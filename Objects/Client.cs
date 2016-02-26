using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BabsHairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylist_id = StylistId;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylist_id;
    }
    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        Client newClient = new Client(ClientName, ClientId);
        allClients.Add(newClient);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;
    }


    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        return (idEquality && nameEquality);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this._name;
      cmd.Parameters.Add(nameParameter);

      SqlParameter StylistIdParameter = new SqlParameter();
      StylistIdParameter.ParameterName = "@StylistId";
      StylistIdParameter.Value = this._stylist_id;
      cmd.Parameters.Add(StylistIdParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Client Find(int ClientId)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
      SqlParameter ClientIdParameter = new SqlParameter();
      ClientIdParameter.ParameterName = "@ClientId";
      ClientIdParameter.Value = ClientId.ToString();
      cmd.Parameters.Add(ClientIdParameter);
      rdr = cmd.ExecuteReader();

      int foundClientId = 0;
      string foundClientName = null;

      while(rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
      }
      Client foundClient = new Client(foundClientName, foundClientId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundClient;
    }
  }
}
