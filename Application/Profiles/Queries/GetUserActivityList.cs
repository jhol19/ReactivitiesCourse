using Application.Core;
using Application.Interfaces;
using Application.Profiles.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles.Queries;

public class GetUserActivityList
{
    public class Query : IRequest<Result<List<UserActivityDto>>>
    {
        public required string UserId { get; set; }
        public required string Filter { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper, IUserAccessor userAccessor) :
        IRequestHandler<Query, Result<List<UserActivityDto>>>
    {
        public async Task<Result<List<UserActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = context.ActivityAttendees
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Activity.Date)
                .Select(x => x.Activity)
                .AsQueryable();

            var today = DateTime.UtcNow;

            query = request.Filter switch
            {
                "past" => query.Where(x => x.Date <= today
                    && x.Attendees.Any(a => a.UserId == userAccessor.GetUserId())),
                "hosting" => query.Where(x =>
                    x.Attendees.Any(a => a.IsHost && a.UserId == userAccessor.GetUserId())),
                _ => query.Where(x => x.Date > today
                    && x.Attendees.Any(a => a.UserId == userAccessor.GetUserId()))
            };

            var projectedActivities = query
                .ProjectTo<UserActivityDto>(mapper.ConfigurationProvider);
                
            var activities = await projectedActivities.ToListAsync(cancellationToken);

            return Result<List<UserActivityDto>>.Success(activities);
        }
    }
}