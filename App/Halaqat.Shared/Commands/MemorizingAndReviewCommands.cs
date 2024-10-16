using Halaqat.Shared.Models;
using MediatR;

namespace Halaqat.Shared.Commands
{
    public static class MemorizingAndReviewCommands
    {
        public record ShowMemorizingAndReviewViewCommand(Student Student, Teacher Teacher) : IRequest;
    }
}
