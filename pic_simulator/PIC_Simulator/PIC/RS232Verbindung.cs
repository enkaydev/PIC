using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace PIC_Simulator.PIC
{
	public class RS232Verbindung
	{
		private SerialPort ComPort;
		private PICProgramm Programm;
		private TextBox TextBox;
		private Form1 Fenster;

		private Timer timer;

		public RS232Verbindung()
		{
			timer = new Timer();
			timer.Tick += TimerOnTick;
			timer.Interval = 500;
			timer.Enabled = true;
		}

		private void TimerOnTick(object sender, EventArgs eventArgs)
		{
			if (ComPort == null) return;
			if (!ComPort.IsOpen) return;

			SendData();
			RecieveData();
		}

		public List<string> GetSerialPorts()
		{
			string[] ArrayComPortsNames = null;
			int index = -1;
			string ComPortName = null;

			List<string> result = new List<string>();

			ArrayComPortsNames = SerialPort.GetPortNames();
			if (ArrayComPortsNames.Length == 0) return result;
			do
			{
				index += 1;
				result.Add(ArrayComPortsNames[index]);
			}
			while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));

			return result.OrderBy(p => p).ToList();
		}

		public void Connect(string port, TextBox logbox, PICProgramm prog, Form1 f)
		{
			ComPort = new SerialPort();

			ComPort.PortName = port;
			ComPort.BaudRate = 4800;
			ComPort.DataBits = 8;
			ComPort.Parity = Parity.None;
			ComPort.StopBits = StopBits.One;

			try
			{
				ComPort.Open();
			}
			catch (Exception ex)
			{
				logbox.Text += ex + "\r\n";
				ComPort = null;
				return;
			}

			if (ComPort.IsOpen)
			{
				logbox.Text += "Connected to " + port + "\r\n";
				Programm = prog;
				TextBox = logbox;
				Fenster = f;
				return;
			}

			ComPort = null;
		}

		public void Disconnect()
		{
			if (ComPort == null) return;
			ComPort.Close();
			ComPort = null;
		}

		private void SendData()
		{
			string p_a = encodeByte(Programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A));
			string t_a = encodeByte(Programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A));
			string p_b = encodeByte(Programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B));
			string t_b = encodeByte(Programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B));

			string send = t_a + p_a + t_b + p_b;

			Send_RS232(send);
		}

		private void Send_RS232(string txt)
		{
			if (txt != string.Empty)
			{
				ComPort.Write(txt + '\r');
				TextBox.Text += "> " + txt + "\r\n";
			}
		}

		private void RecieveData()
		{
			string x = ReadDataSegment();

			if (x != string.Empty)
			{
				if (x == null)
				{
					TextBox.Text += ("< [ERR-R] NULL") + "\r\n";
				}
				else if (x.Length == 4)
				{
					TextBox.Text += ("< " + x) + "\r\n";

					var v = decodeBytes(x);

					if (v == null)
					{
						TextBox.Text += ("< [ERR-D] " + x) + "\r\n";
					}
					else
					{
						for (uint i = 0; i < 8; i++)
						{
							// Nur 'i' bits übernehmen

							if (Programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A, i))
								Programm.Register[PICProgramm.ADDR_PORT_A] = PICProgramm.SetBit(Programm.Register[PICProgramm.ADDR_PORT_A], i, !PICProgramm.GetBit((byte)v.Item1, i));
							if (Programm.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B, i))
								Programm.Register[PICProgramm.ADDR_PORT_B] = PICProgramm.SetBit(Programm.Register[PICProgramm.ADDR_PORT_B], i, !PICProgramm.GetBit((byte)v.Item1, i));
						}

						Fenster.OberflaecheAktualisieren();
					}
				}
				else
				{
					TextBox.Text += ("< [ERR-L] " + x) + "\r\n";
				}

				x = ReadDataSegment();
			}
		}

		private string encodeByte(uint b)
		{
			char c1 = (char)(0x30 + ((b & 0xF0) >> 4));
			char c2 = (char)(0x30 + (b & 0x0F));

			return "" + c1 + c2;
		}

		private Tuple<uint, uint> decodeBytes(string s)
		{
			int i0 = s[0] - 0x30;
			int i1 = s[1] - 0x30;
			int i2 = s[2] - 0x30;
			int i3 = s[3] - 0x30;

			if (i0 >= 0 && i1 >= 0 && i2 >= 0 && i3 >= 0 && i0 <= 0xF && i1 <= 0xF && i2 <= 0xF && i3 <= 0xF)
			{
				uint a = (((uint)i0 & 0x0F) << 4) | ((uint)i1 & 0x0F);
				uint b = (((uint)i2 & 0x0F) << 4) | ((uint)i3 & 0x0F);

				return Tuple.Create(a, b);
			}
			else
			{
				return null;
			}
		}

		private string ReadDataSegment()
		{
			string s = "";

			if (ComPort.BytesToRead >= 5)
			{
				char? c = null;

				int idx = 5;
				while (c != '\r' && idx > 0)
				{
					c = (char)ComPort.ReadByte();

					s += c;

					idx--;
				}

				if (idx <= 0 && c != '\r')
				{
					return null;
				}
			}
			else
			{
				return string.Empty;
			}

			return s.Trim('\r');
		}

	}
}
