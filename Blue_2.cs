using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _set;
        public string Output => _output;
        public string Set => _set;
        public Blue_2(string input, string set) : base(input)
        {
            _set = set;
            _output = "";
        }
        public override void Review()
        {
            string[] allwords = Input.Split(' ');
            int count = 0;
            foreach (string word in allwords)
            {
                if (word == null) continue;
                if (!(word.Length >= 3 && word.Substring(1,2) == _set && _set.Length == 2))
                {
                    if (_output.Length > 0)
                    {
                        _output += " ";
                    }
                    _output += word;
                }
                else if (word.Length >= 3 && word.Substring(1, 2) == _set && _set.Length == 2 && !char.IsLetterOrDigit(word[word.Length - 1])) _output += word[word.Length - 1];
            }
            _output = _output.Trim();
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
