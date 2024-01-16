namespace BrothersGame.Core
{
    internal static class BrothersGameMain
    {
        private const string IntroMessage = "Формат ввода клетки для хода - строка столбец\n" +
                                            "Пример: 3 5\n" +
                                            "После ввода размера, сгенерируется игровое поле и начнется игра.\n" +
                                            "Удачи!";
        public static void Main()
        {
            ColoredConsoleWriteLine(IntroMessage, ConsoleColor.Green);

            Console.Write("Введите размер поля: ");
            int fieldSize;
            while(!int.TryParse(Console.ReadLine(), out fieldSize) || fieldSize <= 0)
            {
                ColoredConsoleWriteLine("Вы ввели неверное значение", ConsoleColor.Red);
                Console.Write("Введите размер поля: ");
            }

            var gameField = new GameField(fieldSize);
            gameField.Shuffle();

            while (!gameField.IsSolved())
            {
                Console.Clear();
                gameField.Print();
                Console.WriteLine();

                Console.Write("строка столбец >> ");
                var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input == null ||
                    input.Length != 2 ||
                    !int.TryParse(input[0], out var row) ||
                    !int.TryParse(input[1], out var column) ||
                    row < 1 || row > fieldSize ||
                    column < 1 || column > fieldSize)
                {
                    ColoredConsoleWriteLine("Неправильный формат ввода данных", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    continue;
                }

                gameField.MakeMove(row - 1, column - 1);
            }

            Console.Clear();
            ColoredConsoleWriteLine("Ура, Вы прошли игру!", ConsoleColor.Green);
        }

        private static void ColoredConsoleWriteLine(
            string message, ConsoleColor textColor, ConsoleColor afterTextColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ForegroundColor = afterTextColor;
        }
    }
}