
namespace PIC_Simulator.PIC
{
	public class PICWatchDog
	{
		private PICProgramm programm;

		public double TimeOut = 0.018; // ms;

		private const double FREQUENCY = 4000000d; // 4 MHz

		public uint Prescale = 1;

		public double time; // in s

		public bool Aktiviert = false;

		private Form1 form;

		public PICWatchDog(PICProgramm p, Form1 frm)
		{
			programm = p;
			time = 0;
			form = frm;
		}

		public void Aktualisieren(uint cycles) //Überprüfung ob eingeschaltet
		{
			if (Aktiviert)
			{
				time += (1.0 / FREQUENCY) * cycles;

				if (time > TimeOut * GetPreScale()) //Wenn Timer größer als TimeOut -> Programm reset
				{
					WDReset();
				}
			}
			else
			{
				time = 0;
			}
		}

		private void WDReset()
		{
			if (!programm.IsSleeping) //Programm ist nicht im Sleep -> Programm wird geresetet
			{
				// >> WATCHDOG RESET <<

				time = 0;

				programm.Reset();
				programm.SetRegisterOhneBank(PICProgramm.ADDR_STATUS, PICProgramm.STATUS_BIT_TO, false);
				form.quartztimer.Stop();
			}
			else //Programm ist im Sleep -> SoftReset -> Programm "wacht auf"
			{
				// >> Wake Up <<

				time = 0;

				programm.IsSleeping = false;
			}
		}

		private uint GetPreScale() //Vorskallierung Option-Register 3 bit werden binär interpretiert und geben Skalierung an (1:Binärwert)
        {
			bool prescale_mode = !programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PSA);

			uint scale = 0;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS2) ? 1U : 0U;
			scale *= 2;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS1) ? 1U : 0U;
			scale *= 2;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS0) ? 1U : 0U;

			Prescale = prescale_mode ? 1 : (PICProgramm.SHL(1, scale));

			return Prescale;
		}

		public void Reset() //Reset setzt Timer auf 0
		{
			time = 0;
		}
	}
}
