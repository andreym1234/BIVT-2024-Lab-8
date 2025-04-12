using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char letter, double percent)[] _output;
        public (char letter, double percent)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = new (char, double)[0];
        }
        public override void Review()
        {
            char[] punctuation = {' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] allwords = Input.Split(punctuation);
            int totalwords = 0;
            int[] letters = new int[1104];
            bool[] whichletters = new bool[1104];
            for (int i = 0; i < allwords.Length; i++)
            {
                string word = allwords[i].ToLower();

                if (string.IsNullOrWhiteSpace(word)) continue;

                char firstletter = word[0];
                if (char.IsLetter(firstletter))
                {
                    int index = (int)firstletter;
                    letters[index]++;
                    whichletters[index] = true;
                    totalwords++;
                    
                }
            }

            (char letter, double percent)[] temp = new (char letter, double percent)[totalwords];
            int count = 0;

            for (int i = 0; i < 1104; i++)
            {
                if (whichletters[i])
                {
                    char letter = (char)i;
                    double percent = Math.Round(letters[i] * 100.0 / totalwords, 4);
                    temp[count++] = (letter, percent);
                }
            }

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (temp[j].percent < temp[j + 1].percent ||
                        temp[j].percent == temp[j + 1].percent && temp[j].letter > temp[j + 1].letter)
                    {
                        (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                    }
                }
            }

            _output = new (char letter, double percent)[count];
            for (int i = 0; i < count; i++)
            {
                _output[i] = temp[i];
            }
        }
        public string ToString()
        {
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].letter} - {_output[i].percent:f4}";
                if (i != _output.Length - 1) result += "\n";
            }
            return result;
        }
    }
}
