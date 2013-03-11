using System;

namespace SharpChip8.Core
{
    public class Input
    {
        private byte[] _keys;

        public byte[] Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        public Input()
        {
            _keys = new byte[16]; // 16 touches

            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < 16; i++)
                _keys[i] = 0x0;
        }
    }
}
