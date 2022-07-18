using System;
using System.IO;

namespace dz6
{
    /*Создайте справочник «Сотрудники».

    Разработайте для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл.Файл должен содержать следующие данные:

    ID
    Дату и время добавления записи
    Ф.И.О.
    Возраст
    Рост
    Дату рождения
    Место рождения
    Для этого необходим ввод данных с клавиатуры.После ввода данных:

    если файла не существует, его необходимо создать;
    если файл существует, то необходимо записать данные сотрудника в конец файла.
    При запуске программы должен быть выбор:


    введём 1 — вывести данные на экран;
    введём 2 — заполнить данные и добавить новую запись в конец файла.*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("СПРАВОЧНИК СОТРУДНИКОВ");

            byte i;

            do
            {
                for (byte j = 0; j < 35; j++)
                {
                    Console.Write("=");
                }
                Console.WriteLine("\n1. Вывести данные.\n2. Внести данные.\n3. Выход.");
                i = Convert.ToByte(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        DataOutput();
                        break;
                    case 2:
                        DataInput();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Ошибка выбора");
                        break;
                }
            } while (i != 3);
        }

        static void DataOutput()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"Employees.txt"))
                {
                    string s = "";
                    if ((s = sr.ReadLine()) == null)
                    {
                        Console.WriteLine("Файл пуст. Добавить записи?");
                        Console.WriteLine("1. Да.\n2. Нет.");
                        byte i;
                        do
                        {
                            i = Convert.ToByte(Console.ReadLine());

                            switch (i)
                            {
                                case 1:
                                    sr.Close(); //////////////////////////////////////////
                                    DataInput();
                                    return;
                                case 2:
                                    break;
                                default:
                                    Console.WriteLine("Ошибка выбора");
                                    break;
                            }
                        } while (i != 2);
                    }
                    else
                    {
                        Console.WriteLine("СПИСОК СОТРУДНИКОВ");
                        string[] lines = File.ReadAllLines(@"Employees.txt");

                        foreach (var line in lines)
                        {
                            /*
                            //Через Split
                            string[] subline = line.Split("#");                            
                            foreach (string sub in subline)
                            {
                                Console.Write(sub + ' ');
                            }
                            Console.WriteLine();
                            */

                            Console.WriteLine(line.Replace('#', ' '));
                        }
                    }
                }
            }
            catch
            {
                FileCreate();
            }
        }

        static void DataInput()
        {
            using (StreamWriter sw = new StreamWriter(@"Employees.txt", true))
            {
                byte i = 1;
                do
                {
                    switch (i)
                    {
                        case 1:
                            string note = string.Empty;
                            //1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва

                            //Ф.И.О.
                            Console.WriteLine("Введите ID: ");
                            note += $"{Console.ReadLine()}#";

                            //Дату и время добавления записи
                            string now = DateTime.Now.ToShortDateString();
                            now += ' ' + DateTime.Now.ToShortTimeString();
                            note += $"{now}#";

                            //Ф.И.О.
                            Console.WriteLine("Введите ФИО: ");
                            note += $"{Console.ReadLine()}#";

                            //Возраст
                            Console.WriteLine("Введите возраст: ");
                            note += $"{Console.ReadLine()}#";

                            //Рост
                            Console.WriteLine("Введите рост: ");
                            note += $"{Console.ReadLine()}#";

                            //Дату рождения
                            Console.WriteLine("Введите дату рождения: ");
                            note += $"{Console.ReadLine()}#";

                            //Место рождения
                            Console.WriteLine("Введите место рождения: ");
                            note += $"{Console.ReadLine()}";

                            for (byte j = 0; j < 35; j++)
                            {
                                Console.Write("=");
                            }

                            Console.WriteLine($"Введенная запись:\n{note}");
                            sw.WriteLine(note);

                            Console.WriteLine("Внести следующего сотрудника?\n1. Да.\n2. Нет");
                            i = Convert.ToByte(Console.ReadLine());
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Ошибка выбора");
                            break;
                    }
                } while (i == 1);
            }
        }

        static void FileCreate()
        {
            Console.WriteLine("Файла не существует. Создать новый файл?");
            Console.WriteLine("1. Да.\n2. Нет.");
            byte i;
            do
            {
                i = Convert.ToByte(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        using (FileStream fs = File.Create(@"Employees.txt"))
                        {
                            Console.WriteLine("Файл создан.");
                        }
                        return;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Ошибка выбора");
                        break;
                }
            } while (i != 2);
        }
    }
}
