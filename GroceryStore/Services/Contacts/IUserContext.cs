using Models;

namespace Services.Contacts
{
    public interface IUserContext
    {
        int? LoggedUserId { get; }

        void Login(int userId);

        void Logout();

        User CheckLogin(string username, string password);
    }
}
