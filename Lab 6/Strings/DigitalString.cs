using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class DigitalString : MyString
    {
        public DigitalString(char[] str) : base(str)
        {
            for(int i = 0; i < length; i++)
            {
                if (!char.IsDigit(this.str[i])){
                    throw new Exception("it is impossible to create a digital string('{this.str[i]}')");
                }
            }
        }

        public override MyString SubtractSymbol(char symbol = '5')
        {
            return base.SubtractSymbol(symbol);
        }

    }
}
