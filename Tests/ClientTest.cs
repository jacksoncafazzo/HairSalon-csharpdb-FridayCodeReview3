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
    public void Test_IfClientEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_IfClientMakesClient()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);

      //Assert
      Assert.Equal(1, client.GetStylistId());
    }
    [Fact]
    public void Test_IfEqualsOverrideLetsTwoClientsHaveSameName()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);
      Client otherClient = new Client("Suzie",1);
      //Assert
      Assert.Equal(true, client.Equals(otherClient));
    }
    [Fact]
    public void Test_IfEqualsOverrideFindsTwoClientsHaveDifferentNames()
    {
      //Arrange, Act
      Client client = new Client("Suzie",1);
      Client otherClient = new Client("Barbara",1);
      //Assert
      Assert.Equal(false, client.Equals(otherClient));
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
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
  }
}
