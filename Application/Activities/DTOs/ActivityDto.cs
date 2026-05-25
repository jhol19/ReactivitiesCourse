using System;
using Application.Profiles.DTOs;

namespace Application.Activities.DTOs;

public class ActivityDto
{
    public required string Id { get; set; }

    public required String Title { get; set; }

    public DateTime Date { get; set; }

    public required String Description { get; set; }

    public required String Category { get; set; }

    public bool IsCancelled { get; set; }

    public required string HostDisplayName { get; set; }

    public required string HostId { get; set; }

    //location props
    public required String City { get; set; }

    public required String Venue { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    // navigation properties
    public ICollection<UserProfile> Attendees { get; set; } = [];
}