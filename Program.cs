using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

/*Написать программу вывода на экран количества сотрудников, чей возраст кратен 3. Тип данных – коллекция.
В текстовом файле записана информация о людях (фамилия, имя, отчество, возраст, вес через пробел). 
Иванов Сергей Николаевич 21 64
Петров Игорь Юрьевич 45 88
Семёнов Михаил Алексеевич 20 70
Пиманов Александр Дмитриевич 53 101
Предусмотреть тестовые ситуации, проект выгрузить в репрозиторий*/

namespace z2_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file.txt");
            List<People> pl = new List<People>();
            try
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] st = str.Split(' ');
                    pl.Add(new People() { fio = st[0] + st[1] + st[2], vozr = Convert.ToInt32(st[3]), ves = st[4] });
                }
            }
            catch { Console.WriteLine("неверные данные"); }
            foreach (People item in pl.Where(d => d.vozr % 3 == 0))
                Console.WriteLine($"{item.fio} {item.vozr} {item.ves}");
        }
    }
}
