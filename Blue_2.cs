using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2:Blue
    {
        /*Дано текст. Необходимо удалить из текста все слова, которые содержат
заданную последовательность букв (например, однокоренные слова), а также
убрать лишние пробелы, которые могут образоваться после удаления слов
(например, двойные пробелы или пробелы в начале и конце строки).
Последовательность букв передается второй строкой при создании экземпляра
класса. Свойство Output должно возвращать итоговую строку после
выполнения всех удалений, а метод ToString() должен возвращать
сокращенный текст.*/
        private string _output;
        private string _needtoremovecombo;
        public string Output => _output;
        public Blue_2(string input, string combo) : base(input)
        {
            _needtoremovecombo = combo;
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_needtoremovecombo)) return;
            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string ftext = "";//измененный текст
            _output = Input;
            foreach (string word in words)
            {
                if (!word.Contains(_needtoremovecombo)) continue;
                if (word.Contains(".") || word.Contains(",") || word.Contains(":") || word.Contains(";"))//знаки после слова без пробела, которые нужно сохранить
                {
                    char[] lettersinword = new char[word.Length];
                    
                    for (int i = 0; i < word.Length; i++) 
                    { 
                        lettersinword[i] = word[i]; //string неизменяемый поэтому слово со знаком сохр как массив
                    }
                    if (word.Contains("\""))//кавычки сохраняются
                    { 
                        ftext = _output.Replace(word + " ", "\"\"" + lettersinword[lettersinword.Length - 1] + " "); 
                    }
                    else 
                    { 
                        ftext = _output.Replace(" " + word, ""+lettersinword[lettersinword.Length - 1]);
                    }
                    _output = ftext;
                }
                else
                {
                    ftext = _output.Replace(word + " ", "");
                    _output = ftext;
                }
            }

        }
        
        public override string ToString()
        {
            return _output;
        }
    }
}
