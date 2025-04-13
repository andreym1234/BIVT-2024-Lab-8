using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            int currentelem = 0;
            bool endelem = true;
            foreach(char i in Input)
            {
                char elem = i;
                if (char.IsDigit(elem))
                {
                    currentelem = currentelem * 10 + (int)(elem - '0');
                    endelem = true;
                }
                else
                {
                    _output += currentelem;
                    currentelem = 0;
                    endelem = false;
                }
            }
            if (endelem) _output += currentelem;
        }
        public override string ToString()
        {
            string result = $"{_output}";
            return result;
        }
    }
}
