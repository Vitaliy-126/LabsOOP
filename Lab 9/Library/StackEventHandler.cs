using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public delegate void StackHandler(object sender, StackEventArgs args);
    public class StackEventArgs : EventArgs
    {
        public int Size { get; set; }
        public StackEventArgs(int size)
        {
            Size = size;
        }
    }
}
