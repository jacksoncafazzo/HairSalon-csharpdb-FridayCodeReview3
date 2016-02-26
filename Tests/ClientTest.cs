using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BabsHairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void IfClientEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void IfClientMakesClient()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);

      //Assert
      Assert.Equal(1, client.GetStylistId());
    }
    [Fact]
    public void IfEqualsOverrideLetsTwoClientsHaveSameName()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);
      Client otherClient = new Client("Suzie",1);
      //Assert
      Assert.Equal(true, client.Equals(otherClient));
    }
    [Fact]
    public void IfEqualsOverrideFindsTwoClientsHaveDifferentNames()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);
      Client otherClient = new Client("Barbara",1);
      //Assert
      Assert.Equal(false, client.Equals(otherClient));
    }

    [Fact]
    public void Save_SavesToDatabase()
    {
      Client.DeleteAll();
      //Arrange
      Client testClient = new Client("Suzie",1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();

      //Assert
      Assert.Equal(testClient.GetName(), result[0].GetName());
      Client.DeleteAll();
    }

    [Fact]
    public void Find_GetClientInDatabaseById()
    {
      //Arrange
      Client testClient = new Client("Marsha",1);
      Client otherTestClient = new Client("David",1);
      testClient.Save();
      otherTestClient.Save();
      Client foundClient = Client.Find(testClient.GetId());
      //Act
      int returnId = foundClient.GetId();

      //Assert
      Assert.Equal(testClient.GetName(), foundClient.GetName());
    }

    [Fact]
    public void Update_UpdatesClientInDatabase()
    {
      //Arrange
      Client testClient = new Client("Michael",0);
      testClient.Save();
      //Act
      testClient.Update("Nancy");

      string result = testClient.GetName();

      //Assert
      Assert.Equal("Nancy", result);
    }
    [Fact]
    public void Delete_IfDeletesClientInDatabase()
    {
      //Arrange
      Client firstClient = new Client("Princess",0);
      Client secondClient = new Client("Gunda",1);
      firstClient.Save();
      secondClient.Save();
      // Client foundClientId = secondClient.GetId();

      //Act
      firstClient.Delete();
      List<Client> allClients = Client.GetAll();
      //Assert
      Assert.Equal("Gunda", allClients[0].GetName());
    }
  }
}
