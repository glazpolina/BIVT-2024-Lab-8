using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4:Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input) 
        { 
            _output = 0;
        }
        /*Текст содержит слова и целые числа произвольного порядка. Найти сумму
включенных в текст чисел. Свойство Output должно возвращать целое число, а
метод ToString() должен возвращать это число в качество строки. Запрещено
использовать методы конвертации (например: TryParse).*/
       
        public override void Review()
        {
            int sum = 0;
            int faced_number = 0;
            
            if (string.IsNullOrEmpty(Input)) return;
            foreach (char entity in Input)
            {
                if (char.IsDigit(entity))
                {
                    faced_number = faced_number * 10 + (entity - '0'); // каждая новая цифра становится низшим порядком всего предыдущего
                }
                else 
                {
                    sum += faced_number; //следующий символ не цифра поэтому конец числа
                    faced_number = 0;
                }
            }
            sum += faced_number;//если вся строка закончилась на этом числе, то оно не вошло в сумму
            _output = sum;
        }
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
