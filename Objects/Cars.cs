using System.Collections.Generic;

namespace RocketLeague.Objects
{
  public class Car
  {

    private string _name;
    private int _id;
    private static List<Car> _instances = new List<Car> {};

    public Car (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public static List<Car> GetAllCar()
    {
      return _instances;
    }

    public static Car Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
