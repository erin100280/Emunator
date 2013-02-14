using System;

namespace SharpChip8.Core
{
    public class Opcode
    {
        public const int OpcodeCount = 55; // 35 opcodes Chip-8 + 9 Opcodes Super Chip-8 + 11 Opcodes Mega Chip-8

        public ushort Id { get; set; }
        public ushort Mask { get; set; }

        private static Opcode[] _jump;
        private static bool _init = false;

        public Opcode(ushort id, ushort mask)
        {
            Id = id;
            Mask = mask;
        }

        /// <summary>
        /// Initialisation des opcodes Chip8
        /// </summary>
        public static Opcode [] GetOpcodeTable()
        {
            if (!_init)
            {
                _jump = new Opcode[OpcodeCount];
                
                _jump[0] = new Opcode(0x00E0, 0xFFFF);    // 00E0
                _jump[1] = new Opcode(0x00EE, 0xFFFF);    // 00EE
                _jump[2] = new Opcode(0x0FFF, 0x0F00);    // 0XXX
                _jump[3] = new Opcode(0x1000, 0xF000);   // 1NNN
                _jump[4] = new Opcode(0x2000, 0xF000);   // 2NNN
                _jump[5] = new Opcode(0x3000, 0xF000);   // 3XNN
                _jump[6] = new Opcode(0x4000, 0xF000);   // 4XNN
                _jump[7] = new Opcode(0x5000, 0xF00F);   // 5XY0
                _jump[8] = new Opcode(0x6000, 0xF000);   // 6XNN
                _jump[9] = new Opcode(0x7000, 0xF000);   // 7XNN
                _jump[10] = new Opcode(0x8000, 0xF00F);  // 8XY0
                _jump[11] = new Opcode(0x8001, 0xF00F);  // 8XY1
                _jump[12] = new Opcode(0x8002, 0xF00F);  // 8XY2
                _jump[13] = new Opcode(0x8003, 0xF00F);  // 8XY3
                _jump[14] = new Opcode(0x8004, 0xF00F);  // 8XY4
                _jump[15] = new Opcode(0x8005, 0xF00F);  // 8XY5
                _jump[16] = new Opcode(0x8006, 0xF00F);  // 8XY6
                _jump[17] = new Opcode(0x8007, 0xF00F);  // 8XY7
                _jump[18] = new Opcode(0x800E, 0xF00F);  // 8XYE
                _jump[19] = new Opcode(0x9000, 0xF00F);  // 9XY0
                _jump[20] = new Opcode(0xA000, 0xF000);  // ANNN
                _jump[21] = new Opcode(0xB000, 0xF000);  // BNNN
                _jump[22] = new Opcode(0xC000, 0xF000);  // CXNN
                _jump[23] = new Opcode(0xD000, 0xF000);  // DXYN
                _jump[24] = new Opcode(0xE09E, 0xF0FF);  // EX9E
                _jump[25] = new Opcode(0xE0A1, 0xF0FF);  // EXA1
                _jump[26] = new Opcode(0xF007, 0xF0FF);  // FX07
                _jump[27] = new Opcode(0xF00A, 0xF0FF);  // FX0A
                _jump[28] = new Opcode(0xF015, 0xF0FF);  // FX15
                _jump[29] = new Opcode(0xF018, 0xF0FF);  // FX18
                _jump[30] = new Opcode(0xF01E, 0xF0FF);  // FX1E
                _jump[31] = new Opcode(0xF029, 0xF0FF);  // FX29
                _jump[32] = new Opcode(0xF033, 0xF0FF);  // FX33
                _jump[33] = new Opcode(0xF055, 0xF0FF);  // FX55
                _jump[34] = new Opcode(0xF065, 0xF0FF);  // FX65
                // Opcode Super Chip-8
                _jump[35] = new Opcode(0x00C0, 0xFFFF); // 00CN
                _jump[36] = new Opcode(0x00FB, 0xFFFF); // 00FB
                _jump[37] = new Opcode(0x00FC, 0xFFFF); // 00FC
                _jump[38] = new Opcode(0x00FD, 0xFFFF); // 00FD
                _jump[39] = new Opcode(0x00FE, 0xFFFF); // 00FE
                _jump[40] = new Opcode(0x00FF, 0xFFFF); // 00FF
				_jump[41] = new Opcode(0xF000, 0xF0FF); // FX30
                _jump[42] = new Opcode(0xF075, 0xF0FF); // FX75
                _jump[43] = new Opcode(0xF085, 0xF0FF); // FX85
                // Opcode Mega Chip-8
				_jump[44] = new Opcode(0x0010, 0xFFFF); // 0010
				_jump[45] = new Opcode(0x0011, 0xFFFF); // 0011
				_jump[46] = new Opcode(0x0100, 0xFFFF); // 01NN
				_jump[47] = new Opcode(0x0200, 0xFFFF); // 02NN
				_jump[48] = new Opcode(0x0300, 0xFFFF); // 03NN
				_jump[49] = new Opcode(0x0400, 0xFFFF); // 04NN
				_jump[50] = new Opcode(0x0500, 0xFFFF); // 05NN
				_jump[51] = new Opcode(0x06C0, 0xFFFF); // 060N
				_jump[52] = new Opcode(0x07C0, 0xFFFF); // 0700
				_jump[53] = new Opcode(0x08C0, 0xFFFF); // 080N
				_jump[54] = new Opcode(0x00B0, 0xFFFF); // 00BN
                _init = true;
            }
            return _jump;
        }
    }
}
