using System;
using System.Linq;

public class HumanCreationClass
{
  public enum Sex 
  { 
      BigGuy, 
      HotChick
  };

  private class Human
  {
    public Sex Sex { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }

  public void CreateHuman(int humanIdentificationNumber)
  {
      Human newHumanInstance = new Human();
      newHumanInstance.Age = humanIdentificationNumber;
      if (humanIdentificationNumber % 2 == 0)
      {
          newHumanInstance.Name = "The big guy";
          newHumanInstance.Sex = Sex.BigGuy;
      }
      else
      {
          newHumanInstance.Name = "The hot chick";
          newHumanInstance.Sex = Sex.HotChick;
      }
  }
}
