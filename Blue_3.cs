using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3:Blue
    {
        /*Определить долю (в процентах) слов, начинающихся на различные буквы.
Выписать эти буквы и доли начинающихся на них слов. Свойство Output
должно возвращать массив кортежей (символ в нижнем регистре,
вещественное число), отсортированный по убыванию доли слов. При равенстве
долей сортировать по буквы по алфавиту. Метод ToString() должен возвращать
построчно пары символа и вещественного числа, разделенных “-”.*/

        private (char, double)[] _output;
        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;
                (char, double)[] copied_output = new (char, double)[_output.Length];
                Array.Copy(_output, copied_output, _output.Length);
                return copied_output;
            }
        }
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }
            string[] words = Input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first_letters = new Dictionary <char, int> ();
            int number_of_all_words = 0;
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word) && char.IsLetter(word[0]))
                {
                    char firstletter = char.ToLower(word[0]);
                    if (first_letters.ContainsKey(firstletter)) first_letters[firstletter]++;
                    else first_letters[firstletter] = 1;
                    number_of_all_words++;
                }
            }
            if (number_of_all_words == 0)//in case there aren't any words in text
            {
                _output = null;
                return;
            }
            _output = first_letters.Select(x => (x.Key, (double) x.Value / number_of_all_words * 100)).OrderByDescending(y => y.Item2).ThenBy(y => y.Item1).ToArray();
        }
        
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].Item1} - {_output[i].Item2:f4}";
                if (i != _output.Length - 1) result += Environment.NewLine;
            }
            return result;
        }
    }
}
