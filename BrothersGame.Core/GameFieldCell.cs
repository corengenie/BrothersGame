namespace BrothersGame.Core
{
    internal enum CellDirection
    {
        Horizontal,
        Vertical
    }

    internal class GameFieldCell
    {
        public CellDirection Direction { get; set; }

        public GameFieldCell()
        {
            this.Direction = CellDirection.Horizontal;
        }

        public void SwitchDirection()
        {
            this.Direction = (this.Direction == CellDirection.Horizontal) ? CellDirection.Vertical : CellDirection.Horizontal;
        }

        public override string ToString()
        {
            return this.Direction == CellDirection.Horizontal ? "-" : "|";
        }
    }
}