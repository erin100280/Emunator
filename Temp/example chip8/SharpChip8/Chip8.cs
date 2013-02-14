using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if NETFX_CORE
using Windows.Storage;
using Windows.Storage.Streams;
#else
using System.IO;
#endif

using SharpChip8.Core;

namespace SharpChip8
{
    public class Chip8
    {
        public const string emulator = "SharpChip-8";
        public const string version = "0.6";
        public const string codename = "Raider";

        private Cpu _cpu;
        private Screen _screen;
		private bool _activeSound;
		
        public Screen Screen
        {
            get { return _screen; }
        }

        public Cpu Cpu
        {
            get { return _cpu; }
        }
		
		public bool ActiveSound
		{
			get { return _activeSound; }
			set { _activeSound = value; }
		}

        public Chip8()
        {
            _cpu = new Cpu(this);
            _screen = new Screen(this);
        }
		
		public void Start()
		{
			_cpu.Running = true;
		}
		
		public void Stop()
		{
			_cpu.Running = false;	
		}

        public void Reset()
        {
            _cpu.ResetMemory();
            _cpu.Reset();
            _cpu.Input.Reset();
            _screen.Reset();
        }
		
		public void Update()
		{
			if (_cpu.Running && !_cpu.WaitForInput)
			{
	            for (int instructionCounter = 0; instructionCounter < Cpu.OperationPerSecond; instructionCounter++)
	            {
	                ushort opcode = _cpu.GetOpcode();
	                _cpu.InterpretOpcode(opcode);
	            }
                _cpu.CountDown();
			}
		}

#if NETFX_CORE
        public async void LoadRomFromFile(StorageFile file)
        {
            IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);
            IInputStream inputStream = readStream.GetInputStreamAt(0);
            DataReader dataReader = new DataReader(inputStream);

            uint nbBytesLoaded = await dataReader.LoadAsync((uint)readStream.Size);
            int length = (int)nbBytesLoaded;

            ushort position = 0;
            byte[] romBin = new byte[length];

            while (position < length)
            {
                romBin[position] = dataReader.ReadByte();
                position += sizeof(byte);
            }

            LoadRomInMemory(romBin);
        }
#else
        public void LoadRomFromFile(string romfile)
        {
            if (File.Exists(romfile))
            {
                using (BinaryReader b = new BinaryReader(File.Open(romfile, FileMode.Open)))
                {
                    ushort position = 0;
                    int length = (int)b.BaseStream.Length;

                    byte[] romBin = new byte[length];

                    while (position < length)
                    {
                        romBin[position] = b.ReadByte();
                        position += sizeof(byte);
                    }

                    // Tester la taille de la rom

                    LoadRomInMemory(romBin);
                }
            }
            else
                throw new Exception("Erreur au chargement de la rom");
        }
#endif

        public void LoadRomInMemory(byte[] bin)
        {
            uint binstart = 0;
            uint binlength = (uint)bin.Length;
            uint maxlength = Memory.MemorySize;

            byte[] memory = new byte[4096];
            for (int i = 0; i < 4096; i++)
                memory[i] = 0x0;


            if (binlength > Memory.MemorySize - Memory.StartAddress)
                maxlength = Memory.MemorySize;
            else
                maxlength = Memory.StartAddress + binlength;

            for (ushort i = Memory.StartAddress; i < maxlength; i++)
            {
                memory[i] = new byte();
                memory[i] = (byte)bin[binstart];
                binstart++;
            }
            _cpu.Memory = memory;
            _cpu.LoadFont();
        }
    }
}
