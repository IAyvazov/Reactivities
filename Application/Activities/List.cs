using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;
using MediatR;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>{}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this.context.Activities.ToListAsync(cancellationToken);
            }

        }
    }
}