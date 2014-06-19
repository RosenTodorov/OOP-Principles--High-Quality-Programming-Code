namespace RefactoreStatements.Matrix
{
    using System;
    using System.Linq;

    public class BoundsValidator
    {
        private const int MinimalColumnValue = int.MinValue;
        private const int MaximalColumnValue = int.MaxValue;
        private const int MaximalRowValue = int.MaxValue;
        private const int MinimalRowValue = int.MinValue;

        private int currentRow = 0;
        private int currentColumn = 0;

        public void GoToCell(int row, int column, bool shouldNotVisitedCell)
        {
            if (this.CheckForValidCell(row, column, bool))
            {
                this.VisitedCell(row, column);
            }
        }


        private bool CheckForValidCell(int row, int column, bool shouldNotVisitedCell)
        {
            bool validRow = MinimalRowValue <= row && row <= MaximalRowValue;
            bool validColumn = MinimalColumnValue <= column && column <= MaximalColumnValue;
            bool isValidCell = validColumn && validRow && !shouldNotVisitedCell;

            return isValidCell;
        }

        private void VisitedCell(int row, int column)
        {
            this.currentColumn = column;
            this.currentRow = row;
        }
    }
}