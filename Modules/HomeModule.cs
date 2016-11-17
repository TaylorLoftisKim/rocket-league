using Nancy;
using System.Collections.Generic;
using RocketLeague.Objects;

namespace RocketLeague
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/car/new"] = _ => View["car-new-form.cshtml"];
      Get["/player/new"] = _ => View["player-new-form.cshtml"];
      Get["/players/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedPlayer = Player.Find(parameters.id);
        var playerCars = selectedPlayer.GetCars();
        model.Add("player", selectedPlayer);
        model.Add("Cars", playerCars);
        return View["view-player.cshtml", model];
      };
      Get["/view-all-player"] = _ =>
       {
         var allPlayers = Player.GetAll();
         return View["view-all-player.cshtml", allPlayers];
       };
      Post["/view-all-car"] = _ =>
      {
        Car newCar = new Car(Request.Form["name"]);
        var allCar = Car.GetAllCar();
        return View["view-all-car.cshtml", allCar];
      };
      Post["/view-all-player"] = _ =>
      {
        Player newPlayer = new Player(Request.Form["player"]);
        var allPlayers = Player.GetAll();
        return View["view-all-player.cshtml", allPlayers];
      };
      Get["/player/{id}/car/new"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedPlayer = Player.Find(parameters.id);
        var playerCars = selectedPlayer.GetCars();
        model.Add("player", selectedPlayer);
        model.Add("Cars", playerCars);
        return View["car-new-form.cshtml", model];
      };
      Post["/cars"] = _ =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedPlayer = Player.Find(Request.Form["player-id"]);
        List<Car> playerCars = selectedPlayer.GetCars();
        Car newCar = new Car(Request.Form["car-name"]);
        playerCars.Add(newCar);
        model.Add("Cars", playerCars);
        model.Add("player", selectedPlayer);
        return View["view-player.cshtml", model];
      };

      Post["/searchPlayer"] = _ =>
      {
        var searchInput = Request.Form["searchName"];
        List<Player> matchedPlayers = Player.FilteredPlayer(searchInput);
        return View["view-all-player.cshtml", matchedPlayers];
      };
    }
  }
}
