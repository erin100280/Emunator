using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpChip8;

namespace WinformFrontend.Frontend
{
    public partial class InputController : Form
    {
        private Chip8 _chip8;

        public InputController(Chip8 chip8)
        {
            InitializeComponent();

            _chip8 = chip8;

            foreach (Button b in flowLayoutPanel1.Controls)
            {
                b.Click += new EventHandler(b_Click);
                b.MouseUp += new MouseEventHandler(b_MouseUp);
            }
        }

        void b_MouseUp(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;

            string temp = b.Name.Split(new string[] { "bt" }, StringSplitOptions.RemoveEmptyEntries)[0];

            switch (int.Parse(temp))
            {
                case 0x0: _chip8.Cpu.Input.Keys[0] = 0x0;
                    break;
                case 0x1:
                    _chip8.Cpu.Input.Keys[1] = 0x0;
                    break;
                case 0x2:
                    _chip8.Cpu.Input.Keys[2] = 0x0;
                    break;
                case 0x3:
                    _chip8.Cpu.Input.Keys[3] = 0x0;
                    break;
                case 0x4:
                    _chip8.Cpu.Input.Keys[4] = 0x0;
                    break;
                case 0x5:
                    _chip8.Cpu.Input.Keys[5] = 0x0;
                    break;
                case 0x6:
                    _chip8.Cpu.Input.Keys[6] = 0x0;
                    break;
                case 0x7:
                    _chip8.Cpu.Input.Keys[7] = 0x0;
                    break;
                case 0x8:
                    _chip8.Cpu.Input.Keys[8] = 0x0;
                    break;
                case 0x9:
                    _chip8.Cpu.Input.Keys[9] = 0x0;
                    break;
                case 0xA:
                    _chip8.Cpu.Input.Keys[10] = 0x0;
                    break;
                case 0xB:
                    _chip8.Cpu.Input.Keys[11] = 0x0;
                    break;
                case 0xC:
                    _chip8.Cpu.Input.Keys[12] = 0x0;
                    break;
                case 0xD:
                    _chip8.Cpu.Input.Keys[13] = 0x0;
                    break;
                case 0xE:
                    _chip8.Cpu.Input.Keys[14] = 0x0;
                    break;
                case 0xF:
                    _chip8.Cpu.Input.Keys[15] = 0x0;
                    break;
                default:
                    break;
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            byte opcode_b3 = (byte)((_chip8.Cpu.CurrentOpcode & 0x0F00) >> 8);

            Button b = sender as Button;
            string temp = b.Name.Split(new string[] { "bt" }, StringSplitOptions.RemoveEmptyEntries)[0];

            switch (int.Parse(temp))
            {
                case 0x0:
                    _chip8.Cpu.Input.Keys[0] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x0;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x1:
                    _chip8.Cpu.Input.Keys[1] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x1;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x2:
                    _chip8.Cpu.Input.Keys[2] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x2;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x3:
                    _chip8.Cpu.Input.Keys[3] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x3;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x4:
                    _chip8.Cpu.Input.Keys[4] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x4;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x5:
                    _chip8.Cpu.Input.Keys[5] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x5;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x6:
                    _chip8.Cpu.Input.Keys[6] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x6;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x7:
                    _chip8.Cpu.Input.Keys[7] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x7;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x8:
                    _chip8.Cpu.Input.Keys[8] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x8;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0x9:
                    _chip8.Cpu.Input.Keys[9] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x9;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xA:
                    _chip8.Cpu.Input.Keys[10] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xA;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xB:
                    _chip8.Cpu.Input.Keys[11] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xB;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xC:
                    _chip8.Cpu.Input.Keys[12] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xC;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xD:
                    _chip8.Cpu.Input.Keys[13] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xD;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xE:
                    _chip8.Cpu.Input.Keys[14] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xE;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case 0xF:
                    _chip8.Cpu.Input.Keys[15] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xF;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
