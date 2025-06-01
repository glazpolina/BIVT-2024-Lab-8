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
                for (int i = 0; i < copy_of_output.Length; i++)
                {
                    copy_of_output[i] = _output[i];
                }
                return copy_of_output;
            }
        }
        public Blue_1(string input):base(input)
        {
           _output = null;
        }
        /*Разбить исходный текст на строки длиной не более 50 символов. Перенос на
 новую строку осуществлять на месте пробела (слова не переносить). Свойство
 Output должно возвращать массив строк. Метод ToString() должен возвращать
 массив отформатированных строк построчно.*/
        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }
            string[] words = Input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] lines = new string[0];
            string thisline = "";
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (thisline.Length == 0) thisline = word;//beginning of a line
                else if (1 + thisline.Length + word.Length <= 50) thisline += " " + word;//adding a word if it fits&not overflowing
                else
                {
                    lines = Addline(lines, thisline);
                    thisline = word;
                }
            }
            if (thisline.Length > 0) lines = Addline(lines, thisline);//the last unadded line
            _output = lines;
        }

        private string[] Addline(string[] lines, string newline)
        {
            string[] new_array_of_lines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                new_array_of_lines[i] = lines[i];
            }
            new_array_of_lines[lines.Length] = newline;
            return new_array_of_lines;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            return string.Join(Environment.NewLine, _output);
        }
    }
}
