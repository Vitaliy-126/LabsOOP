using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class LettersString : MyString
    {
        public LettersString(char[]str) : base(str)
        {
            for (int i = 0; i < length; i++)
            {
                if (!char.IsLetter(this.str[i]))
                {
                    throw new Exception($"it is impossible to create a letters string('{this.str[i]}')");
                }
            }
        }

        public override MyString SubtractSymbol(char symbol = 'a')
        {
            return base.SubtractSymbol(symbol);
        }

    }
}
