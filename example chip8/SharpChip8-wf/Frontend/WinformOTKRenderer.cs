using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using SharpChip8;
using SharpChip8.Core;

namespace WinformFrontend.Frontend
{
    public partial class WinformOTKRenderer : Form
    {
        private bool _loaded = false;
		private byte _lastPressedKey;

        private Chip8 _chip8;

        private string _romfile = String.Empty;

        private int _blackPixelColor;
        private int _whitePixelColor;

		public byte LastPressedKey
		{
			get { return _lastPressedKey; }
			set { _lastPressedKey = value; }
		}

        public WinformOTKRenderer(Chip8 chip8)
        {
            InitializeComponent();

            this.Text = String.Format("{0} {1} Codename {2}", Chip8.emulator, Chip8.version, Chip8.codename);

            _chip8 = chip8;
            _chip8.Reset();

            SetBlackAndWhiteColorPixel();

            _chip8.Cpu.PlaySound += new EventHandler<EventArgs>(Chip8PlaySound_Event);
        }

        private void SetupViewport()
        {
            int width = otkGLControl.Width;
            int height = otkGLControl.Height;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, width, height);
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

        /// <summary>
        /// Mise à jour (lecture Opcode et traitement) dans la classe renderer
        /// Affichage graphique via OpenGL
        /// </summary>
        private void UpdateAndDraw()
        {
            if (!_loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Begin(BeginMode.Quads);

            _chip8.Update();

            // Todo : ajouter un flag qui indiquera QUAND déssiner
            if (_chip8.Cpu.Running)
            {
                for (int i = 0; i < SharpChip8.Core.Screen.InternalWidth; i++)
                    for (int j = 0; j < SharpChip8.Core.Screen.InternalHeight; j++)
                        DrawPixel(_chip8.Screen.Pixels[i][j]);
            }

            GL.End();
            otkGLControl.SwapBuffers();
        }

        // Vider l'écran
        private void Clear()
        {
            _chip8.Screen.Clear();
            GL.ClearColor(Color.Black);
            otkGLControl.Invalidate();
        }

        #region Evénements WindowsForm
        private void Chip8PlaySound_Event(object sender, EventArgs e)
        {
            Console.Beep();
        }
        #endregion

        #region Evénements OpenTK
        private void otkGLControl_Load(object sender, EventArgs e)
        {
            _loaded = true;
            GL.ClearColor(Color.Black);
            SetupViewport();

            Application.Idle += new EventHandler(Application_Idle);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (otkGLControl.IsIdle && _chip8.Cpu.Running && !_chip8.Cpu.WaitForInput)
            {
                UpdateAndDraw();
                Thread.Sleep(SharpChip8.Core.Cpu.WaitTime);
            }
        }

        private void otkGLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            SetupViewport();
            otkGLControl.Invalidate();
        }

        private void otkGLControl_Paint(object sender, PaintEventArgs e)
        {
            UpdateAndDraw();
        }

        private void otkGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && _chip8.Cpu.Running)
            {
                DialogResult result = MessageBox.Show("Voulez vous stopper l'émulation en cours ?", "Stopper l'émulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    StopEmulation();
                }
            }

            byte opcode_b3 = (byte)((_chip8.Cpu.CurrentOpcode & 0x0F00) >> 8);

            switch (e.KeyCode)
            {
                case Keys.NumPad0: 
                    _chip8.Cpu.Input.Keys[0] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x0;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad1: 
                    _chip8.Cpu.Input.Keys[1] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x1;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad2:
                    _chip8.Cpu.Input.Keys[2] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x2;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad3: 
                    _chip8.Cpu.Input.Keys[3] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x3;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad4: 
                    _chip8.Cpu.Input.Keys[4] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x4;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad5:
                    _chip8.Cpu.Input.Keys[5] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x5;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad6: 
                    _chip8.Cpu.Input.Keys[6] = 0x1;
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x6;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad7: 
                    _chip8.Cpu.Input.Keys[7] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x7;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad8: 
                    _chip8.Cpu.Input.Keys[8] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x8;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.NumPad9: 
                    _chip8.Cpu.Input.Keys[9] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0x9;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.A:      
                    _chip8.Cpu.Input.Keys[10] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xA;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.Z:       
                    _chip8.Cpu.Input.Keys[11] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xB;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.E:      
                    _chip8.Cpu.Input.Keys[12] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xC;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.Q:      
                    _chip8.Cpu.Input.Keys[13] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xD;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.S:       
                    _chip8.Cpu.Input.Keys[14] = 0x1; 
                    if (_chip8.Cpu.WaitForInput)
                    {
                        _chip8.Cpu.V[opcode_b3] = 0xE;
                        _chip8.Cpu.WaitForInput = false;
                    }
                    break;
                case Keys.D:       
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

            this.otkGLControl.Invalidate();
        }

