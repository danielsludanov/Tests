using System.Windows;

namespace Tests
{
    public partial class App : Application
    {
        public int CurrentUserID { get; set; }
        public int CurrentRoleID {  get; set; }

        public void SetCurrentID (int ID)
        {
            CurrentUserID = ID;
        }

        public void SetCurrentRole (int role_id)
        {
            CurrentRoleID = role_id;
        }
    }
}
