namespace BrothersGame.Core
{
    internal class GameFieldCell
    {
        private const string HorizontalLine = "-";
        private const string VerticalLine = "|";
        
        public CellDirection Direction { get; private set; }

        public GameFieldCell()
        {
            Direction = CellDirection.Horizontal;
        }

        public void SwitchDirection()
        {
            Direction = Direction == CellDirection.Horizontal
                ? CellDirection.Vertical
                : CellDirection.Horizontal;
        }

        public override string ToString()
        {
            return Direction == CellDirection.Horizontal ? HorizontalLine : VerticalLine;
        }
    }
}