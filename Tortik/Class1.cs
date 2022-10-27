using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortik
{
    class Tort
    {
        public string MainName;
        public string[] Menu_of_MainMenu;
        public int[] number_of_operation;

        public Tort(string mainName, string[] menu_of_operation, int[] Number_of_operation)
        {
            MainName = mainName;
            Menu_of_MainMenu = menu_of_operation;
            number_of_operation = Number_of_operation;
        }
        public  static OutInfo DopMenu( Tort tort)
        {
            
            {
                ;
                Console.WriteLine("Меню ||| Вы можете нажать Escape для выхода обратно в меню");
                Console.WriteLine();

                int row = Console.CursorTop;
                int col = Console.CursorLeft;
                int index = 0;
                while (true)
                {
                    DrawMenu(tort.Menu_of_MainMenu, row, col, index);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (index < tort.Menu_of_MainMenu.Length - 1)
                                index++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (index > 0)
                                index--;
                            break;
                        case ConsoleKey.Escape:
                            {
                                Console.WriteLine("Выбран выход из приложения");
                                return new OutInfo(null, 0);
                            }
                        case ConsoleKey.Enter:
                            switch (index)
                            {
                                default:
                                    return new OutInfo (tort.Menu_of_MainMenu[index],tort.number_of_operation[index]);
                                    
                            }
                           
                    }
                }
            }

            static void DrawMenu(string[] items, int row, int col, int index)
            {
                Console.SetCursorPosition(col, row);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
