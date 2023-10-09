using Lab2;

namespace TestingTesting123;

public class UnitTest1
{

    BusinessLogic businesslogic = new BusinessLogic();

    [Fact]
    public void InsertAirport()
    {
        businesslogic.AddAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 5);
        Assert.NotNull(businesslogic.FindAirport("KFLD"));
    }

    private void RunAirportEdgeTest(string airportCode, string airportName, DateTime openingDate, int runwayCount)
    {
        businesslogic.AddAirport(airportCode, airportName, openingDate, runwayCount);
        Assert.Null(businesslogic.FindAirport(airportCode));
    }

    [Fact]
    public void AddAirportEdgeTest2()
    {
        RunAirportEdgeTest("KRRL", "Merrill", new DateTime(2023, 6, 20), 6);
    }

    [Fact]
    public void AddAirportEdgeTest3()
    {
        RunAirportEdgeTest("KLNL", "Land O' Lakes", new DateTime(2023, 6, 20), 0);
    }
    [Fact]
    public void AddAirportEdgeTest4()
    {
        RunAirportEdgeTest("STE", "Stevens Point", new DateTime(2023, 6, 20), 6);
    }

    [Fact]
    public void AddDuplicateAirportTest()
    {
        Assert.False(businesslogic.AddAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 5));
    }

    [Fact]
    public void DeleteNonExistantAirportTest()
    {
        Assert.False(businesslogic.DeleteAirport("KSTE"));
    }

    [Fact]
    public void DeleteAirportTest()
    {
        Assert.True(businesslogic.DeleteAirport("KFLD"));
    }

    [Fact]
    public void EditAirportTest()
    {
        businesslogic.DeleteAirport("KFLD");
        businesslogic.AddAirport("KFLD", "fond du lac", new DateTime(2023, 9, 18), 5);
        businesslogic.EditAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 20), 3);
        Assert.Equal(new Airport("KFLD", "Fond du Lac", new DateTime(2023, 9, 20), 3), businesslogic.FindAirport("KFLD"));
        
    }

    [Fact]
    public void EditAirportEdgeCaseTest1()
    {
        businesslogic.DeleteAirport("KSTE");
        businesslogic.AddAirport("KSTE", "Stevens Point", new DateTime(2023, 9, 18), 5);
        businesslogic.EditAirport("KSTE", "Stevens Point", new DateTime(2023, 9, 18), 5);

        Airport airport = new Airport("KSTE", "Stevens Point", new DateTime(2023, 9, 18), 5);
        Assert.Equal(airport.City, businesslogic.FindAirport("KSTE").City);
        

       
    }

    //[Fact]
    //public void EditAirportEdgeCaseTest2()
    //{
    //    businesslogic.AddAirport("KFLD", "fond du lac", new DateTime(2023, 9, 18), 5);
    //    businesslogic.EditAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 3);
    //    Assert.Equal(new Airport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KFLD"));

    //}
    //[Fact]
    //public void EditAirportEdgeCaseTest3()
    //{
    //    businesslogic.AddAirport("KFLD", "fond du lac", new DateTime(2023, 9, 18), 5);
    //    businesslogic.EditAirport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 3);
    //    Assert.Equal(new Airport("KFLD", "Fond du Lac", new DateTime(2023, 9, 18), 3), businesslogic.FindAirport("KFLD"));

    //}
}
