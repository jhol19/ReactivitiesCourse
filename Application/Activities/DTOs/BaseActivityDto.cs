using System;

namespace Application.Activities.DTOs;

public class BaseActivityDto
{
    public String Title { get; set; } = "";

    public DateTime Date { get; set; }

    public String Description { get; set; } = "";

    public String Category { get; set; } = "";

    //location props
    public String City { get; set; } = "";

    public String Venue { get; set; } = "";

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
