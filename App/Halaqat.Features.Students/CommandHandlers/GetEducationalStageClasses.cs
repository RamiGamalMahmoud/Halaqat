using Halaqat.Data;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal static class GetEducationalStageClasses
    {
        internal record Command(int EducationalStageId) : IRequest<IEnumerable<Class>>;

        internal class Handler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Command, IEnumerable<Class>>
        {
            public async Task<IEnumerable<Class>> Handle(Command request, CancellationToken cancellationToken)
            {
                using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
                {
                    return await dbContext
                        .Classes
                        .Where(x => EF.Property<int>(x, "EducationalStageId") == request.EducationalStageId)
                        .ToListAsync();
                }
            }
        }
    }
}
