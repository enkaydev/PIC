using PIC_Simulator.PIC;
using PIC_Simulator.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PIC_Simulator
{
	public partial class Form1 : Form
	{
		private PICProgramm programm;

		public Timer quartztimer;
		public RS232Verbindung rs232 = new RS232Verbindung();

		public Form1()
		{
			InitializeComponent();

			quartztimer = new Timer();
			quartztimer.Tick += timer1_Tick;

			cbxComPorts.Items.AddRange(rs232.GetSerialPorts().ToArray());

			for (int i = 0; i < 16; i++)
			{
				var item = new ListViewItem(new[] { string.Format("0x{0:X}0", i), "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00" });
				lvMemory.Items.Add(item);
			}

			lvSpecial.Items.Add(new ListViewItem(new[] { "W", "0x00" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "PC", "0x00" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Status", "0b00000000" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Option", "0b00000000" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Intcon", "0b00000000" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Time", "0ms" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "RA (Backing)", "0b00000000" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "RB (Backing)", "0b00000000" }));

			lvSpecial.Items.Add(new ListViewItem(new[] { "Status[C]", "0" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Status[DC]",  "0" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Status[Z]",  "0" }));
			lvSpecial.Items.Add(new ListViewItem(new[] { "Watchdog timer",  "0ms" }));
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			box_CodeView.Font = new Font("Consolas", 8);

			box_CodeView.Text = Resources.TPicSim1;

			programm = new PICProgramm(this);
			programm.Laden(Resources.TPicSim1);

			OberflaecheAktualisieren();
		}

		private void cmd_Start_Click(object sender, EventArgs e)
		{
			quartztimer.Stop();
			quartztimer.Interval = int.Parse(insertTime.Text);
			quartztimer.Start();
			rs232.Disconnect();
		}

		private void cmd_next_Click(object sender, EventArgs e)
		{
			StepProgramm();
		}

		private void programmÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string datei = File.ReadAllText(openFileDialog1.FileName);

				box_CodeView.Text = datei;

				programm = new PICProgramm(this);
				programm.Laden(datei);

				OberflaecheAktualisieren();
			}
		}

		private void cmdOpenDoc_Click(object sender, EventArgs e) // Funktion um externe PDF zu öffnen
		{
			string path = Path.GetTempFileName() + ".pdf";
			File.WriteAllBytes(path, Resources.DataSheet);
			System.Diagnostics.Process.Start(path);
		}

		//Funktion um Zeile aktuell ausgeführte Zeile zu markieren
		void Highlight(int line)
		{
			int i1 = box_CodeView.GetFirstCharIndexFromLine(line);
			int i2 = box_CodeView.GetFirstCharIndexFromLine(line + 1);
			if (i2 < 0 || i1 < 0)
			{
				box_CodeView.SelectionStart = 0;
				box_CodeView.SelectionLength = box_CodeView.TextLength;
				box_CodeView.SelectionBackColor = box_CodeView.BackColor;
			}
			else
			{
				box_CodeView.SelectionStart = 0;
				box_CodeView.SelectionLength = box_CodeView.TextLength;
				box_CodeView.SelectionBackColor = box_CodeView.BackColor;
				box_CodeView.SelectionStart = i1;
				box_CodeView.SelectionLength = i2 - i1;
				box_CodeView.SelectionBackColor = Color.SteelBlue;
			}
		}
		void HighlightBreakpoint(int line) //Breakpoint markieren
		{
			int i1 = box_CodeView.GetFirstCharIndexFromLine(line);
			int i2 = box_CodeView.GetFirstCharIndexFromLine(line) + 4;

			box_CodeView.SelectionStart = i1;
			box_CodeView.SelectionLength = i2 - i1;
			box_CodeView.SelectionBackColor = Color.Red;
		}

		private void cmd_reset_Click(object sender, EventArgs e)
		{
			quartztimer.Stop();
			
			programm = new PICProgramm(this);
			programm.Laden(box_CodeView.Text);
			rs232.Disconnect();

			OberflaecheAktualisieren();
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			StepProgramm();
		}

		private void cmd_Stop_Click(object sender, EventArgs e)
		{
			quartztimer.Stop();
		}

		private void StepProgramm()
		{
			bool finished = programm.Step(int.Parse(insertTime.Text));

			if (finished) { quartztimer.Stop(); MessageBox.Show("Finished"); return; }

			if (programm.Breakpoints.Contains(programm.befehle[programm.PCCounter].labelnummer)) quartztimer.Stop(); // quartztimer wird gestopt und dadurch wird programm angehalten

			OberflaecheAktualisieren();
		}

		public void OberflaecheAktualisieren()
		{
			// Zeile highlighten

			var a = box_CodeView.SelectionStart;

			if (programm.befehle.Count > 0 && programm.PCCounter < programm.befehle.Count)
			{
				Highlight(programm.befehle[programm.PCCounter].zeilennummer);
			}

			foreach (var bp in programm.Breakpoints)
			{
				PICBefehl b = programm.befehle.FirstOrDefault(i => i.labelnummer == bp);
				if (b != null)
				{
					HighlightBreakpoint(b.zeilennummer);
				}
			}

			box_CodeView.SelectionStart = a;
			box_CodeView.SelectionLength = 0;

			// Memory aktualisieren

			for (int y = 0; y < 16; y++)
			{
				for (int x = 0; x < 16; x++)
				{
					string nummer = string.Format("{0:X2}", programm.GetRegisterOhneBank((uint) (y*16 + x)));
					if (nummer != lvMemory.Items[y].SubItems[x + 1].Text) lvMemory.Items[y].SubItems[x+1].Text = nummer;
				}
			}

			// Spezialregister aktualisieren

			lvSpecial.Items[0].SubItems[1].Text  = string.Format("0x{0:X2}", programm.Register_W);
			lvSpecial.Items[1].SubItems[1].Text  = string.Format("{0,4}", programm.PCCounter);
			lvSpecial.Items[2].SubItems[1].Text  = string.Format("0b{0}", Convert.ToString(programm.GetRegisterOhneBank(PICProgramm.ADDR_STATUS), 2).PadLeft(8, '0'));
			lvSpecial.Items[3].SubItems[1].Text  = string.Format("0b{0}", Convert.ToString(programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION), 2).PadLeft(8, '0'));
			lvSpecial.Items[4].SubItems[1].Text  = string.Format("0b{0}", Convert.ToString(programm.GetRegisterOhneBank(PICProgramm.ADDR_INTCON), 2).PadLeft(8, '0'));
			lvSpecial.Items[5].SubItems[1].Text  = string.Format("{0}ms", programm.Stepcount * int.Parse(insertTime.Text));
			lvSpecial.Items[6].SubItems[1].Text  = "0b" + Convert.ToString(programm.Latch_RA, 2).PadLeft(8, '0');
			lvSpecial.Items[7].SubItems[1].Text  = "0b" + Convert.ToString(programm.Latch_RB, 2).PadLeft(8, '0');
			lvSpecial.Items[8].SubItems[1].Text  = programm.GetRegisterOhneBank(PICProgramm.ADDR_STATUS, PICProgramm.STATUS_BIT_C) ? "1" : "0";
			lvSpecial.Items[9].SubItems[1].Text  = programm.GetRegisterOhneBank(PICProgramm.ADDR_STATUS, PICProgramm.STATUS_BIT_DC) ? "1" : "0";
			lvSpecial.Items[10].SubItems[1].Text = programm.GetRegisterOhneBank(PICProgramm.ADDR_STATUS, PICProgramm.STATUS_BIT_Z) ? "1" : "0";
			lvSpecial.Items[11].SubItems[1].Text = string.Format("{0:0.000}ms", programm.WatchDog.time * 1000);

			lbStack.Items.Clear();
			foreach (var u in programm.Stack) lbStack.Items.Add(u.ToString());

			// RA + RB aktualisieren

			btn_RA_0.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 0) ? 1 : 0).ToString();
			btn_RA_1.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 1) ? 1 : 0).ToString();
			btn_RA_2.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 2) ? 1 : 0).ToString();
			btn_RA_3.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 3) ? 1 : 0).ToString();
			btn_RA_4.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 4) ? 1 : 0).ToString();
			btn_RA_5.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 5) ? 1 : 0).ToString();
			btn_RA_6.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 6) ? 1 : 0).ToString();
			btn_RA_7.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 7) ? 1 : 0).ToString();

			btn_RA_Tris_0.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 0) ? "i" : "o");
			btn_RA_Tris_1.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 1) ? "i" : "o");
			btn_RA_Tris_2.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 2) ? "i" : "o");
			btn_RA_Tris_3.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 3) ? "i" : "o");
			btn_RA_Tris_4.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 4) ? "i" : "o");
			btn_RA_Tris_5.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 5) ? "i" : "o");
			btn_RA_Tris_6.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 6) ? "i" : "o");
			btn_RA_Tris_7.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 7) ? "i" : "o");

			btn_RB_0.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 0) ? 1 : 0).ToString();
			btn_RB_1.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 1) ? 1 : 0).ToString();
			btn_RB_2.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 2) ? 1 : 0).ToString();
			btn_RB_3.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 3) ? 1 : 0).ToString();
			btn_RB_4.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 4) ? 1 : 0).ToString();
			btn_RB_5.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 5) ? 1 : 0).ToString();
			btn_RB_6.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 6) ? 1 : 0).ToString();
			btn_RB_7.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B, 7) ? 1 : 0).ToString();

			btn_RB_Tris_0.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 0) ? "i" : "o");
			btn_RB_Tris_1.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 1) ? "i" : "o");
			btn_RB_Tris_2.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 2) ? "i" : "o");
			btn_RB_Tris_3.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 3) ? "i" : "o");
			btn_RB_Tris_4.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 4) ? "i" : "o");
			btn_RB_Tris_5.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 5) ? "i" : "o");
			btn_RB_Tris_6.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 6) ? "i" : "o");
			btn_RB_Tris_7.Text = (programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 7) ? "i" : "o");

			if (btnWD1.Font.Bold != programm.WatchDog.Aktiviert) btnWD1.Font = new Font(btnWD1.Font, programm.WatchDog.Aktiviert ? FontStyle.Bold : FontStyle.Regular); 
			if (btnWD0.Font.Bold == programm.WatchDog.Aktiviert) btnWD0.Font = new Font(btnWD0.Font, programm.WatchDog.Aktiviert ? FontStyle.Regular : FontStyle.Bold);
			if (btnClockStart.Font.Bold != programm.TaktgeberAktiviert) btnClockStart.Font = new Font(btnClockStart.Font, programm.TaktgeberAktiviert ? FontStyle.Bold : FontStyle.Regular);
		}

		private void box_CodeView_DoubleClick(object sender, EventArgs e)
		{
			int line = box_CodeView.GetLineFromCharIndex(box_CodeView.SelectionStart);

			PICBefehl b = programm.befehle.FirstOrDefault(i => i.zeilennummer == line);

			if (b != null)
			{
				if (programm.Breakpoints.Contains(b.labelnummer))
					programm.Breakpoints.Remove(b.labelnummer);
				else
					programm.Breakpoints.Add(b.labelnummer);

				OberflaecheAktualisieren();
			}
		}

		private void btn_RA_Tris_7_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 7, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 7));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_6_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 6, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 6));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_5_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 5, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 5));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_4_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 4, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 4));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_3_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 3, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 3));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_2_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 2, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 2));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_1_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 1, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 1));
			OberflaecheAktualisieren();
		}

		private void btn_RA_Tris_0_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 0, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 0));
			OberflaecheAktualisieren();
		}

		private void btn_RA_7_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 7)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 7, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 7));
			OberflaecheAktualisieren();
		}

		private void btn_RA_6_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 6)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 6, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 6));
			OberflaecheAktualisieren();
		}

		private void btn_RA_5_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 5)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 5, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 5));
			OberflaecheAktualisieren();
		}

		private void btn_RA_4_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 4)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 4, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 4));
			OberflaecheAktualisieren();
		}

		private void btn_RA_3_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 3)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 3, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 3));
			OberflaecheAktualisieren();
		}

		private void btn_RA_2_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 2)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 2, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 2));
			OberflaecheAktualisieren();
		}

		private void btn_RA_1_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 1)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 1, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 1));
			OberflaecheAktualisieren();
		}

		private void btn_RA_0_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, 0)) return;
			programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_A], 0, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_A], 0));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_7_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 7, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 7));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_6_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 6, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 6));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_5_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 5, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 5));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_4_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 4, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 4));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_3_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 3, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 3));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_2_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 2, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 2));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_1_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 1, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 1));
			OberflaecheAktualisieren();
		}

		private void btn_RB_Tris_0_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			programm.SetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 0, !programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 0));
			OberflaecheAktualisieren();
		}

		private void btn_RB_7_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 7)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 7, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 7));
			OberflaecheAktualisieren();
		}

		private void btn_RB_6_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 6)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 6, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 6));
			OberflaecheAktualisieren();
		}

		private void btn_RB_5_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 5)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 5, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 5));
			OberflaecheAktualisieren();
		}

		private void btn_RB_4_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 4)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 4, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 4));
			OberflaecheAktualisieren();
		}

		private void btn_RB_3_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 3)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 3, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 3));
			OberflaecheAktualisieren();
		}

		private void btn_RB_2_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 2)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 2, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 2));
			OberflaecheAktualisieren();
		}

		private void btn_RB_1_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 1)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 1, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 1));
			OberflaecheAktualisieren();
		}

		private void btn_RB_0_Click(object sender, EventArgs e)
		{
			if (programm == null) return;
			if (!programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, 0)) return;
			programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(programm.Register[PICProgramm.ADDR_PORT_B], 0, !PICProgramm.GetBit(programm.Register[PICProgramm.ADDR_PORT_B], 0));
			OberflaecheAktualisieren();
		}

		private void btnRSConnect_Click(object sender, EventArgs e)
		{
			rs232.Connect(cbxComPorts.SelectedItem.ToString(), edRS232Log, programm, this);
			OberflaecheAktualisieren();
		}

		private void btnRSDisconnect_Click(object sender, EventArgs e)
		{
			rs232.Disconnect();
			OberflaecheAktualisieren();
		}

		private void btnClockStart_Click(object sender, EventArgs e)
		{
			programm.TaktgeberAktiviert = !programm.TaktgeberAktiviert;
			programm.TaktgeberFrequenz = int.Parse(edCLockFreq.Text);
			programm.TaktgeberZahler = 0;
			programm.TaktgeberAdresse = Convert.ToUInt32(edClockAddr.Text.Substring(2), 16);
			programm.TaktgeberBitnummer = uint.Parse(edClockBit.Text);
			OberflaecheAktualisieren();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            programm.IsSleeping = false; //Kein WatchdogTimer implementiert, Sleep durch button deaktiviert
	        OberflaecheAktualisieren();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			programm.WatchDog.TimeOut = double.Parse(tbWD.Text, CultureInfo.InvariantCulture) / 1000d;
			programm.WatchDog.Aktiviert = true;
			OberflaecheAktualisieren();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			programm.WatchDog.Aktiviert = false;
			OberflaecheAktualisieren();
		}
    }
}

