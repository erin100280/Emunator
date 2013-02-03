using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SharpChip8;
using WinformFrontend.Frontend;

namespace WinformFrontend
{
    static class WinformProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Chip8 chip8 = new Chip8();
            Application.Run(new WinformOTKRenderer(chip8));
        }
    }
}
