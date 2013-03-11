using System;

namespace SharpChip8.Core
{
    public class Screen
    {
        public const int InternalWidth = 64;
        public const int InternalHeight = 32;
		public const int HightWidth = 64;
		public const int HightHeight = 64;
		public const int SuperWidth = 128;
		public const int SuperHeight = 64;
		public const int MegaWidth = 256;
		public const int MegaHeight = 192;
		

        public const int WaitTime = 14; // Pour le rafraichissement
        public const int FramePerSecond = 60;

        private int _width;
        private int _height;

        private Pixel[][] _pixels;

        private Cpu _cpu;

        public int Width
        {
            get { return _width; }
            protected set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            protected set { _height = value; }
        }

        public Pixel[][] Pixels
        {
            get { return _pixels; }
            set { _pixels = value; }
        }

        public Cpu Cpu
        {
            get { return _cpu; }
        }

        public Screen(Chip8 chip8)
        {
            _cpu = chip8.Cpu;
            _width = InternalWidth * Pixel.PixelWidth;
            _height = InternalHeight * Pixel.PixelHeight;

            _pixels = new Pixel[InternalWidth][];
            for (int i = 0; i < InternalWidth; i++)
                _pixels[i] = new Pixel[InternalHeight];
        }

        public void Reset()
        {
            for (int i = 0; i < InternalWidth; i++)
                for (int j = 0; j < InternalHeight; j++)
                    _pixels[i][j] = new Pixel(i * Pixel.PixelWidth, j * Pixel.PixelHeight, Pixel.PixelWidth, Pixel.PixelHeight, PixelColor.Black);
        }

        public void Draw(ushort opcode_b1, ushort opcode_b2, ushort opcode_b3)
        {
            byte code = 0;
            int x = 0;
            int y = 0;
            byte offset = 0;

            _cpu.V[0xF] = 0; // Retenue

            for (byte k = 0; k < opcode_b1; k++)
            {
                if (_cpu.I + k <= 0xFFF)
                    code = _cpu.Memory[_cpu.I + k]; // Code correspondant à la ligne à dessiner
                y = (_cpu.V[opcode_b2] + k) % Screen.InternalHeight;
                offset = 7;
                for (byte j = 0; j < 8; j++)
                {
                    x = (_cpu.V[opcode_b3] + j) % Screen.InternalWidth;

                    if (((code) & (0x1 << offset)) != 0)
                    {
                        if (_pixels[x][y].Color == PixelColor.White)
                        {
                            _pixels[x][y].Color = PixelColor.Black;
                            _cpu.V[0xF] = 1; // On retien 1 car deux pixels se chevauchent
                        }
                        else
                            _pixels[x][y].Color = PixelColor.White;
                    }
                    offset--;
                }
            }
        }
		
		public void UpdateScreenResolution(Chip8Mode mode)
		{	
			switch(mode)
			{
				case Chip8Mode.Chip8:
					break;
				case Chip8Mode.HightResolution:
					break;
				case Chip8Mode.SuperChip8:
					break;
				case Chip8Mode.MegaChip8:
					break;
				default:
					break;
			}
		}
		
		// SuperChip-8 : 00CN : Scrolling de l'écran vers la bas de n lignes
		public void ScrollDown(int lines)
		{
			
		}
		
		// SuperChip-8 : 00FB : Scrolling de l'écran vers la droite de 4 pixels
		public void ScrollRight()
		{
			
		}
		
		// SuperChip-8 : 00FC : Scrolling de l'écran vers la gauche de 4 pixels
		public void ScrollLeft()
		{
			
		}
		
		// MegaChip-8 : 00BN : Scrolling de l'écran vers la haut de n lignes
		public void ScrollUp(int lines)
		{
			
		}
		
        public void Clear()
        {
            for (int i = 0; i < InternalWidth; i++)
                for (int j = 0; j < InternalHeight; j++)
                    _pixels[i][j].Color = PixelColor.Black;
        }
    }
}
