using Models;

namespace Services.Contacts
{
    public interface IUserContext
    {
        int? LoggedUserId { get; }

        void Login(int userId);
    }
}
