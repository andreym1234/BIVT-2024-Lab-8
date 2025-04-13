using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;
        public Blue_1(string input) : base(input)
        {
            _output = new string[0];
        }
        public override void Review()
        {
            string[] allwords = Input.Split(' ');
            int count = 0;
            foreach (string word in allwords)
            {
                if (word != null) count++;
            }
            string[] words = new string[count];
            int count1 = 0;
            foreach (string word in allwords)
            {
                if (word != null)
                {
                    words[count1++] = word;
                }
            }
            string[] stroka = new string[words.Length];
            int count2 = 0;
            string currentstroka = "";
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (currentstroka.Length == 0) currentstroka = word;
                else if ((currentstroka.Length + 1 + word.Length) <= 50) currentstroka += " " + word;
                else
                {
                    stroka[count2++] = currentstroka;
                    currentstroka = word;
                }
            }
            if (currentstroka.Length > 0)
            {
                stroka[count2++] = currentstroka;
            }
            _output = new string[stroka.Length];
            for (int i = 0; i < stroka.Length; i++)
            {
                _output[i] = stroka[i];
            }
        }
        public override string ToString()
        {
            return string.Join("\n", _output);
        }
    }
}
