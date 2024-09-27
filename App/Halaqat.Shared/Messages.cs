using Halaqat.Shared.Models;

namespace Halaqat.Shared
{
    public static class Messages
    {
        public static class Common
        {
            public record EntityCreatedMessage<TModel>(TModel Model);
            public record EntityUpdatedMessage<TModel>();
            public record EntityRemovedMessage<TModel>();
        }

        public static class Notifications
        {
            public record SuccessNotification(string Message = "عملية ناجحة");
            public record FailureNotification(string Message = "عملية فاشلة");
            public record Notification(string Message);
        }

        public static class Users
        {
            public record LoginSucceded(User User);
            public record LoginFailed();
        }

        public static class Logging
        {
            public record LogErrorMessage(string Message);
        }
    }
}
