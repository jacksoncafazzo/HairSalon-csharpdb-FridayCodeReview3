using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BabsHairSalon
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Post["/add_stylist"] = _ => {
        Stylist stylist = new Stylist(Request.Form["stylist-name"]);
        stylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/stylist/{id}"] = parameters => {
        Dictionary<string, object> models = new Dictionary<string, object>(){};
        Stylist stylist = Stylist.Find(parameters.id);
        models.Add("stylist", stylist);

        List<Client> foundClients = Client.FindByStylistId(parameters.id);
        models.Add("clients", foundClients);
        return View["stylist.cshtml", models];
      };

      Post["/stylist/{id}"] = parameters => {
        Dictionary<string, object> models = new Dictionary<string, object>(){};
        Stylist stylist = Stylist.Find(parameters.id);
        stylist.Update(Request.Form["new-stylist-name"]);
        models.Add("stylist", stylist);
        List<Client> foundClients = Client.FindByStylistId(parameters.id);
        models.Add("clients", foundClients);
        return View["stylist.cshtml", models];
      };

      Delete["/stylist/{id}/delete"] = parameters => {
        Stylist stylist = Stylist.Find(parameters.id);
        stylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Patch["/stylist/{id}/update"] = parameters => {
        Stylist stylist = Stylist.Find(parameters.id);
        stylist.Update(Request.Form["new-stylist-name"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/stylists/all"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/stylist/{id}/clients"] = parameters => {
        Dictionary<string, object> models = new Dictionary<string, object>(){};
        Stylist stylist = Stylist.Find(parameters.id);
        models.Add("stylist", stylist);
        List<Client> foundClients = Client.FindByStylistId(parameters.id);
        models.Add("clients", foundClients);
        return View["stylist.cshtml", models];
      };

      Post["/stylist/{id}/clients"] = parameters => {
        List<Client> foundClients = Client.FindByStylistId(parameters.id);
        return View["stylist.cshtml", foundClients];
      };

      Post["/stylist/{id}/add_client"] = parameters => {
        Dictionary<string, object> models = new Dictionary<string, object>(){};
        Stylist stylist = Stylist.Find(parameters.id);
        models.Add("stylist", stylist);
        Client client = new Client(Request.Form["client-name"], parameters.id);
        client.Save();
        List<Client> foundClients = Client.FindByStylistId(parameters.id);
        models.Add("clients", foundClients);
        return View["stylist.cshtml", models];
      };

      Delete["/clear_all"] = _ => {
        Stylist.DeleteAll();
        return View["index.cshtml"];
      };


    }
  }
}
