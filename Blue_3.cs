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
        public (char, double)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            string[] words = Input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            char[] letters = new char[128];//(в одном алфавите будет точно меньше символов)
            int[] number_of_appearances = new int[128];
            int number_of_f_letters = 0;
            int wordsintotal = 0;
            foreach (var word in words)
            {
                if (char.IsLetter(word[0]))
                {
                    char letter = char.ToLower(word[0]);
                    int index = -1;
                    for (int i = 0; i < number_of_f_letters; i++)//проверяю записана ли уже буква
                    {
                        if (letters[i] == letter)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)//буква встречалась до этого
                    {
                        number_of_appearances[index]++;
                    }
                    else//буквы не было 
                    {
                        letters[number_of_f_letters] = letter;
                        number_of_appearances[number_of_f_letters] = 1;
                        number_of_f_letters++;
                    }
                    wordsintotal++;
                }
            }

            (char, double)[] result = new (char, double)[number_of_f_letters];
            for (int i = 0; i < number_of_f_letters; i++)
            {
                result[i] = (letters[i], (double)number_of_appearances[i] / wordsintotal * 100);
            }
           
            Sort(result);
            _output = result;
        }
        private void Sort((char, double)[] result)
        {
            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i].Item2 < result[j].Item2 || (Math.Abs(result[i].Item2 - result[j].Item2) < 0.0001 && result[i].Item1 > result[j].Item1))
                    {
                        var t = result[i];
                        result[i] = result[j];
                        result[j] = t;
                    }
                }
            }
        }
    
        public override string ToString()
        {
            if (_output == null) return null;
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].Item1} - {_output[i].Item2:f4}";
                if (i != _output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }


    }
    

}
