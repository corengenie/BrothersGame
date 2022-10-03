namespace BrothersGame.Core
{
    internal class GameField
    {
        private GameFieldCell[,] _field;
        public int _fieldSize { get; private set; }

        public GameField(int fieldSize)
        {
            this._fieldSize = fieldSize;
            this._field = new GameFieldCell[fieldSize, fieldSize];

            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    this._field[i, j] = new GameFieldCell();
                }
            }

            this.Shuffle();
        }

        public void Shuffle()
        {
            var rnd = new Random();
            do
            {
                for (int _ = 0; _ < Math.Pow(_fieldSize, 2); _++)
                {
                    var row = rnd.Next(_fieldSize);
                    var column = rnd.Next(_fieldSize);
                    this.MakeMove(row, column);
                }
            } while (CheckIfSolved());
        }

        public void MakeMove(int row, int column)
        {
            this._field[row, column].SwitchDirection();

            for (int i = 0; i < this._fieldSize; i++)
            {
                this._field[i, column].SwitchDirection();
                this._field[row, i].SwitchDirection();
            }
        }

        public void Print()
        {
            for (int i = 0; i < this._fieldSize; i++)
            {
                for (int j = 0; j < this._fieldSize; j++)
                {
                    Console.Write($"{this._field[i, j]}");
                }
                Console.WriteLine();
            }
        }

        public bool CheckIfSolved()
        {
            var direction = this._field[0, 0].Direction;
            foreach (var cell in this._field)
            {
                if (cell.Direction != direction) { return false; }
            }
            return true;
        }
    }
}