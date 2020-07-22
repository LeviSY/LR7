using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rc4
{
    class Program
    {
        static void Main(string[] args)
        {

            int key = 0;
            Console.Write("Введите ключ: ");
            string query = Console.ReadLine();
            int.TryParse(query, out key);
            byte[] bytekey = BitConverter.GetBytes(key);

            Console.Write("Входной файл: ");
            string infile = Console.ReadLine();

            Console.Write("Результирующий файл: ");
            string outfile = Console.ReadLine();

            var ob = new RC4();
            while (1 == 1)
            {
                switch (menu())
                {
                    case (1):
                        ob.text = ob.ReadByteArrayFromFile(infile);
                        ob.init(bytekey);
                        ob.WriteByteArrayToFile(ob.code(), outfile);
                        Console.WriteLine("Сообщение зашифровано!");
                        Console.Read();
                        break;

                    case (2):
                        ob.text = ob.ReadByteArrayFromFile(outfile);
                        ob.init(bytekey);
                        ob.WriteByteArrayToFile(ob.code(), infile);
                        Console.WriteLine("Сообщение расшифровано!");
                        Console.Read();
                        break;

                    case (3):
                        key = 0;
                        Console.Write("Введите ключ: ");
                        query = Console.ReadLine();
                        int.TryParse(query, out key);
                        bytekey = BitConverter.GetBytes(key);
                        Console.Write("Входной файл: ");
                        infile = Console.ReadLine();
                        Console.Write("Результирующий файл: ");
                        outfile = Console.ReadLine();
                        break;

                    case (4):
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Такого действия нет!");
                        break;
                }
            }
        }

        private static int menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine(" 1. Шифровать");
            Console.WriteLine(" 2. Дешифровать");
            Console.WriteLine(" 3. Ввести новые данные");
            Console.WriteLine(" 4. Выход");
            Console.Write(" \n\n>>> ");
            string action = Console.ReadLine();
            int act = 0;
            int.TryParse(action, out act);
            Console.Clear();
            return act;
        }
    }
}