
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PIC_Simulator.PIC
{
	public class PICBefehl
	{
		public string befehl;
		public uint parameter_d;
		public uint parameter_f;
		public uint parameter_x;
		public uint parameter_k;
		public uint parameter_b;

		public int labelnummer;

		public int zeilennummer;
	}

	public class PICProgramm
	{
		public const uint ADDR_INDF = 0x00;
		public const uint ADDR_TMR0 = 0x01;
		public const uint ADDR_PCL = 0x02;
		public const uint ADDR_STATUS = 0x03;
		public const uint ADDR_FSR = 0x04;
		public const uint ADDR_PORT_A = 0x05;
		public const uint ADDR_PORT_B = 0x06;
		public const uint ADDR_UNIMPL_A = 0x07;
		public const uint ADDR_PCLATH = 0x0A;
		public const uint ADDR_INTCON = 0x0B;

		public const uint ADDR_OPTION = 0x81;
		public const uint ADDR_TRIS_A = 0x85;
		public const uint ADDR_TRIS_B = 0x86;
		public const uint ADDR_UNIMPL_B = 0x87;
		public const uint ADDR_EECON1 = 0x88;
		public const uint ADDR_EECON2 = 0x89;

		public const uint STATUS_BIT_IRP = 7;		// Unused in PIC16C84
		public const uint STATUS_BIT_RP1 = 6;		// Register Bank Selection Bit [1] (Unused in PIC16C84)
		public const uint STATUS_BIT_RP0 = 5;		// Register Bank Selection Bit [0]
		public const uint STATUS_BIT_TO = 4;		// Time Out Bit
		public const uint STATUS_BIT_PD = 3;		// Power Down Bit
		public const uint STATUS_BIT_Z = 2;			// Zero Bit
		public const uint STATUS_BIT_DC = 1;		// Digit Carry Bit
		public const uint STATUS_BIT_C = 0;			// Carry Bit

		public const uint OPTION_BIT_RBPU = 7;		// PORT-B Pull-Up Enable Bit
		public const uint OPTION_BIT_INTEDG = 6;	// Interrupt Edge Select Bit
		public const uint OPTION_BIT_T0CS = 5;		// TMR0 Clock Source Select Bit
		public const uint OPTION_BIT_T0SE = 4;		// TMR0 Source Edge Select Bit
		public const uint OPTION_BIT_PSA = 3;		// Prescaler Alignment Bit
		public const uint OPTION_BIT_PS2 = 2;		// Prescaler Rate Select Bit [2]
		public const uint OPTION_BIT_PS1 = 1;		// Prescaler Rate Select Bit [1]
		public const uint OPTION_BIT_PS0 = 0;		// Prescaler Rate Select Bit [0]

		public const uint INTCON_BIT_GIE = 7;		// Global Interrupt Enable Bit
		public const uint INTCON_BIT_EEIE = 6;		// EE Write Complete Interrupt Enable Bit
		public const uint INTCON_BIT_T0IE = 5;		// TMR0 Overflow Interrupt Enable Bit
		public const uint INTCON_BIT_INTE = 4;		// RB0/INT Interrupt Bit
		public const uint INTCON_BIT_RBIE = 3;		// RB Port Change Interrupt Enable Bit
		public const uint INTCON_BIT_T0IF = 2;		// TMR0 Overflow Interrupt Flag Bit
		public const uint INTCON_BIT_INTF = 1;		// RB0/INT Interrupt Flag Bit
		public const uint INTCON_BIT_RBIF = 0;		// RB Port Change Interrupt Flag Bit

		public const uint INTERRUPT_SERVICE_ADDRESS = 0x04;


		public const string ADDWF  = "000111dfffffff";
		public const string ANDWF  = "000101dfffffff";
		public const string CLRF   = "0000011fffffff";
		public const string CLRW   = "0000010xxxxxxx";
		public const string COMF   = "001001dfffffff";
		public const string DECF   = "000011dfffffff";
		public const string DECFSZ = "001011dfffffff";
		public const string INCF   = "001010dfffffff";
		public const string INCFSZ = "001111dfffffff";
		public const string IORWF  = "000100dfffffff";
		public const string MOVF   = "001000dfffffff";
		public const string MOVWF  = "0000001fffffff";
		public const string NOP    = "0000000xx00000";
		public const string RLF    = "001101dfffffff";
		public const string RRF    = "001100dfffffff";
		public const string SUBWF  = "000010dfffffff";
		public const string SWAPF  = "001110dfffffff";
		public const string XORWF  = "000110dfffffff";

		public const string BCF    = "0100bbbfffffff";
		public const string BSF    = "0101bbbfffffff";
		public const string BTFSC  = "0110bbbfffffff";
		public const string BTFSS  = "0111bbbfffffff";
		
		public const string ADDLW  = "11111xkkkkkkkk";
		public const string ANDLW  = "111001kkkkkkkk";
		public const string CALL   = "100kkkkkkkkkkk";
		public const string CLRWDT = "00000001100100";
		public const string GOTO   = "101kkkkkkkkkkk";
		public const string IORLW  = "111000kkkkkkkk";
		public const string MOVLW  = "1100xxkkkkkkkk";
		public const string RETFIE = "00000000001001";
		public const string RETLW  = "1101xxkkkkkkkk";
		public const string RETURN = "00000000001000";
		public const string SLEEP  = "00000001100011";
		public const string SUBLW  = "11110xkkkkkkkk";
		public const string XORLW  = "111010kkkkkkkk";

		public string[] ALL_COMMANDS = {ADDWF, ANDWF, CLRF, CLRW, COMF, DECF, DECFSZ, INCF, INCFSZ, IORWF, MOVF, MOVWF, NOP, RLF, RRF, SUBWF, SWAPF, XORWF, BCF, BSF, BTFSC, BTFSS, ADDLW, ANDLW, CALL, CLRWDT, GOTO, IORLW, MOVLW, RETFIE, RETLW, RETURN, SLEEP, SUBLW, XORLW  };

		public List<PICBefehl> befehle;

		public int PCCounter = 0; // -> nächster befehl
		public int Stepcount = 0;
		public byte Register_W = 0;
		public byte[] Register = new byte[0x100];
		public Stack<uint> Stack = new Stack<uint>();
		public bool IsSleeping = false;

		public byte Latch_RA = 0;
		public byte Latch_RB = 0;

		public List<int> Breakpoints = new List<int>();

		public int TaktgeberFrequenz = 100000;
		public int TaktgeberZahler = 0;
		public bool TaktgeberAktiviert = false;
		public uint TaktgeberAdresse = 0;
		public uint TaktgeberBitnummer = 0;

		public PICTimer Zaehler;
		public PICWatchDog WatchDog;

		public byte Merker_RB0;

		public PICProgramm(Form1 f)
		{
			Zaehler = new PICTimer(this);
			WatchDog = new PICWatchDog(this, f);

			// Anfangswerte

			Reset();
		}

		public void Laden(string code)
		{
			befehle = new List<PICBefehl>();

			int zn = -1;
			foreach (var zeile in Regex.Split(code, @"\r?\n"))
			{
				zn++;

				if (zeile.StartsWith("         ")) continue;
				if (zeile.Length < 10) continue;

				befehle.Add(FindeBefehl(zeile, zn));
			}
		}

		private PICBefehl FindeBefehl(string zeile, int zeilennummer)
		{
			foreach (var cmd in ALL_COMMANDS)
			{
				string bin = hex2binary(zeile.Substring(5, 4));

				uint p_d = 0;
				uint p_f = 0;
				uint p_x = 0;
				uint p_k = 0;
				uint p_b = 0;

				bool ok = true;

				for (int i = 0; i < 14; i++)
				{
					if (cmd[i] == '0' && bin[i] == '0') continue;
					if (cmd[i] == '1' && bin[i] == '1') continue;
					if (cmd[i] == 'd' && bin[i] == '0') { p_d <<= 1; p_d |= 0; continue; }
					if (cmd[i] == 'd' && bin[i] == '1') { p_d <<= 1; p_d |= 1; continue; }
					if (cmd[i] == 'f' && bin[i] == '0') { p_f <<= 1; p_f |= 0; continue; }
					if (cmd[i] == 'f' && bin[i] == '1') { p_f <<= 1; p_f |= 1; continue; }
					if (cmd[i] == 'x' && bin[i] == '0') { p_x <<= 1; p_x |= 0; continue; }
					if (cmd[i] == 'x' && bin[i] == '1') { p_x <<= 1; p_x |= 1; continue; }
					if (cmd[i] == 'k' && bin[i] == '0') { p_k <<= 1; p_k |= 0; continue; }
					if (cmd[i] == 'k' && bin[i] == '1') { p_k <<= 1; p_k |= 1; continue; }
					if (cmd[i] == 'b' && bin[i] == '0') { p_b <<= 1; p_b |= 0; continue; }
					if (cmd[i] == 'b' && bin[i] == '1') { p_b <<= 1; p_b |= 1; continue; }
					if (cmd[i] == '0' && bin[i] == '1') { ok = false; break; }
					if (cmd[i] == '1' && bin[i] == '0') { ok = false; break; }

					throw new Exception("Falscher wert in cmd");
				}

				if (ok)
				{
					PICBefehl b = new PICBefehl();
					b.befehl = cmd;
					b.parameter_d = p_d;
					b.parameter_f = p_f;
					b.parameter_k = p_k;
					b.parameter_x = p_x;
					b.parameter_b = p_b;
					b.zeilennummer = zeilennummer;
					b.labelnummer = Convert.ToInt32(zeile.Substring(0, 4), 16);
					return b;
				}
			}

			throw new Exception("konnte befehl nicht finden: " + zeile);
		}

		private string hex2binary(string hexvalue)
		{
			string binaryval = "";
			binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2).PadLeft(14, '0');
			return binaryval;
		}

		public bool Step(int frequenz)
		{
			if (PCCounter >= befehle.Count) return true;

			PICBefehl aktueller_befehl = befehle[PCCounter];

			if (TaktgeberAktiviert)
			{
				TaktgeberZahler += frequenz;
				if (TaktgeberZahler >= TaktgeberFrequenz)
				{
					TaktgeberZahler = 0;
					SetRegisterOhneBank(TaktgeberAdresse, TaktgeberBitnummer, !GetRegisterOhneBank(TaktgeberAdresse, TaktgeberBitnummer));
				}
			}

			if (IsSleeping) { WatchDog.Aktualisieren(1); return false;}

			uint cycleCount = 1;

			if (aktueller_befehl.befehl == ADDWF)
			{
				// Add the contents of the W register with
				// register 'f'.If 'd' is 0 the result is stored
				// in the W register.If 'd' is 1 the result is
				// stored back in register 'f'.

				byte a = GetRegister(aktueller_befehl.parameter_f);
				byte b = Register_W;

				uint Result = (uint) (a + b);
				bool dc = AdditionDigitCarry(a, b);

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, (Result % 0x100) == 0);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_DC, dc);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, Result > 0xFF);

				Result %= 0x100;

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, (byte)Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == ANDWF)
			{
				// AND the W register with register 'f'.If 'd'
				// is 0 the result is stored in the W regis -
				// ter.If 'd' is 1 the result is stored back in
				// register 'f'

				byte Result = (byte)(Register_W & GetRegister(aktueller_befehl.parameter_f));

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = Result;
			}
			else if (aktueller_befehl.befehl == CLRF)
			{
				// The contents of register 'f' are cleared
				// and the Z bit is set.

				SetRegister(aktueller_befehl.parameter_f, 0x00);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, true);
			}
			else if (aktueller_befehl.befehl == CLRW)
			{
				// W register is cleared.Zero bit (Z) is
				// set.

				Register_W = 0;
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, true);
			}
			else if (aktueller_befehl.befehl == COMF)
			{
				// The contents of register 'f' are comple-
				// mented.If 'd' is 0 the result is stored in
				// W.If 'd' is 1 the result is stored back in
				// register 'f'.

				byte Result = (byte)~GetRegister(aktueller_befehl.parameter_f);

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = Result;
			}
			else if (aktueller_befehl.befehl == DECF)
			{
				// Decrement register 'f'.If 'd' is 0 the
				// result is stored in the W register.If 'd' is
				// 1 the result is stored back in register 'f'.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				if (Result == 0)
					Result = 0xFF;
				else
					Result -= 1;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == DECFSZ)
			{
				// The contents of register 'f' are decre-
				// mented.If 'd' is 0 the result is placed in the
				// W register.If 'd' is 1 the result is placed
				// back in register 'f'.
				// If the result is 1, the next instruction, is
				// executed.If the result is 0, then a NOP is
				// executed instead making it a 2T CY instruc -
				// tion.

				bool Cond = GetRegister(aktueller_befehl.parameter_f) == 1;

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				if (Result == 0)
					Result = 0xFF;
				else
					Result -= 1;

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;

				if (Cond)
				{
					PCCounter++; // skip next
					cycleCount = 2;
				}
			}
			else if (aktueller_befehl.befehl == INCF)
			{
				// The contents of register 'f' are incre-
				// mented.If 'd' is 0 the result is placed in
				// the W register.If 'd' is 1 the result is
				// placed back in register 'f'.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				Result += 1;

				Result %= 0x100;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == INCFSZ)
			{
				// The contents of register 'f' are incre-
				// mented.If 'd' is 0 the result is placed in
				// the W register.If 'd' is 1 the result is
				// placed back in register 'f'.
				// If the result is 1, the next instruction is
				// executed.If the result is 0, a NOP is exe -
				// cuted instead making it a 2T CY instruc -
				// tion

				bool Cond = GetRegister(aktueller_befehl.parameter_f) == 0xFF;

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				Result += 1;

				Result %= 0x100;

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;

				if (Cond)
				{
					PCCounter++; // skip next
					cycleCount = 2;
				}
			}
			else if (aktueller_befehl.befehl == IORWF)
			{
				// Inclusive OR the W register with regis -
				// ter 'f'.If 'd' is 0 the result is placed in the
				// W register.If 'd' is 1 the result is placed
				// back in register 'f'.

				byte Result = (byte)(Register_W | GetRegister(aktueller_befehl.parameter_f));

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = Result;
			}
			else if (aktueller_befehl.befehl == MOVF)
			{
				// The contents of register f is moved to a
				// destination dependant upon the status
				// of d. If d = 0, destination is W register. If
				// d = 1, the destination is file register f
				// itself.d = 1 is useful to test a file regis-
				// ter since status flag Z is affected.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == MOVWF)
			{
				// Move data from W register to register
				// 'f'

				SetRegister(aktueller_befehl.parameter_f, Register_W);
			}
			else if (aktueller_befehl.befehl == NOP)
			{
				//No operation.
			}
			else if (aktueller_befehl.befehl == RLF)
			{
				// The contents of register 'f' are rotated
				// one bit to the left through the Carry
				// Flag.If 'd' is 0 the result is placed in the
				// W register.If 'd' is 1 the result is stored
				// back in register 'f'.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				uint Carry_Old = GetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C) ? 1u : 0u;
				uint Carry_New = (Result & 0x80) >> 7;

				Result = Result << 1;
				Result &= 0xFF;

				Result |= Carry_Old;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, Carry_New != 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == RRF)
			{
				// The contents of register 'f' are rotated
				// one bit to the right through the Carry
				// Flag.If 'd' is 0 the result is placed in the
				// W register.If 'd' is 1 the result is placed
				// back in register 'f'.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				uint Carry_Old = GetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C) ? 0x80u : 0x00u;
				uint Carry_New = Result & 0x01;

				Result = Result >> 1;
				Result &= 0xFF;

				Result |= Carry_Old;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, Carry_New != 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == SUBWF)
			{
				// Subtract(2’s complement method) W reg-
				// ister from register 'f'.If 'd' is 0 the result is
				// stored in the W register.If 'd' is 1 the
				// result is stored back in register 'f'.

				uint a = GetRegister(aktueller_befehl.parameter_f);
				uint b = Register_W;

				bool carry = (a + ((~b) & 0xFF)) > 0xFF;

				bool dc = SubtractionDigitCarry((byte)a, (byte)b);

				if (a < b)
				{
					a += 0x100;
				}

				uint Result = a - b;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, (Result % 0x100) == 0);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_DC, dc);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, carry);

				Result %= 0x100;

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == SWAPF)
			{
				// The upper and lower nibbles of register
				// 'f' are exchanged. If 'd' is 0 the result is
				// placed in W register. If 'd' is 1 the result
				// is placed in register 'f'.

				uint Result = GetRegister(aktueller_befehl.parameter_f);

				uint Low = Result & 0x0F;
				uint High = Result & 0xF0;

				Result = (Low << 4) | (High >> 4);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == XORWF)
			{
				// Exclusive OR the contents of the W
				// register with register 'f'.If 'd' is 0 the
				// result is stored in the W register.If 'd' is
				// 1 the result is stored back in register 'f'.

				byte Result = (byte)(Register_W ^ GetRegister(aktueller_befehl.parameter_f));

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				if (aktueller_befehl.parameter_d != 0)
					SetRegister(aktueller_befehl.parameter_f, Result);
				else
					Register_W = Result;
			}
			else if (aktueller_befehl.befehl == BCF)
			{
				// Bit 'b' in register 'f' is cleared 

				SetRegister(aktueller_befehl.parameter_f, aktueller_befehl.parameter_b, false);
			}
			else if (aktueller_befehl.befehl == BSF)
			{
				// Bit 'b' in register 'f' is set.

				SetRegister(aktueller_befehl.parameter_f, aktueller_befehl.parameter_b, true);
			}
			else if (aktueller_befehl.befehl == BTFSC)
			{
				// If bit 'b' in register 'f' is '1' then the next
				// instruction is executed.
				// If bit 'b', in register 'f', is '0' then the next
				// instruction is discarded, and a NOP is
				// executed instead, making this a 2T CY
				// instruction

				if (!GetBit(GetRegister(aktueller_befehl.parameter_f), aktueller_befehl.parameter_b))
				{
					PCCounter++;
					cycleCount = 2;
				}
			}
			else if (aktueller_befehl.befehl == BTFSS)
			{
				// If bit 'b' in register 'f' is '0' then the next
				// instruction is executed.
				// If bit 'b' is '1', then the next instruction is
				// discarded and a NOP is executed
				// instead, making this a 2T CY instruction.

				if (GetBit(GetRegister(aktueller_befehl.parameter_f), aktueller_befehl.parameter_b))
				{
					PCCounter++;
					cycleCount = 2;
				}
			}
			else if (aktueller_befehl.befehl == ADDLW)
			{
				// The contents of the W register are
				// added to the eight bit literal 'k' and the
				// result is placed in the W register

				uint a = Register_W;
				uint b = aktueller_befehl.parameter_k;

				uint Result = a + b;
				bool dc = AdditionDigitCarry((byte)a, (byte)b);

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, (Result % 0x100) == 0);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_DC, dc);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, Result > 0xFF);

				Result %= 0x100;

				Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == ANDLW)
			{
				// The contents of W register are
				// AND’ed with the eight bit literal 'k'.The
				// result is placed in the W register

				uint Result = Register_W & aktueller_befehl.parameter_k;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == CALL)
			{
				// Call Subroutine. First, return address
				// (PC + 1) is pushed onto the stack. The
				// eleven bit immediate address is loaded
				// into PC bits<10:0 >.The upper bits of
				// the PC are loaded from PCLATH.CALL
				// is a two cycle instruction.

				Stack.Push((uint) PCCounter);
				PCCounter = (int) (aktueller_befehl.parameter_k - 1);
				cycleCount = 2;
			}
			else if (aktueller_befehl.befehl == CLRWDT)
			{
				// CLRWDT instruction resets the Watch -
				// dog Timer.It also resets the prescaler
				// of the WDT. Status bits TO and PD are
				// set.

				WatchDog.Reset();

				if (GetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PSA))
				{
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS0, false);
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS1, false);
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS2, false);
				}

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_TO, true);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_PD, true);
			}
			else if (aktueller_befehl.befehl == GOTO)
			{
				// GOTO is an unconditional branch.The
				// eleven bit immediate value is loaded
				// into PC bits<10:0>.The upper bits of
				// PC are loaded from PCLATH<4:3>.
				// GOTO is a two cycle instruction.

				PCCounter = befehle.FindIndex(b => b.labelnummer == aktueller_befehl.parameter_k) - 1;
				cycleCount = 2;
			}
			else if (aktueller_befehl.befehl == IORLW)
			{
				// The contents of the W register is
				// OR’ed with the eight bit literal 'k'.The
				// result is placed in the W register

				uint Result = Register_W | aktueller_befehl.parameter_k;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == MOVLW)
			{
				// The eight bit literal 'k' is loaded into W
				// register.The don’t cares will assemble
				// as 0’s.

				Register_W = (byte)aktueller_befehl.parameter_k;
			}
			else if (aktueller_befehl.befehl == RETFIE)
			{
				// Return from Interrupt.Stack is POPed
				// and Top of Stack(TOS) is loaded in the
				// PC.Interrupts are enabled by setting
				// Global Interrupt Enable bit, GIE
				// (INTCON < 7 >).This is a two cycle
				// instruction.

				PCCounter = (int) Stack.Pop();
				SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE, true);
				cycleCount = 2;
			}
			else if (aktueller_befehl.befehl == RETLW)
			{
				// The W register is loaded with the eight
				// bit literal 'k'.The program counter is
				// loaded from the top of the stack(the
				// return address). This is a two cycle
				// instruction.
				Register_W = (byte)aktueller_befehl.parameter_k;
				PCCounter = (int) Stack.Pop();
				cycleCount = 2;
			}
			else if (aktueller_befehl.befehl == RETURN)
			{
				// Return from subroutine. The stack is
				// POPed and the top of the stack(TOS)
				// is loaded into the program counter.This
				// is a two cycle instruction.
				PCCounter = (int)Stack.Pop();
				cycleCount = 2;
			}
			else if (aktueller_befehl.befehl == SLEEP)
			{
				// The power-down status bit, PD is
				// cleared.Time -out status bit, TO is
				// set.Watchdog Timer and its prescaler
				// are cleared.
				// The processor is put into SLEEP
				// mode with the oscillator stopped. See
				// Section 14.8 for more details.

				if (GetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PSA))
				{
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS0, false);
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS1, false);
					SetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_PS2, false);
				}

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_TO, true);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_PD, false);

				IsSleeping = true;
			}
			else if (aktueller_befehl.befehl == SUBLW)
			{
				// The W register is subtracted (2’s comple-
				// ment method) from the eight bit literal 'k'.
				// The result is placed in the W register.

				uint a = aktueller_befehl.parameter_k;
				uint b = Register_W;

				bool carry;

				bool dc = SubtractionDigitCarry((byte)a, (byte)b);

				if (carry = a < b)
				{
					a += 0x100;
				}

				uint Result = a - b;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, (Result % 0x100) == 0);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_DC, dc);
				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_C, !carry);

				Result %= 0x100;

				Register_W = (byte)Result;
			}
			else if (aktueller_befehl.befehl == XORLW)
			{
				// The contents of the W register are
				// XOR’ed with the eight bit literal 'k'.
				// The result is placed in the W regis -
				// ter.

				uint Result = Register_W ^ aktueller_befehl.parameter_k;

				SetRegisterOhneBank(ADDR_STATUS, STATUS_BIT_Z, Result == 0);

				Register_W = (byte)Result; ;
			}

			PCCounter++;
			Stepcount++;

			Zaehler.TimerBerechnen(cycleCount);

			WatchDog.Aktualisieren(cycleCount);

			if (Merker_RB0 != Register[ADDR_PORT_B])
			{
				Interrupt_RB(Merker_RB0, Register[ADDR_PORT_B]);
				Merker_RB0 = Register[ADDR_PORT_B];
			}

			return PCCounter >= befehle.Count;
		}

		public void SetRegisterOhneBank(uint index, uint wert)
		{
			// register die nur einmal auf bank1 + 2 existieren
			if (index == ADDR_PCL + 0x80) index -= 0x80;
			if (index == ADDR_STATUS + 0x80) index -= 0x80;
			if (index == ADDR_FSR + 0x80) index -= 0x80;
			if (index == ADDR_PCLATH + 0x80) index -= 0x80;
			if (index == ADDR_INTCON + 0x80) index -= 0x80;

			if (index == ADDR_PCL) // PC direkt setzen
			{
				wert &= 0xFF; // Only Low 8 Bit
				uint high = GetRegister(ADDR_PCLATH);
				high &= 0x1F; // Only Bit <0,1,2,3,4>
				high <<= 8;

				PCCounter = (int) (high | wert);
			}

			if (index == ADDR_INDF) // indirekte Adresierung
			{
				if (Register[ADDR_FSR] % 0x80 != 0) Register[Register[ADDR_FSR]] = (byte)(wert & 0xFF);
				return;
			}

			if (index == ADDR_PORT_B)
			{
				Interrupt_RB(Register[index], (byte)wert);
			}

			if (index == ADDR_TMR0)
			{
				Zaehler.Reset();
			}

			if (index == ADDR_PORT_A)
			{
				var ta = Register[ADDR_TRIS_A];

				Latch_RA = (byte)(wert & 0xFF);

				for (uint i = 0; i < 8; i++)
				{
					if (!GetBit(ta, i)) Register[ADDR_PORT_A] = SetBit(Register[ADDR_PORT_A], i, GetBit(Latch_RA, i));
				}
				return;
			}

			if (index == ADDR_PORT_B)
			{
				var tb = Register[ADDR_TRIS_B];

				Latch_RB = (byte)(wert & 0xFF);

				for (uint i = 0; i < 8; i++)
				{
					if (!GetBit(tb, i)) Register[ADDR_PORT_B] = SetBit(Register[ADDR_PORT_B], i, GetBit(Latch_RB, i));
				}
				return;
			}

			if (index == ADDR_TRIS_A)
			{
				var ta = (byte)(wert & 0xFF);

				for (uint i = 0; i < 8; i++)
				{
					if (!GetBit(ta, i)) Register[ADDR_PORT_A] = SetBit(Register[ADDR_PORT_A], i, GetBit(Latch_RA, i));
				}
			}

			if (index == ADDR_TRIS_B)
			{
				var tb = (byte)(wert & 0xFF);

				for (uint i = 0; i < 8; i++)
				{
					if (!GetBit(tb, i)) Register[ADDR_PORT_B] = SetBit(Register[ADDR_PORT_B], i, GetBit(Latch_RB, i));
				}
			}

			Register[index] = (byte)(wert & 0xFF);
		}

		private void Interrupt_RB(byte alt, byte neu)
		{
			// RB0/INT

			if (GetBit(alt, 0) != GetBit(neu, 0))
			{
				if (GetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_INTEDG) && GetBit(neu, 0)) // aufsteigende flanke
				{
					RB0Interrupt();
				}
				else if (!GetRegisterOhneBank(ADDR_OPTION, OPTION_BIT_INTEDG) && !GetBit(neu, 0)) // Fallende flanke
				{
					RB0Interrupt();
				}
			}

			// PORT RB

			if (GetBit(alt, 4) != GetBit(neu, 4) && GetRegisterOhneBank(ADDR_TRIS_B, 4))
			{
				PortBInterrupt();
			}
			else if (GetBit(alt, 5) != GetBit(neu, 5) && GetRegisterOhneBank(ADDR_TRIS_B, 5))
			{
				PortBInterrupt();
			}
			else if (GetBit(alt, 6) != GetBit(neu, 6) && GetRegisterOhneBank(ADDR_TRIS_B, 6))
			{
				PortBInterrupt();
			}
			else if (GetBit(alt, 7) != GetBit(neu, 7) && GetRegisterOhneBank(ADDR_TRIS_B, 7))
			{
				PortBInterrupt();
			}
		}

		public byte GetRegisterOhneBank(uint index)
		{
			if (index == ADDR_UNIMPL_A) return 0;
			if (index == ADDR_UNIMPL_B) return 0;

			// register die nur einmal auf bank1 + 2 existieren
			if (index == ADDR_PCL + 0x80) index -= 0x80;
			if (index == ADDR_STATUS + 0x80) index -= 0x80;
			if (index == ADDR_FSR + 0x80) index -= 0x80;
			if (index == ADDR_PCLATH + 0x80) index -= 0x80;
			if (index == ADDR_INTCON + 0x80) index -= 0x80;

			if (index == ADDR_PCL) // PC
			{
				return (byte) (PCCounter & 0xFF);
			}

			if (index == ADDR_INDF) // indirekte adresierung
			{
				if (Register[ADDR_FSR] % 0x80 == 0) return 0;
				return Register[Register[ADDR_FSR]];
			}

			return Register[index];
		}

		private byte GetRegister(uint index)
		{
			if ((Register[ADDR_STATUS] & STATUS_BIT_RP0) == STATUS_BIT_RP0)
			{
				return GetRegisterOhneBank(0x80 + index);
			}
			else
			{
				return GetRegisterOhneBank(index);
			}
		}

		private void SetRegister(uint index, uint wert)
		{
			if (GetBit(Register[ADDR_STATUS], STATUS_BIT_RP0))
			{
				SetRegisterOhneBank(0x80 + index, wert);
			}
			else
			{
				SetRegisterOhneBank(index, wert);
			}
		}

		public void SetRegisterOhneBank(uint index, uint bit, bool wert)
		{
			SetRegisterOhneBank(index, SetBit(GetRegisterOhneBank(index), bit, wert));
		}

		private void SetRegister(uint index, uint bit, bool wert)
		{
			SetRegister(index, SetBit(GetRegister(index), bit, wert));
		}

		public bool GetRegisterOhneBank(uint index, uint bit)
		{
			return GetBit(GetRegisterOhneBank(index), bit);
		}

		public static bool AdditionDigitCarry(byte a, byte b)
		{
			a &= 0x0F;
			b &= 0x0F;

			return (a + b) > 0x0F;
		}

		public static bool SubtractionDigitCarry(byte a, byte b)
		{
			int xa = a & 0x0F;
			int xb = ((~b) & 0x0F);

			return (xa + xb) > 0x0F;
		}

		public static bool GetBit(byte val, uint pos)
		{
			return (val & SHL(1, pos)) != 0;
		}

		public static uint SHL(uint val, uint steps)
		{
			return (uint)((val) << ((int)steps));
		}

		public static uint SHR(uint val, uint steps)
		{
			return (uint)((val) >> ((int)steps));
		}

		public static byte SetBit(byte val, uint pos, bool bit)
		{
			return (byte)(bit ? (val | SHL(1, pos)) : (val & ~SHL(1, pos)));
		}

		public void Reset()
		{
			Register = new byte[0x100];

			Latch_RA = 0;
			Latch_RB = 0;

			Register_W = 0;
			Stack.Clear();

			SetRegisterOhneBank(ADDR_PCL, 0x00);
			SetRegisterOhneBank(ADDR_STATUS, 0x18);
			SetRegisterOhneBank(ADDR_PCLATH, 0x00);
			SetRegisterOhneBank(ADDR_INTCON, 0x00);

			SetRegisterOhneBank(ADDR_OPTION, 0xFF);
			SetRegisterOhneBank(ADDR_TRIS_A, 0x1F);
			SetRegisterOhneBank(ADDR_TRIS_B, 0xFF);

			SetRegisterOhneBank(ADDR_EECON1, 0x00);
			SetRegisterOhneBank(ADDR_EECON2, 0x00);

			PCCounter = 0;
		}

		public void TimerInterrupt()
		{
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE)) return;
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_T0IE)) return;

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_T0IF, true);

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE, false);

			Stack.Push((uint)PCCounter);
			PCCounter = (int) INTERRUPT_SERVICE_ADDRESS;
		}

		public void RB0Interrupt()
		{
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE)) return;
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_INTE)) return;

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_INTF, true);

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE, false);

			Stack.Push((uint)PCCounter);
			PCCounter = (int)INTERRUPT_SERVICE_ADDRESS;
		}

		public void PortBInterrupt()
		{
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE)) return;
			if (!GetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_RBIE)) return;

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_RBIF, true);

			SetRegisterOhneBank(ADDR_INTCON, INTCON_BIT_GIE, false);

			Stack.Push((uint)PCCounter);
			PCCounter = (int)INTERRUPT_SERVICE_ADDRESS;
		}
	}
}
