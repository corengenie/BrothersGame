namespace BrothersGame.Core
{
    internal class GameField
    {
        private readonly GameFieldCell[,] _field;
        private int FieldSize { get; set; }

        public GameField(int fieldSize)
        {
            FieldSize = fieldSize;
            _field = new GameFieldCell[fieldSize, fieldSize];

            for (var i = 0; i < FieldSize; i++)
            {
                for (var j = 0; j < FieldSize; j++)
                {
                    _field[i, j] = new GameFieldCell();
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            var rnd = new Random();
            do
            {
                for (var _ = 0; _ < Math.Pow(FieldSize, 2); _++)
                {
                    var row = rnd.Next(FieldSize);
                    var column = rnd.Next(FieldSize);
                    MakeMove(row, column);
                }
            } while (IsSolved());
        }

        public void MakeMove(int row, int column)
        {
            _field[row, column].SwitchDirection();

            for (var i = 0; i < FieldSize; i++)
            {
                _field[i, column].SwitchDirection();
                _field[row, i].SwitchDirection();
            }
        }

        public void Print()
        {
            for (var i = 0; i < FieldSize; i++)
            {
                for (var j = 0; j < FieldSize; j++)
                {
                    Console.Write($"{_field[i, j]}");
                }
                Console.WriteLine();
            }
        }

        public bool IsSolved()
        {
            var direction = _field[0, 0].Direction;
            return _field.Cast<GameFieldCell>().All(cell => cell.Direction == direction);
        }
    }
}