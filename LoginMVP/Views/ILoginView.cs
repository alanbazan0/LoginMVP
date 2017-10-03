using System;
using LoginMVP.Models;

namespace LoginMVP.Views
{
    public interface ILoginView
    {
        string Username {get;set;}       
        string Password {get;set;}
        void Login();
        void LoadMenu(User user);
        void ShowMessage(string message);
    }
}
