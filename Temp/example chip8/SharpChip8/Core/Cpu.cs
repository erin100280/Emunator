using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpChip8.Core
{
	public enum Chip8Mode
	{
		Chip8, HightResolution, SuperChip8, MegaChip8	
	}
	
    // byte : 8 bit non signé
    // ushort : 16 bit non signé
    // uint : 32 bit non signé
    public class Cpu
    {
        #if NETFX_CORE
        public static int OperationPerSecond = 16;
#else
        public static int OperationPerSecond = 4; // 250 Hz soit 1/250 = 4ms
#endif
        public static int WaitTime = 14; // temps d'attente entre chaque mise à jour

        private byte [] _memory; // Mémoire interne
        private byte[] _V; // Registres V1 à V16
        private ushort _I; // Stock une adresse mémoire / Déssinateur
        private Stack<ushort> _stack; // Gère les sauts mémoire
        private byte _stackSize; // Nombre de saut déjà réalisé dans la mémoire
        private byte _delayTimer; // Compteur synchro
        private byte _soundTimer; // Compteur son
        private ushort _Pc; // Pointer Counter : Parcours de la mémoire
		private ushort [] _hp48; // Registres HP48 pour le support du Super Chip8
		
		private Chip8Mode _mode;
        private ushort _currentOpcode;
        private bool _waitForInput; // Utilisé par FX0A afin d'attendre une entrée clavier

        private Opcode [] _opcode; // Table des Opcodes
        private Input _input;
		
		private Chip8 _chip8;

        public bool _running;

        public event EventHandler<EventArgs> CpuRunning = null;
        public event EventHandler<EventArgs> PlaySound = null;

        private void EmulationRunning(EventArgs arg)
        {
            if (CpuRunning != null)
                CpuRunning(this, arg);
        }

        private void SoundReadyToPlay(EventArgs arg)
        {
            if (PlaySound != null)
                PlaySound(this, arg);
        }

        public byte[] Memory
        {
            get { return _memory; }
            set { _memory = value; }
        }

        public byte[] V
        {
            get { return _V; }
            protected set { _V = value; }
        }

        public ushort I
        {
            get { return _I; }
            protected set { _I = value; }
        }

        public byte JumpCount
        {
            get { return _stackSize; }
            protected set { if (_stackSize < 16) _stackSize = value; }
        }

        public ushort PC
        {
            get { return _Pc; }
            protected set 
            {
                if (value >= SharpChip8.Core.Memory.MemorySize)
                {
                    _Pc = SharpChip8.Core.Memory.StartAddress;
                }
                else
                    _Pc = value;
            }
        }
		
		public ushort [] HP48
		{
			get { return _hp48; }
			set { _hp48 = value; }
		}

        public Stack<ushort> Stack
        {
            get { return _stack; }
            set { _stack = value; }
        }

        public ushort CurrentStackState
        {
            get 
            {
                if (_stack.Count > 0)
                    return _stack.Last();
                return 0;
            }
        }

        public int CountStack
        {
            get { return _stack.Count; }
        }

        public byte DelayTimer
        {
            get { return _delayTimer; }
            set { _delayTimer = value; }
        }

        public byte SoundTimer
        {
            get { return _soundTimer; }
            set { _soundTimer = value; }
        }

        public Screen Screen
        {
            get { return _chip8.Screen; }
            //set { _chip8.Screen = value; }
        }
		
		public Input Input
		{
			get { return _input; }
			set { _input = value; }
		}

        public bool Running
        {
            get { return _running; }
            set { _running = value; }
        }

        public bool WaitForInput
        {
            get { return _waitForInput; }
            set { _waitForInput = value; }
        }

        public ushort CurrentOpcode
        {
            get { return _currentOpcode; }
            protected set { _currentOpcode = value; }
        }
		
		public Chip8Mode Mode
		{
			get { return _mode; }
			set { _mode = value; }
		}

        public void SetByteOnMemory(ushort position, byte b)
        {
            _memory[position] = b;
        }

        public Cpu(Chip8 chip8)
        {
            this._memory = new byte[SharpChip8.Core.Memory.MemorySize];
            this._V = new byte[16];
            this._I = 0;
            this._stack = new Stack<ushort>(16);
            this._stackSize = 0;
            this._delayTimer = 0;
            this._soundTimer = 0;
            this._Pc = SharpChip8.Core.Memory.StartAddress;
			this._hp48 = new ushort[8];
            this._opcode = Opcode.GetOpcodeTable();
            this._input = new Input();
			this._chip8 = chip8;
            this._running = false; // Le processeur n'est pas démarré à la création
            this._waitForInput = false;
            this._currentOpcode = 0x0;
            ResetMemory();
            Reset();
        }

        public void ResetMemory()
        {
            for (int i = 0; i < SharpChip8.Core.Memory.MemorySize; i++)
                _memory[i] = 0;
            LoadFont();
        }

        public void Reset()
        {
            for (int i = 0; i < 16; i++)
                _V[i] = 0;
            
            _I = 0;
            
            _stack.Clear();

            _Pc = SharpChip8.Core.Memory.StartAddress;
            
            _stackSize = 0;
            _delayTimer = 0;
            _soundTimer = 0;

            _waitForInput = false;
            _currentOpcode = 0x0;
			
			_input.Reset();
        }

        public void CountDown()
        {
            if (_delayTimer > 0)
                _delayTimer--;

            if (_soundTimer > 0)
                _soundTimer--;

            if (_soundTimer == 1)
            {
                _soundTimer = 0;
                SoundReadyToPlay(EventArgs.Empty);
            }
        }

        public ushort GetOpcode()
        {
            if (_running)
            {
                ushort opcode = (ushort)((_memory[_Pc] << 8) + _memory[_Pc + 1]);
                return opcode;
            }
            else
                return 0;
        }

        /// <summary>
        /// Determine l'action associée à l'opcode
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns>Indice du tableau d'opcode correspondant à cet opcode</returns>
        public byte GetAction(ushort opcode)
        {
            byte action = 0;
            ushort result = 0;

            for (action = 0; action < Opcode.OpcodeCount; action++)
            {
                result = (ushort)(_opcode[action].Mask & opcode);

                if (result == _opcode[action].Id)
                    break;
            }
            return action;
        }

        public void InterpretOpcode(ushort opcode)
        {
            _currentOpcode = opcode;

            byte opcode_b4 = GetAction(opcode);
            byte opcode_b3 = (byte)((opcode & 0x0F00) >> 8);
            byte opcode_b2 = (byte)((opcode & 0x00F0) >> 4);
            byte opcode_b1 = (byte)(opcode & 0x000F);

            switch (opcode_b4)
            {
                case 0:         // 00E0 : Effacer l'écran
                    this.Screen.Clear();
                    break;
                case 1:         // 00EE : Retourne à partir d'un sous programme
                    if (JumpCount > 0)
                    {
                        PC = _stack.Pop();
                        JumpCount--;
                    }
                    break;
                case 2:         // 0NNN
                    break;
                case 3:         // 1NNN : Effectue un saut à l'adresse NNN
                    PC = (ushort)((opcode_b3 << 8) + (opcode_b2 << 4) + opcode_b1);
                    PC -= 2;    // Car on incrémente PC de 2 à la fin du switch
                    break;
                case 4:         // 2NNN : Execute un sous programme à l'adresse NNN
                    _stack.Push(PC);
                    JumpCount++;
                    // On fait le saut et on met le PC à jour
                    PC = (ushort)((opcode_b3 << 8) + (opcode_b2 << 4) + opcode_b1);
                    PC -= 2;    
                    break;
                case 5:         // 3XNN : Saute l'instruction suivante si VX == NN
                    if (V[opcode_b3] == (opcode_b2 << 4 + opcode_b1))
                    {
                        PC += 2;
                    }
                    break;  
                case 6:         // 4XNN : Saute l'instruction suivante si VX != NN
                    if (V[opcode_b3] != ((opcode_b2 << 4) + opcode_b1))
                    {
                        PC += 2;
                    }
                    break;
                case 7:         // 5XY0 : Saute à l'instruction suivante si VX == VY
                    if (V[opcode_b3] == V[opcode_b2])
                    {
                        PC += 2;
                    }
                    break;
                case 8:         // 6XNN : Définie VX à NN
                    V[opcode_b3] = (byte)((opcode_b2 << 4) + opcode_b1);
                    break;
                case 9:         // 7XNN : Ajoute NN à VX
                    V[opcode_b3] += (byte)((opcode_b2 << 4) + opcode_b1);
                    break;
                case 10:        // 8XY0 : Définie VX à la valeur VY
                    V[opcode_b3] = V[opcode_b2];
                    break;
                case 11:        // 8XY1 :Définie VX à VX OR VY
                    V[opcode_b3] = (byte)(V[opcode_b3] | V[opcode_b2]);
                    break;
                case 12:        // 8XY2 : Définie VX à VX AND VY
                    V[opcode_b3] = (byte)(V[opcode_b3] & V[opcode_b2]);
                    break;
                case 13:        // 8XY3 : Définie VX à VX XOR VY
                    V[opcode_b3] = (byte)(V[opcode_b3] ^ V[opcode_b2]);
                    break;
                case 14:        // 8XY4 : VY += VX, si le résultat est > 0xff VF = 0x1 sinon VF = 0x0
                    if ((V[opcode_b3] + V[opcode_b2]) > 0xFF)
                        V[0xF] = 1;
                    else
                        V[0xF] = 0;
                    V[opcode_b3] += V[opcode_b2];
                    break;
                case 15:        // 8XY5 : VY = VY - VX, si le resultat est négatif VF = 0x1 sinon VF = 0x0
                    int subVY = (V[opcode_b3] - V[opcode_b2]);
                    if (subVY < 0)
                    {
                        V[0xF] = 1;
                        subVY *= -1;
                    }
                    else
                        V[0xF] = 0;

                    byte nb3 = (byte)subVY;
                    V[opcode_b3] = nb3;
                    break;
                case 16:        // 8XY6 : Décale VX à droite de 1 bit, VF = valeur du bit de poids faible de VX avant décalage
                    V[0xF] = (byte)(V[opcode_b3] & 0x01);
                    V[opcode_b3] = (byte)(V[opcode_b3] >> 1);
                    break;
                case 17:        // 8XY7 : VX = VY - VX, si le résultat est < 0 VF = 0x1 sinon VF = 0x0
                    int subVX = V[opcode_b2] - V[opcode_b3];
                    if (subVX < 0)
                        V[0xF] = 1;
                    else
                        V[0xF] = 0;
                    byte sb3 = (byte)subVX;
                    V[opcode_b3] = sb3;
                    break;
                case 18:        // 8XYE : Décale VX à gauche de 1 bit, VF = valeur du bit de poids fort de VX avant décalage
                    V[0xF] = (byte)(V[opcode_b3] >> 7);
                    V[opcode_b3] = (byte)(V[opcode_b3] << 1);
                    break;
                case 19:        // 9XY0 : Saute l'instruction suivante si VX et VY ne sont pas égaux
                    if (V[opcode_b3] != V[opcode_b2])
                        PC += 2;
                    break;
                case 20:        // ANNN : Affecte NNN à I
                    I = (ushort)((opcode_b3 << 8) + (opcode_b2 << 4) + opcode_b1);
                    break;      
                case 21:        // BNNN : Passe à l'adresse NNN + V0
                    PC = (ushort)((opcode_b3 << 8 + opcode_b2 << 4 + opcode_b1) + V[0x0]);
                    PC -= 2;
                    break;
                case 22:        // CXNN : Définit VX à un nombre aléatoire < NN
                    Random rand = new Random();
                    V[opcode_b3] = (byte)(rand.Next(0, 255) % ((opcode_b2 << 4) + (opcode_b1) + 1));
                    break;
                case 23:        // DXYN : Dessine un sprite à l'écran
                    this.Screen.Draw(opcode_b1, opcode_b2, opcode_b3);
                    break;
                case 24:        // EX9E : Saute l'instruction suivante si la touche représentée par VX == 0x1
                    if (_input.Keys[opcode_b3] == 0x1)
                        PC += 2;
                    break;
                case 25:        // EXA1 : Saute l'instruction suivante si la touche représentée par VX == 0x0
                    if (_input.Keys[opcode_b3] == 0x0)
                        PC += 2;
                    break;
                case 26:        // FX07 : Définie VX = Tempo Jeu
                    V[opcode_b3] = _delayTimer;
                    break;
                case 27:        // FX0A : Attend l'appuie sur une touche et le retour est stocké dans VX
                    _waitForInput = true;
                    break;
                case 28:        // FX15 : Définie la tempo du jeu à VX
                    _delayTimer = V[opcode_b3];
                    break;
                case 29:        // FX18 : Définie la tempo du son à VX
                    _soundTimer = V[opcode_b3];
                    break;
                case 30:        // FX1E : I = VX + I, VF = 1 si il y a un depassement de mémoire sinon VF = 0
                    if (I > 0xFFF) // 4095(10)
                        V[0xF] = 1;
                    else
                        V[0xF] = 0;
                    I = (ushort)(V[opcode_b3] + I);
                    break;
                case 31:        // FX29 : Défnit I à l'emplacement du caractère sotcké dans VX
                    I = (ushort)(5 * opcode_b3);
                    break;
                case 32:        // FX33 :  Stocke dans la mémoire le code décimal représentant VX
                    _memory[I] = (byte)(V[opcode_b3] / 100); // Chiffre des centaines
                    _memory[I + 1] = (byte)((V[opcode_b3] % 100) / 10); // Chiffre des dizaines (TODO : à vérifier)
                    _memory[I + 2] = (byte)((V[opcode_b3] % 100) % 10);
                    break;
                case 33:        // FX55 : Stock le contenu des registres V0 jusqu'à VX en mémoire à partir de l'adresse I
                    for (byte i = 0; i <= opcode_b3; i++)
                        _memory[I + i] = V[i]; // Fixé le debordement mémoire
                    break;
                case 34:        // FX65 : Rempli les registres V0 à VX avec le contenu de la mémoire à partir de I
                    for (byte i = 0; i <= opcode_b3; i++)
                        V[i] = _memory[I + i];
                    break;
				// Opcode Super Chip-8
				case 35:
					break;
				case 36:
					break;
				case 37:
					break;
				case 38:
					break;
				case 39:	// 00FE : Désactiver le mode écran étendu
                    Screen.UpdateScreenResolution(Chip8Mode.Chip8);
					break;
				case 40:	// 00FF : Activer le mode écran étendu
                    Screen.UpdateScreenResolution(Chip8Mode.SuperChip8);
					break;
				case 41:
					break;
				case 42:
					break;
				case 43:
					break;
				// Opcode Mega Chip-8
				case 44:	// 0010 : Désactiver le mode écran MegaChip-8
                    Screen.UpdateScreenResolution(Chip8Mode.Chip8);
					break;
				case 45:	// 0011 : Activer le mode écran MegaChip-8
                    Screen.UpdateScreenResolution(Chip8Mode.MegaChip8);
					break;
				case 46:
					break;
				case 47:
					break;
				case 48:
					break;
				case 49:
					break;
				case 50:
					break;
				case 51:
					break;
				case 52:
					break;
				case 53:
					break;
				case 54:
					break;
                default:
                    break;
            }
            PC += 2;

            // On notifie les abonnés que le processeur travail
            if (!_waitForInput)
                EmulationRunning(EventArgs.Empty);
        }

        public void LoadFont()
        {
            for (int i = 0; i < Fontset.Length; i++)
                _memory[i] = Fontset[i];
        }

        private static byte[] Fontset = {
			0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
			0x20, 0x60, 0x20, 0x20, 0x70, // 1
			0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
			0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
			0x90, 0x90, 0xF0, 0x10, 0x10, // 4
			0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
			0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
			0xF0, 0x10, 0x20, 0x40, 0x40, // 7
			0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
			0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
			0xF0, 0x90, 0xF0, 0x90, 0x90, // A
			0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
			0xF0, 0x80, 0x80, 0x80, 0xF0, // C
			0xE0, 0x90, 0x90, 0x90, 0xE0, // D
			0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
			0xF0, 0x80, 0xF0, 0x80, 0x80  // F	
		};
    }
}
