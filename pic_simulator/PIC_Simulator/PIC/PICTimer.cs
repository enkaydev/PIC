
namespace PIC_Simulator.PIC
{
	public class PICTimer
	{
		private PICProgramm programm;

		public PICTimer(PICProgramm p)
		{
			programm = p;
		}

		private bool prev_RA4 = false;
		public void TimerBerechnen(uint cycles)
		{
			bool tmr_mode = programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_T0CS);
			bool edge_mode = programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_T0SE);

			if (tmr_mode)
			{
				bool curr_A4 = programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 4);

				if (edge_mode)
				{
					if (prev_RA4 && !curr_A4)
					{
						TimerHochzaehlen(cycles);
					}
				}
				else
				{
					if (!prev_RA4 && curr_A4)
					{
						TimerHochzaehlen(cycles);
					}
				}
			}
			else
			{
				TimerHochzaehlen(cycles);
			}

			prev_RA4 = programm.GetRegisterOhneBank(PICProgramm.ADDR_PORT_A, 4);
		}

		private uint count = 0; // Zähler für timer

		private void TimerHochzaehlen(uint cycles)
		{
			uint current = programm.Register[PICProgramm.ADDR_TMR0];
			uint scale = BerechneVorskalierung();

			count += cycles;

			while (count >= scale)
			{
				count -= scale;

				uint Result = current + 1;
				if (Result > 0xFF)
				{
					programm.TimerInterrupt();
				}

				Result %= 0x100;

				uint tmp_psc = count;
				programm.Register[PICProgramm.ADDR_TMR0] = (byte) Result;
				count = tmp_psc;
			}
		}

		private uint BerechneVorskalierung()
		{
			bool prescale_mode = programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PSA);

			uint scale = 0;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS2) ? 1U : 0U;
			scale *= 2;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS1) ? 1U : 0U;
			scale *= 2;
			scale += programm.GetRegisterOhneBank(PICProgramm.ADDR_OPTION, PICProgramm.OPTION_BIT_PS0) ? 1U : 0U;

			return prescale_mode ? 1 : (PICProgramm.SHL(2, scale));
		}

		public void Reset()
		{
			count = 0;
		}
	}
}
