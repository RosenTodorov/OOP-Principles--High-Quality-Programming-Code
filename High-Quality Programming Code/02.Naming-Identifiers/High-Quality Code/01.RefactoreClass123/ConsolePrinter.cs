using System;
using System.Linq;
public class MainClass
{
    public const int MAX_COUNT = 6;

    public class FirstNestedClassInMainClass
    {
        public void ConvertBoolVariableToString(bool variableBoolState)
        {
            string boolVariableToString = variableBoolState.ToString();
            Console.WriteLine(boolVariableToString);
        }
    }
    public static void Main()
    {
        MainClass.FirstNestedClassInMainClass firstNestedClassInstance =
          new MainClass.FirstNestedClassInMainClass();
        firstNestedClassInstance.ConvertBoolVariableToString(true);
    }
}

