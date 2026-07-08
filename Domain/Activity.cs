using System;
using System.Net.NetworkInformation;

namespace Domain;

public class Activity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required String Title { get; set; }

    public DateTime Date { get; set; }

    public required String Description { get; set; }

    public required String Category { get; set; }

    public bool IsCancelled { get; set; }

    //location props
    public required String City { get; set; }

    public required String Venue { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    // navigation properties
    public ICollection<ActivityAttendee> Attendees { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}