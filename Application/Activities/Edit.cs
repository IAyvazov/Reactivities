using Domain;
using Persistence;

using AutoMapper;
using MediatR;

namespace Application.Activities
{
    public class Edit
    {
        public class Command :  IRequest 
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await this.context.Activities.FindAsync(request.Activity.Id);

                this.mapper.Map(request.Activity, activity);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}