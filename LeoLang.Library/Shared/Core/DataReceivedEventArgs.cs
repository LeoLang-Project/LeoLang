﻿using System;

namespace LeoLang.Library.Shared.Core
{
    internal class DataReceivedEventArgs : EventArgs
    {
        public byte[] Data { get; set; }

        internal DataReceivedEventArgs(byte[] data, long length)
        {
            if (data != null)
            {
                Data = new byte[length];
                Array.Copy(data, Data, length);
            }
        }
    }
}