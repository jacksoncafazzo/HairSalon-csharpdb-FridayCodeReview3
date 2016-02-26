using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BabsHairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void Test_IfCanCreate()
    {
      // Arrange, Act
      Stylist stylist = new Stylist("Babs");
      // Assert
      Assert.Equal("Babs", stylist.GetName());
    }
  }
}
