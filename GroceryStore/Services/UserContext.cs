using Services.Contacts;

namespace Services
{
    public class UserContext : IUserContext
    {
        private int? loggedUserId;

        public int? LoggedUserId
        {
            get => this.loggedUserId;
            private set => this.loggedUserId = value;
        }

        public void Login(int userId)
        {
            this.LoggedUserId = userId;
        }
    }
}
