using System.Collections.Generic;

namespace RocketLeague.Objects
{
  public class Player
  {
    private static List<Player> _instances = new List<Player> {};
    private string _artistName;
    private int _id;
    private List<Car> _cars;
    private static List<Player> _matches = new List<Player> {};

    public Player(string artistName)
    {
      _artistName = artistName;
      _instances.Add(this);
      _id = _instances.Count;
      _cars = new List<Car>{};
    }
    public string GetPlayerName()
    {
      return _artistName;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Car> GetCars()
    {
      return _cars;
    }
    public static Player Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public static List<Player> FilteredPlayer(string searchName)
    {
      _matches.Clear();
      foreach(Player i in _instances)
      {
        if(i._artistName == searchName)
        {
          _matches.Add(i);
        }
      }
      return _matches;
    }
    public static List<Player> GetAll()
    {
      return _instances;
    }
  }


}
