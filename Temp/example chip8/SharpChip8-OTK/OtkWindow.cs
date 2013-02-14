using System;
using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SharpChip8;
using SharpChip8.Core;

namespace SharpChip8CLI
{
	public class OtkWindow : GameWindow
	{
		private Chip8 _chip8;
		
		private int _blackPixelColor;
        private int _whitePixelColor;
		
		public OtkWindow(Chip8 chip8)
		{
			this.Title = String.Format("{0} {1} Codename {2}", Chip8.emulator, Chip8.version, Chip8.codename);
			this.WindowBorder = WindowBorder.Fixed;
			this.ClientSize = new Size(Screen.InternalWidth * Pixel.PixelDim, Screen.InternalHeight * Pixel.PixelDim);
			
			_chip8 = chip8;
			_chip8.Cpu.PlaySound += Handle_chip8CpuPlaySound;
			
			this.Resize += OnResize;
			this.Keyboard.KeyUp += OnKeyUp;
			this.Keyboard.KeyDown += OnKeyDown;

            _blackPixelColor = 0x000000;
            _whitePixelColor = 0xFFFFFF;
		}

		void Handle_chip8CpuPlaySound (object sender, EventArgs e)
		{
			Console.Beep(); // Todo :  remplacer ça par autre chose
		}
		
		private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, this.Width, this.Height, 0, -1, 1);
            GL.Viewport(0, 0, this.Width, this.Height);
        }
		
		private void DrawPixel(Pixel pixel)
        {
            if (pixel.Color == PixelColor.Black)
                GL.Color3(Color.FromArgb(_blackPixelColor));
            else
                GL.Color3(Color.FromArgb(_whitePixelColor));

            GL.Vertex2(pixel.X, pixel.Y);
            GL.Vertex2(pixel.X, pixel.Y + Pixel.PixelDim);
            GL.Vertex2(pixel.X + Pixel.PixelDim, pixel.Y + Pixel.PixelDim);
            GL.Vertex2(pixel.X + Pixel.PixelDim, pixel.Y);
        }
		
		// Vider l'écran
        private void Clear()
        {
            _chip8.Screen.Clear();
            GL.ClearColor(Color.Black);
        }
		
		/// <summary>
        /// Mise à jour (lecture Opcode et traitement) dans la classe renderer
        /// Affichage graphique via OpenGL
        /// </summary>
        private void UpdateAndDraw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Begin(BeginMode.Quads);

            _chip8.Update();

            // Todo : ajouter un flag qui indiquera QUAND déssiner
            for (int i = 0; i < SharpChip8.Core.Screen.InternalWidth; i++)
                for (int j = 0; j < SharpChip8.Core.Screen.InternalHeight; j++)
                    DrawPixel(_chip8.Screen.Pixels[i][j]);
            

            GL.End();
            GL.Flush();
			SwapBuffers();
			
			Thread.Sleep(Cpu.WaitTime);
        }
		
		protected void OnLoad(object sender, EventArgs e)
		{
			SetupViewport();
			GL.ClearColor(Color.Black);
		}
		
		protected void OnResize(object sender, EventArgs e)
		{
			SetupViewport();
		}
		
		protected override void OnRenderFrame(FrameEventArgs e)
		{			
			base.OnRenderFrame(e);
			if (_chip8.Cpu.Running && !_chip8.Cpu.WaitForInput)
            {
                UpdateAndDraw();
                Thread.Sleep(SharpChip8.Core.Cpu.WaitTime);
            }
		}
		
		protected void OnKeyUp(object sender, KeyboardKeyEventArgs e)
		{
			switch (e.Key)
			{
			    case Key.Number0: _chip8.Cpu.Input.Keys[0] = 0x0; break;
			    case Key.Number1: _chip8.Cpu.Input.Keys[1] = 0x0; break;
			    case Key.Number2: _chip8.Cpu.Input.Keys[2] = 0x0; break;
			    case Key.Number3: _chip8.Cpu.Input.Keys[3] = 0x0; break;
			    case Key.Number4: _chip8.Cpu.Input.Keys[4] = 0x0; break;
			    case Key.Number5: _chip8.Cpu.Input.Keys[5] = 0x0; break;
			    case Key.Number6: _chip8.Cpu.Input.Keys[6] = 0x0; break;
			    case Key.Number7: _chip8.Cpu.Input.Keys[7] = 0x0; break;
			    case Key.Number8: _chip8.Cpu.Input.Keys[8] = 0x0; break;
			    case Key.Number9: _chip8.Cpu.Input.Keys[9] = 0x0; break;
			    case Key.A: _chip8.Cpu.Input.Keys[10] = 0x0; break;
			    case Key.Z: _chip8.Cpu.Input.Keys[11] = 0x0; break;
			    case Key.E: _chip8.Cpu.Input.Keys[12] = 0x0; break;
			    case Key.Q: _chip8.Cpu.Input.Keys[13] = 0x0; break;
			    case Key.S: _chip8.Cpu.Input.Keys[14] = 0x0; break;
			    case Key.D: _chip8.Cpu.Input.Keys[15] = 0x0; break;
			    default:
			        break;
			}
		}
		
		protected void OnKeyDown(object sender, KeyboardKeyEventArgs e)
		{
			if (e.Key == Key.Escape)
				this.Exit();
			
			byte opcode_b3 = (byte)((_chip8.Cpu.CurrentOpcode & 0x0F00) >> 8);

            switch (e.Key)
            {
				case Key.Number0: 
                    _chip8.Cpu.Input.Keys[0] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x0;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number1: 
                    _chip8.Cpu.Input.Keys[1] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x1;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number2:
                    _chip8.Cpu.Input.Keys[2] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x2;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number3: 
                    _chip8.Cpu.Input.Keys[3] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x3;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number4: 
                    _chip8.Cpu.Input.Keys[4] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x4;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number5:
                    _chip8.Cpu.Input.Keys[5] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x5;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number6: 
                    _chip8.Cpu.Input.Keys[6] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x6;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number7: 
                    _chip8.Cpu.Input.Keys[7] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x7;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number8: 
                    _chip8.Cpu.Input.Keys[8] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x8;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Number9: 
                    _chip8.Cpu.Input.Keys[9] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x9;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
				case Key.A:      
                    _chip8.Cpu.Input.Keys[10] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xA;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Z:       
                    _chip8.Cpu.Input.Keys[11] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xB;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.E:      
                    _chip8.Cpu.Input.Keys[12] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xC;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.Q:      
                    _chip8.Cpu.Input.Keys[13] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xD;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.S:       
                    _chip8.Cpu.Input.Keys[14] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xE;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Key.D:       
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

