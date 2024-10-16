using Halaqat.Shared.Models;
using MediatR;

namespace Halaqat.Shared.Commands
{
    public static class Programs
    {
        public record GetProgram(int Id) : IRequest<Program>;
    }
}
