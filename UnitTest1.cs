using Lab2;
using System.Collections.ObjectModel;

namespace TestingTesting123;

public class UnitTest1
{

    BusinessLogic businesslogic = new BusinessLogic();

    //[Fact]
    //public void DeleteAllAirports()
    //{
    //    businesslogic.DeleteAirport("KFLD");
    //    businesslogic.DeleteAirport("KLSE");
    //    businesslogic.DeleteAirport("KMKE");
    //    businesslogic.DeleteAirport("KCWA");
    //    businesslogic.DeleteAirport("KGRB");
    //}

    [Fact]
    public void InsertAirportClassic()
    {
      
            businesslogic.AddAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 5);
       
        Assert.NotNull(businesslogic.FindAirport("KFLD"));
    }

    private void RunAirportEdgeTest(string id, string city, DateTime dateVisited, int rating)
    {
        businesslogic.AddAirport(id, city, dateVisited, rating);
        Assert.Null(businesslogic.FindAirport(id));
    }

    [Fact]
    public void InsertAirportInvalidHighRating()
    {
        RunAirportEdgeTest("KRRL", "Merrill", new DateTime(2023, 6, 20), 6);
    }

    [Fact]
    public void InsertAirportInvalidLowRating()
    {
        RunAirportEdgeTest("KLNL", "Land O' Lakes", new DateTime(2023, 6, 20), 0);
    }
    [Fact]
    public void InsertAirportInvalidId()
    {
        RunAirportEdgeTest("STE", "Stevens Point", new DateTime(2023, 6, 20), 6);
    }

    [Fact]
    public void InsertDuplicateAirport()
    {
        businesslogic.AddAirport("KAIG", "Antigo", new DateTime(2023, 9, 18), 2);
        Assert.False(businesslogic.AddAirport("KAIG", "Antigo", new DateTime(2023, 9, 18), 2));
    }

    [Fact]
    public void DeleteNonExistantAirportTest()
    {
        Assert.False(businesslogic.DeleteAirport("KEAU"));
    }

    [Fact]
    public void DeleteAirportTest()
    {
        Assert.True(businesslogic.DeleteAirport("KFLD"));
    }

    [Fact]
    public void EditAirportTest()
    {
        businesslogic.AddAirport("KLSE", "lacrosse", new DateTime(2023, 9, 18), 5);
        businesslogic.EditAirport("KLSE", "La Crosse", new DateTime(2023, 9, 20), 3);
        Assert.Equivalent(new Airport("KLSE", "La Crosse", new DateTime(2023, 9, 20), 3), businesslogic.FindAirport("KLSE"));
    }

    [Fact]
    public void UpdateWithInvalidCityLengthTest()
    {
        businesslogic.DeleteAirport("KMKE");
        businesslogic.AddAirport("KMKE", "Milwaukee", new DateTime(2023, 9, 18), 3);
        businesslogic.EditAirport("KMKE", "MilwaukeeWisconsinisWhereTheMKEBucksPlay", new DateTime(2023, 9, 18), 3);
        Assert.Equivalent(new Airport("KMKE", "Milwaukee", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KMKE"));
    }

    [Fact]
    public void UpdateWithInvalidRatingTest()
    {
        businesslogic.AddAirport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 3);
        businesslogic.EditAirport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 6);
        Assert.NotStrictEqual(new Airport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KCWA"));

    }

    [Fact]
    public void UpdateNonExistantAirportTest()
    {
        businesslogic.EditAirport("KGRB", "Green Bay", new DateTime(2023, 9, 18), 3);
        Assert.Null(businesslogic.FindAirport("KGRB"));

    }
   

    [Fact]
    public void SelectAllAirportsTest()
    {
        ObservableCollection<Airport> airports = businesslogic.GetAirports();
        Assert.NotNull(airports);
    }
}
