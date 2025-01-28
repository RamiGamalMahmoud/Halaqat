using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace Halaqat.Shared.Commands
{
    public static class Circles
    {
        public record SearchByName(string Name) : IRequest<IEnumerable<Circle>>;
        public record ShowCircleDetailsCommand(int Id) : IRequest;
    }
}
