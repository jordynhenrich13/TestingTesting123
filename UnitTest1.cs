using Lab2;
using System.Collections.ObjectModel;

namespace TestingTesting123;

public class UnitTest1
{

    BusinessLogic businesslogic = new BusinessLogic();


    /// Can be ran as a test to clear
    /// all airports from the database
    /// Good to have a fresh start
    /// before running the tests :)
    //[Fact]
    //public void DeleteAllAirports()
    //{
    //    businesslogic.DeleteAirport("KFLD");
    //    businesslogic.DeleteAirport("KLSE");
    //    businesslogic.DeleteAirport("KMKE");
    //    businesslogic.DeleteAirport("KCWA");
    //    businesslogic.DeleteAirport("KGRB");
    //}

    /// <summary>
    /// Test method for inserting an airport and verifying its existence.
    /// </summary>
    [Fact]
    public void InsertAirportClassic()
    {

        businesslogic.AddAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 5);

        Assert.NotNull(businesslogic.FindAirport("KFLD"));
    }

    /// <summary>
    /// Helper method for running an edge test for inserting an airport with an invalid high rating.
    /// </summary>
    /// <param name="id">The ID of the airport to be inserted.</param>
    /// <param name="city">The city of the airport to be inserted.</param>
    /// <param name="dateVisited">The date when the airport was visited.</param>
    /// <param name="rating">The rating of the airport to be inserted.</param>
    private void RunAirportEdgeTest(string id, string city, DateTime dateVisited, int rating)
    {
        businesslogic.AddAirport(id, city, dateVisited, rating);
        Assert.Null(businesslogic.FindAirport(id));
    }

    /// <summary>
    /// Test method for inserting an airport with an invalid high rating.
    /// </summary>
    [Fact]
    public void InsertAirportInvalidHighRating()
    {
        RunAirportEdgeTest("KRRL", "Merrill", new DateTime(2023, 6, 20), 6);
    }

    /// <summary>
    /// Test method for inserting an airport with an invalid low rating.
    /// </summary>
    [Fact]
    public void InsertAirportInvalidLowRating()
    {
        RunAirportEdgeTest("KLNL", "Land O' Lakes", new DateTime(2023, 6, 20), 0);
    }

    /// <summary>
    /// Test method for inserting an airport with an invalid ID.
    /// </summary>
    [Fact]
    public void InsertAirportInvalidId()
    {
        RunAirportEdgeTest("STE", "Stevens Point", new DateTime(2023, 6, 20), 6);
    }

    /// <summary>
    /// Test method for inserting a duplicate airport.
    /// </summary>
    [Fact]
    public void InsertDuplicateAirport()
    {
        businesslogic.AddAirport("KAIG", "Antigo", new DateTime(2023, 9, 18), 2);
        Assert.False(businesslogic.AddAirport("KAIG", "Antigo", new DateTime(2023, 9, 18), 2));
    }

    /// <summary>
    /// Test method for deleting a non-existent airport.
    /// </summary>
    [Fact]
    public void DeleteNonExistantAirportTest()
    {
        Assert.False(businesslogic.DeleteAirport("KEAU"));
    }

    /// <summary>
    /// Test method for deleting an airport.
    /// </summary>
    [Fact]
    public void DeleteAirportTest()
    {
        Assert.True(businesslogic.DeleteAirport("KFLD"));
    }

    /// <summary>
    /// Test method for editing an airport.
    /// </summary>
    [Fact]
    public void EditAirportTest()
    {
        businesslogic.AddAirport("KLSE", "lacrosse", new DateTime(2023, 9, 18), 5);
        businesslogic.EditAirport("KLSE", "La Crosse", new DateTime(2023, 9, 20), 3);
        Assert.Equivalent(new Airport("KLSE", "La Crosse", new DateTime(2023, 9, 20), 3), businesslogic.FindAirport("KLSE"));
    }

    /// <summary>
    /// Test method for updating an airport with an invalid city length.
    /// </summary>
    [Fact]
    public void UpdateWithInvalidCityLengthTest()
    {
        businesslogic.DeleteAirport("KMKE");
        businesslogic.AddAirport("KMKE", "Milwaukee", new DateTime(2023, 9, 18), 3);
        businesslogic.EditAirport("KMKE", "MilwaukeeWisconsinisWhereTheMKEBucksPlay", new DateTime(2023, 9, 18), 3);
        Assert.Equivalent(new Airport("KMKE", "Milwaukee", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KMKE"));
    }

    /// <summary>
    /// Test method for updating an airport with an invalid rating.
    /// </summary>
    [Fact]
    public void UpdateWithInvalidRatingTest()
    {
        businesslogic.AddAirport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 3);
        businesslogic.EditAirport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 6);
        Assert.NotStrictEqual(new Airport("KCWA", "Mosinee", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KCWA"));

    }

    /// <summary>
    /// Test method for updating a non-existent airport.
    /// </summary>
    [Fact]
    public void UpdateNonExistantAirportTest()
    {
        businesslogic.EditAirport("KGRB", "Green Bay", new DateTime(2023, 9, 18), 3);
        Assert.Null(businesslogic.FindAirport("KGRB"));

    }

    /// <summary>
    /// Test method for selecting all airports.
    /// </summary>
    [Fact]
    public void SelectAllAirportsTest()
    {
        ObservableCollection<Airport> airports = businesslogic.GetAirports();
        Assert.NotNull(airports);
    }
}
