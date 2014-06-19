namespace RefactoreStatements
{
    using System;
    using System.Linq;
    using RefactoreStatements.Potatoes;
    using RefactoreStatements.Matrix;

    public class Program
    {
        public static void Main()
        {
            Chef chefCeco = new Chef();
            chefCeco.Cook();

            BoundsValidator someTestMatrix = new BoundsValidator();
            someTestMatrix.GoToCell(1, 1, false);
        }
    }
}