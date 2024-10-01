using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace Halaqat.Shared.Commands
{
    public static class Students
    {
        public record Search(string Name) : IRequest<IEnumerable<Student>>;
        public record GetStudentsWithNoCircleCommand : IRequest<IEnumerable<Student>>;
    }
}
