using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Урок_35_4хмерный_массив
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Алгоритм поиска книг («О дивный новый мир», «Приключения Тома Сойера» и «CLR via C#») по названию.
              Поиск в 4х мерном массиве строк (образно представленным как 3 комнаты, в которых по 3 стелажа, каждый 
              стелаж по 10 полок, каждая полка по 10 книг)
              Запрос от пользователя - название книги , возврат  - значения о расположении книги */
            {
                // Инициализируем 4х мерный массив строками, также вносим название 3-х книг.
                string[,,,] array_dataofbooks = new string[3, 3, 10, 10];
                byte r = 0;
                for (byte w = 0; w < array_dataofbooks.GetLength(0); w++)
                    for (r = 0; r < array_dataofbooks.GetLength(1); r++)
                    {
                        for (byte i = 0; i < array_dataofbooks.GetLength(2); i++)
                            for (byte j = 0; j < array_dataofbooks.GetLength(3); j++)
                            {
                                array_dataofbooks[w, r, i, j] = $"{r + i + j}";
            
                            }
                    
                    array_dataofbooks[0, 0, 7, 2] = "О дивный новый мир";
                    array_dataofbooks[1 ,1, 1, 8] = "Приключения Тома Сойера";
                    array_dataofbooks[2, 2, 4, 9] = "CLR via C#";
                }

                // Выполняем поиск заданного пользователем условия(названия книги).
                Console.Write("Введите название книги для поиска: ");
                string nameofbook = Console.ReadLine();
                bool indicator = false;
                for (byte w = 0; w < array_dataofbooks.GetLength(0); w++)
                for (r = 0; r < array_dataofbooks.GetLength(1); r++)
                {
                    for (byte i = 0; i < array_dataofbooks.GetLength(2); i++)
                        for (byte j = 0; j < array_dataofbooks.GetLength(3); j++)
                        {
                            string book = array_dataofbooks[w, r, i, j];
                            if (book == nameofbook)
                            {
                                byte rack = r; byte shelf = i; byte place = j; byte room = w;

                                // Вывод значения с прибавлением единицы (+1) для начала нумерации стелажей, полок и мест с единицы, но не с нуля.
                                Console.WriteLine($"Ваша книга находится в {room+1}-й комнате, на {rack + 1}-м стелаже, " +
                                    $"{shelf + 1}-я полка, {place + 1}-е место.");
                                indicator = true;
                                break;
                            }

                        }


                }

                if (indicator == false)
                    Console.WriteLine("Извините, нет такой книги в нашей библиотеке!");
                Console.ReadKey();
            }
        }
    }
}
