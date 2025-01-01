using CommunityToolkit.Mvvm.Messaging.Messages;
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
            public record WarningNotification(string Message = "تحذير");
            public record Notification(string Message);
        }

        public static class Users
        {
            public record LoginSucceded(User User);
            public record LoginFailed();
            public record LogoutMessage();
            public class LoggedInUserRequestMessage() : RequestMessage<User>;
            public class GetEmployeesPrivilegesRequestMessage() : RequestMessage<Privileges>;
            public class GetStudentsPrivilegesRequestMessage() : RequestMessage<Privileges>;
            public class GetCirclesPrivilegesRequestMessage() : RequestMessage<Privileges>;
            public class GetProgramsPrivilegesRequestMessage() : RequestMessage<Privileges>;
            public class GetUsersPrivilegesRequestMessage() : RequestMessage<Privileges>;
        }

        public static class Logging
        {
            public record LogErrorMessage(string Message);
        }

        public static class App
        {
            public class TestConnectionRequestMessageAsync : AsyncRequestMessage<bool>;
            public class TestConnectionRequestMessageWitoutDatabaseAsync : AsyncRequestMessage<bool>;
        }
    }
}
