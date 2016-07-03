﻿using System;
using System.Collections.Generic;
using System.IO;
using ReadAndCoder;

namespace Signature
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int sizePart;
                
                if (!IsCorrectParam(args, out sizePart))
                {
                    throw new ArgumentException();
                }
                string path = args[0];

                // создаём объект кодировщика
                Coder coder = new Coder(path, sizePart);
                
                // распечатываем сигнатуры
                foreach (KeyValuePair<long, string> pair in coder.GetHashStringSignature())
                {
                    Console.WriteLine(pair.Key + ":\t" + pair.Value);
                }

                Console.Write("Successful. ");
            }
            // ошибки неверно введенных данных
            catch (ArgumentException)
            {
                Console.WriteLine("Illegal argiments!\n" +
                                  "Used: Signature.exe File_Name Size_of_part_in_Bytes\n");
            }
            // ошибки ввода-вывода
            catch (IOException e)
            {
                Console.WriteLine("I/O exception: " +
                                  e.Message + "\n" +
                                  e.StackTrace);
            }
            // другие ошибки
            catch (Exception e)
            {
                Console.WriteLine("Unknow exception: " +
                                  e.Message + "\n" +
                                  e.StackTrace);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        

        // проверяем корректность введенных данных
        private static bool IsCorrectParam(string[] args, out int sizePart)
        {
            if (args.Length == 2 &&                         // ровно два аргумента
                File.Exists(args[0]) &&                     // файл существует
                Int32.TryParse(args[1], out sizePart) &&    // размер части указан корректным числом
                sizePart > 0)                               // размер части положительный
            {
                // если всё верно, то выходим, возвращая true
                return true;
            }

            // иначе, чтобы не ругался компилятор, присваиваем значение
            sizePart = 0;
            // и выходим, возвращая false
            return false;
        }
    }
}
