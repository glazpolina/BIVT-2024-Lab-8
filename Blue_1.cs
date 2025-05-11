using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1:Blue
    {
        private string[] _output;
        public string[] Output
        {
            get
            {
                if (_output == null) return null;
                string[] copy_of_output = new string[_output.Length];
                for(int i = 0; i < copy_of_output.Length; i++)
                {
                    copy_of_output[i] = _output[i];
                }
                return copy_of_output;
            }
        }
        public Blue_1(string input):base(input)
        {
            _output = new string[0];
        }
        /*Разбить исходный текст на строки длиной не более 50 символов. Перенос на
 новую строку осуществлять на месте пробела (слова не переносить). Свойство
 Output должно возвращать массив строк. Метод ToString() должен возвращать
 массив отформатированных строк построчно.*/
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            string[] array_of_lines = new string[0];
            string[] words = Input.Split(' ');
            int i = 0;
            while(i < words.Length)
            {
                string new_line = "";
                int number_of_symbols = words[i].Length;
                while (number_of_symbols <= 50)
                {
                    new_line += words[i] + " ";
                    i++;
                    
                    if (i != words.Length)
                    {
                        number_of_symbols += words[i].Length + 1;
                    }
                    else break;
                   
                }
                Add(ref array_of_lines, new_line.Substring(0, new_line.Length - 1));//последний пробел нужно удалить поэтому только часть строчки до new_line.Length - 1
            }

            _output = array_of_lines;

        }
        private static void Add(ref string[] array_of_lines, string new_line)
        {
            if (array_of_lines == null || string.IsNullOrEmpty(new_line)) return;
            string[] new_array = new string[array_of_lines.Length + 1];
            for (int i = 0; i < array_of_lines.Length; i++) 
            {
                new_array[i] = array_of_lines[i];
            }
            new_array[array_of_lines.Length] = new_line;
            array_of_lines = new_array;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            string resulttext = "";
            for (int i = 0; i < _output.Length; i++)
            {
                resulttext += _output[i];
                if (i != _output.Length - 1)
                {
                    resulttext += Environment.NewLine;
                }
            }
            return resulttext;
        }
    }
}
