using System;
using System.IO;
using SharpChip8;

namespace SharpChip8CLI
{
	public class OtkMain
	{
		[STAThread]
		public static void Main(string [] args)
		{
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    Chip8 chip8 = new Chip8();
                    chip8.Reset();
                    chip8.LoadRomFromFile(args[0]);
                    chip8.Start();

                    OtkWindow emu = new OtkWindow(chip8);
                    emu.Run();
                }
                else
                    Console.WriteLine("Le Fichier n'existe pas");
            }
            else
                Console.WriteLine("Usage: SharpChip8.exe nomRom.ch8");
		}
	}
}
