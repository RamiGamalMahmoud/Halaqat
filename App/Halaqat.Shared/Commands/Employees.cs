using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace Halaqat.Shared.Commands
{
    public static class Employees
    {
        public record GetByName(string Name) : IRequest<IEnumerable<Employee>>;
        public record GetTeachersCommand() : IRequest<IEnumerable<Employee>>;
    }
}
