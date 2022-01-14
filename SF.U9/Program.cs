namespace unit9
{
    class Program
    {
        static void Main(string[] args)
        {

            Exception exception = new Exception("Мое собственное исключение");
            exception.HelpLink = "www.google.ru";

            Exception [] exceptions = new Exception [5];
            exceptions [0] = exception;
            exceptions[1] = new DivideByZeroException();
            exceptions[2] = new IndexOutOfRangeException();
            exceptions [3] = new OverflowException("Переполнение случилось");
            exceptions [4] = new ArgumentException("Непустой аргумент, передаваемый в метод, является недопустимым.");

            foreach (Exception ex in exceptions)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e) when (e.Equals(exception))
                { 
                    Console.WriteLine (e.Message);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("Делить на ноль нельзя. {0}", e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Сработало исключение. {0}", e.Message);
                }
                finally
                {
                    Console.WriteLine("___________________________________________________________");
                }
            }
            Console.ReadKey();
        }
    }
}
