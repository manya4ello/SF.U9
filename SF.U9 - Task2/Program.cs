using System;

namespace unit9
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> names = new List<string>() { "Галкин", "Палкин", "Малкин", "Чалкин", "Залкинд " };
            Console.WriteLine("У нас есть следующие товарищи:");
            ShowNames(names);

            NumberReader numberReader = new NumberReader(); 
            numberReader.NumberReaderEvent += SortTyper;
            int i=0;
            while (i==0)
            {
                try
                {
                    numberReader.Read(names);
                    ShowNames(names);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
                catch (Exception ex) when (ex.Message == "Выход")
                {
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void SortTyper(int number, List<string> names)
        {
            Console.WriteLine("Введено число {0}",number);
            
            switch(number)
                {
                case 0:throw new Exception("Выход");
                case 1: names.Sort(); break;
                case 2: names.Sort(); names.Reverse(); break;
            }
            

        }
      
        static void ShowNames(List<string> names)
        {
            foreach (string name in names)  
                Console.WriteLine(name);
        }
    }
    class NumberReader
    {
        public delegate void NumberReaderDelegate(int number, List<string> names);
        public event NumberReaderDelegate NumberReaderEvent;

        public void Read(List<string> names)
        {
            Console.Write("Для сортировки имен ведите 1 (А-Я) или 2 (Я-А): ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 0 && number != 1 && number != 2) throw new Exception("Число должно быть 1 или 2");

            NumberEntered(number, names);
        }

        protected virtual void NumberEntered (int number, List<string> names)
        {
            NumberReaderEvent?.Invoke(number, names);
        }
    }
}