        private void otkGLControl_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0: _chip8.Cpu.Input.Keys[0] = 0x0; break;
                case Keys.NumPad1: _chip8.Cpu.Input.Keys[1] = 0x0; break;
                case Keys.NumPad2: _chip8.Cpu.Input.Keys[2] = 0x0; break;
                case Keys.NumPad3: _chip8.Cpu.Input.Keys[3] = 0x0; break;
                case Keys.NumPad4: _chip8.Cpu.Input.Keys[4] = 0x0; break;
                case Keys.NumPad5: _chip8.Cpu.Input.Keys[5] = 0x0; break;
                case Keys.NumPad6: _chip8.Cpu.Input.Keys[6] = 0x0; break;
                case Keys.NumPad7: _chip8.Cpu.Input.Keys[7] = 0x0; break;
                case Keys.NumPad8: _chip8.Cpu.Input.Keys[8] = 0x0; break;
                case Keys.NumPad9: _chip8.Cpu.Input.Keys[9] = 0x0; break;
                case Keys.A: _chip8.Cpu.Input.Keys[10] = 0x0; break;
                case Keys.Z: _chip8.Cpu.Input.Keys[11] = 0x0; break;
                case Keys.E: _chip8.Cpu.Input.Keys[12] = 0x0; break;
                case Keys.Q: _chip8.Cpu.Input.Keys[13] = 0x0; break;
                case Keys.S: _chip8.Cpu.Input.Keys[14] = 0x0; break;
                case Keys.D: _chip8.Cpu.Input.Keys[15] = 0x0; break;
                default:
                    break;
            }
            this.otkGLControl.Invalidate();
        }
        #endregion

        #region Evenements Menu
        // Menu Fichier
        // --- Ouvrir
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRom();
            StartEmulation();
        }

        // --- Fermer
        private void closeItemMenu_Click(object sender, EventArgs e)
        {
            CloseRom();
        }

        // --- Quitter
        private void quitItemMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Menu Emulation
        // --- Démarrer l'émulation
        private void startItemMenu_Click(object sender, EventArgs e)
        {
            StartEmulation();
        }

        // --- Stopper l'émulation
        private void stopItemMenu_Click(object sender, EventArgs e)
        {
            StopEmulation();
        }

        // --- Reset
        private void resetItemMenu_Click(object sender, EventArgs e)
        {
            CloseRom();
            StartEmulation();
        }

        // --- Controleur virtuel
        private void itemMenuInputController_Click(object sender, EventArgs e)
        {
            InputController inputController = new InputController(_chip8);
            inputController.Show();
        }

        // Menu Configuration
        // - Menu Affichage
        // --- Changer la résolution
        private void itemMenuCRNative_Click(object sender, EventArgs e)
        {
            this.itemMenuCRNative.Checked = true;
            this.itemMenuCRDouble.Checked = false;
            this.itemMenuCRTriple.Checked = false;
            this.itemMenuCRPerso.Checked = false;
            ChangeResolution(8, 8);
        }

        private void itemMenuCRDouble_Click(object sender, EventArgs e)
        {
            this.itemMenuCRNative.Checked = false;
            this.itemMenuCRDouble.Checked = true;
            this.itemMenuCRTriple.Checked = false;
            this.itemMenuCRPerso.Checked = false;
            ChangeResolution(16, 16);
        }

        private void itemMenuCRTriple_Click(object sender, EventArgs e)
        {
            this.itemMenuCRNative.Checked = false;
            this.itemMenuCRDouble.Checked = false;
            this.itemMenuCRTriple.Checked = true;
            this.itemMenuCRPerso.Checked = false;
            ChangeResolution(24, 24);
        }

        private void itemMenuCRPerso_Click(object sender, EventArgs e)
        {

        }

        // --- Changer les couleurs de pixel
        private void itemMenuColorBW_Click(object sender, EventArgs e)
        {
            itemMenuColorBW.Checked = true;
            itemMenuColorLB.Checked = false;
            itemMenuColorLO.Checked = false;
            itemMenuColorLG.Checked = false;
            SetBlackAndWhiteColorPixel();
        }

        private void itemMenuColorLB_Click(object sender, EventArgs e)
        {
            itemMenuColorBW.Checked = false;
            itemMenuColorLB.Checked = true;
            itemMenuColorLO.Checked = false;
            itemMenuColorLG.Checked = false;
            SetBlueLevelColorPixel();
        }

        private void itemMenuColorLO_Click(object sender, EventArgs e)
        {
            itemMenuColorBW.Checked = false;
            itemMenuColorLB.Checked = false;
            itemMenuColorLO.Checked = true;
            itemMenuColorLG.Checked = false;
            SetOrangeLevelColorPixel();
        }

        private void itemMenuColorLG_Click(object sender, EventArgs e)
        {
            itemMenuColorBW.Checked = false;
            itemMenuColorLB.Checked = false;
            itemMenuColorLO.Checked = false;
            itemMenuColorLG.Checked = true;
            SetGreenLevelColorPixel();
        }

        // --- Changement de la vitesse du CPU
        private void itemMenuVNormal_Click(object sender, EventArgs e)
        {
            this.itemMenuVNormal.Checked = true;
            this.itemMenuVSpeed.Checked = false;
            this.itemMenuVMoreSpeed.Checked = false;
            SharpChip8.Core.Cpu.OperationPerSecond = 4;
        }

        private void itemMenuVSpeed_Click(object sender, EventArgs e)
        {
            this.itemMenuVNormal.Checked = false;
            this.itemMenuVSpeed.Checked = true;
            this.itemMenuVMoreSpeed.Checked = false;
            SharpChip8.Core.Cpu.OperationPerSecond = 8;
        }

        private void itemMenuVMoreSpeed_Click(object sender, EventArgs e)
        {
            this.itemMenuVNormal.Checked = false;
            this.itemMenuVSpeed.Checked = false;
            this.itemMenuVMoreSpeed.Checked = true;
            SharpChip8.Core.Cpu.OperationPerSecond = 12;
        }

        // --- Activer / Désactiver le son
        private void itemMenuSActive_Click(object sender, EventArgs e)
        {
            this.itemMenuSActive.Checked = false;
            this.itemMenuSDesactive.Checked = true;
            _chip8.ActiveSound = true;
        }

        private void itemMenuSDesactive_Click(object sender, EventArgs e)
        {
            this.itemMenuSActive.Checked = false;
            this.itemMenuSDesactive.Checked = true;
            _chip8.ActiveSound = false;
        }

        // Menu Debug
        // --- Lancer le déboggeur
        private void debugerItemMenu_Click(object sender, EventArgs e)
        {
            Debugger.DebugWindow debugger = new Debugger.DebugWindow(_chip8);
            debugger.Show();
        }
        
        // --- Lancer le désassembleur
        private void disasmItemMenu_Click(object sender, EventArgs e)
        {  
            Debugger.DisassemblerWindow dasmWindow = new Debugger.DisassemblerWindow(_chip8);
            dasmWindow.Show();
        }

        // Menu Aide
        // --- A propos
        private void aboutItemMenu_Click(object sender, EventArgs e)
        {
            string text = String.Format("SharpChip-8 est un emulateur/interpreteur de Chip-8.\nIl est Open Source et gratuit, pour plus d'information consultez la licence (GPLv2).\n\nYannick Comte");
            MessageBox.Show(text, "A propos de SharpChip-8", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Aide
        private void helpItemMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pour utiliser SharpChip-8 vous devez dans un premier temps charger un fichier Rom (.ch8 et ck8) via le menu Fichier/Ouvrir. L'émulation démarrera automatiquement après ça.", "Aide SharpChip-8", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Methodes génériques utilisées par le menu, la barre d'outils et les touches
        private void StopEmulation()
        {
            _chip8.Cpu.Running = false;
            _chip8.Cpu.Reset();
            this.labelEtatEmu.Text = "Emulation arrêtée";
            Clear();
        }

        private void StartEmulation()
        {
            if (_romfile != String.Empty)
            {
                _chip8.LoadRomFromFile(_romfile);
                _chip8.Cpu.Running = true;
                this.labelEtatEmu.Text = "Emulation démarrée";
            }
        }

        private void OpenRom()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Charger une rom";
            openFileDialog.DefaultExt = "ch8";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Rom Chip-8 (*.ch8)|*.ch8|Rom Chip-8 (*.c8k)|*.c8k|Tous les fichiers (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            string defaultSearchPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (System.IO.Directory.Exists(defaultSearchPath + System.IO.Path.DirectorySeparatorChar + "Roms"))
                defaultSearchPath += System.IO.Path.DirectorySeparatorChar + "Roms";

            openFileDialog.InitialDirectory = defaultSearchPath;

            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _romfile = openFileDialog.FileName;
                this.labelEtatEmu.Text = String.Format("Rom {0} chargée", openFileDialog.SafeFileName);
            }

            if (_chip8.Cpu.Running)
                StopEmulation();
        }

        private void CloseRom()
        {
            StopEmulation();
            _romfile = String.Empty;
            this.labelEtatEmu.Text = "Pas de rom chargée";
        }

        private void ChangeResolution(int pixelWidth, int pixelHeight)
        {
            this.Size = new Size((SharpChip8.Core.Screen.InternalWidth * pixelWidth) + 10, (SharpChip8.Core.Screen.InternalHeight * pixelHeight) + 84);
            this.otkGLControl.Size = new Size(64 * pixelWidth, 32 * pixelHeight);
            SetupViewport();
            Pixel.PixelDim = pixelWidth;
            _chip8.Screen.Reset();
        }
        #endregion

        #region Définie la couleurs des pixel
        private void SetBlackAndWhiteColorPixel()
        {
            _blackPixelColor = 0x000000;
            _whitePixelColor = 0xFFFFFF;
        }

        private void SetBlueLevelColorPixel()
        {
            _blackPixelColor = 0x3575FF;
            _whitePixelColor = 0xAAB6FF;
        }

        private void SetGreenLevelColorPixel()
        {
            _blackPixelColor = 0x05A72A;
            _whitePixelColor = 0x93FF99;
        }

        private void SetOrangeLevelColorPixel()
        {
            _blackPixelColor = 0xFF5E14;
            _whitePixelColor = 0xFFC9B2;
        }
        #endregion
    }
}
