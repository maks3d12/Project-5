
using Tortik;
namespace tortic
{
    static class Program
    {
        static void Main(string[] args)
        {
            Tort forma = new Tort("Форма", new string[4] { "Круглый", "Квадратный", "Овальный", "Ромбический" }, new int[4] { 119, 222, 516, 517 });
            Tort size = new Tort("Размер", new string[4] { "4:2", "16:9", "240:4 ", "340:500" }, new int[4] { 400, 1200, 5000, 12000 });
            Tort taste = new Tort("Вкус",new string[5] {"Клубничный","Шоколадный","Ванильный","Фисташковый","Железная начинка"}, new int[5] {1500,4000,2000,3000,5000});
            Tort numbers = new Tort("Количество коржей", new string[3] { "2 коржа", "3 коржа", "4 коржа" },new int[3] { 1000, 1500, 2200 });
            Tort glazure = new Tort("Глазурь", new string[2] { "Шоколадная", "Крысиная" }, new int[2] {400,0});
            Tort decor = new Tort("Декор", new string[3] { "Дед Мороз", "Пряничный человечек", "План тюрьмы" }, new int[3] { 500, 300, 7000 });
            Tort[] menuItems = new Tort[6] {forma,size,taste,numbers,glazure,decor};
            Console.WriteLine("Меню");
            Console.WriteLine(" -------------------------------- ");
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            int k = 0;
            string g = null;
            string g2 = null;
            int summ = 0;

       
           
            while (true)
            {

                Console.Clear();
                DrawMenu(menuItems, row, col, index); // drawning menu
                if (k > 0)
                {
                    Console.WriteLine("Общая сумма Сумма:" + Convert.ToString(summ) + "\n Ваш заказ:" + g2 ) ;
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 6:
                                Console.WriteLine("Выбран выход из приложения");
                                File.AppendAllText("C:\\Users\\Петрушка\\Desktop\\Заказы тортов\\Торты.txt", g2);
                                return;
                            default:
                                Console.Clear();
                                OutInfo outInfo =  Tort.DopMenu(menuItems[index]);
                                summ = summ + outInfo.result;
                                g = (outInfo.choose + "=" + Convert.ToString(outInfo.result) + "\t");
                                g2 = g2 + g;
                                k++;
                                break;
                        }
                        break;
                      
                }

            }
        }

        private static void DrawMenu(Tort[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i].MainName);
                Console.ResetColor();
            }
            Console.WriteLine("Выход");
            Console.WriteLine();
        }
    }
        
}