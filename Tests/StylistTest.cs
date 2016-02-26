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

    [Fact]
    public void Test_EqualOverride_ReturnsTrueIfNameIsTheSame()
    {
      //Arrange, Act
      Stylist stylist1 = new Stylist("Babs");
      Stylist stylist2 = new Stylist("Babs");

      //Assert
      Assert.Equal(stylist1.GetName(), stylist2.GetName());
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Babs");
      Stylist otherStylist = new Stylist("Suzie");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      Assert.Equal(testList[0].GetName(), result[0].GetName());
    }

  }
}
