using System;
using LoginMVP.Views;
using LoginMVP.DataAccess;
using LoginMVP.Models;

namespace LoginMVP.Presenters
{
    public class LoginPresenter
    {
        private ILoginView view;
        private User user;

       

        public LoginPresenter(ILoginView view)
        {
            this.view = view;
        }

        public async void Login()
        {
            UsersDataAccess dataAccess = new UsersDataAccess();
            user = await dataAccess.Find(view.Username, view.Password); 
            if(user!=null)
            {
                view.LoadMenu(user);
				view.ShowMessage("Access granted!");
            }
            else
            {
                //access denied
                view.ShowMessage("Access denied!");
            }
        }

        public User User
        {
            get { return user; }
        }

    }
}
