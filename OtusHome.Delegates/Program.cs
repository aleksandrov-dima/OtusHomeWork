using System;
using System.Collections.Generic;
using System.IO;

namespace OtusHome.Delegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Задание №1
            FindHumanMax();

            //Задание №2
            FileSearch();
            
            //Задание #3
            FileSearchWithFileArg();
        }

        /// <summary>
        /// Вывод информации о файлах в текущем каталоге (Action)
        /// </summary>
        private static void FileSearch()
        {
            FileSearch fileSearch = new FileSearch();
            fileSearch.OnAction += fi =>
            {
                Console.WriteLine("{0}: {1}, {2}",
                    fi.Name,
                    fi.Length,
                    fi.CreationTime);
            };
            fileSearch.TraverseTree(Environment.CurrentDirectory);
        }
        
        /// <summary>
        /// Вывод информации о файлах в текущем каталоге (EventHandler)
        /// </summary>
        private static void FileSearchWithFileArg()
        {
            FileSearch fileSearch = new FileSearch();
            fileSearch.FileFound += (sender, fileArgs) =>
            {
                Console.WriteLine("{0}",
                    fileArgs.FileName);

                //Задание №4 - помечаем, что нужно прекратить дальнейший поиск
                ((FileSearch) sender).HasCancelFlag = true;
            };
            fileSearch.TraverseTree(Environment.CurrentDirectory);
        }

        /// <summary>
        /// Поиск человека по максимальному возрасту
        /// </summary>
        private static void FindHumanMax()
        {
            List<Human> humans = new List<Human>();
            humans.Add(new Human() {Name = "Dima", Birthdate = new DateTime(1990, 08, 02)});
            humans.Add(new Human() {Name = "Petr", Birthdate = new DateTime(1989, 06, 26)});
            humans.Add(new Human() {Name = "Lena", Birthdate = new DateTime(1994, 05, 04)});
            humans.Add(new Human() {Name = "Aleksey", Birthdate = new DateTime(1996, 02, 02)});

            Func<Human, float> myDelegate = GetAgeByDays;

            Human humanMax = humans.GetMax(myDelegate);

            Console.WriteLine(humanMax.ToString());
        }

        /// <summary>
        /// Возраст человека в днях
        /// </summary>
        /// <param name="human"></param>
        /// <returns></returns>
        static float GetAgeByDays(Human human)
        {
            return (float)(DateTime.Today - human.Birthdate).TotalDays;
        }
    }
}