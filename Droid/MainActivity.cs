using Android.App;
using Android.Widget;
using Android.OS;
using LoginMVP.Views;
using LoginMVP.Presenters;
using LoginMVP.Models;

namespace LoginMVP.Droid
{
    [Activity(Label = "LoginMVP", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, ILoginView
    {
        private LoginPresenter presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            presenter = new LoginPresenter(this);

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);			

			FindViewById<Button>(Resource.Id.loginButton).Click += delegate {Login();};
        }

        public void Login()
        {
            presenter.Login();
        }

        public string Username 
        {
            get
            {
                return FindViewById<EditText>(Resource.Id.userEditText).Text;
            }
            set
            {
                FindViewById<EditText>(Resource.Id.userEditText).Text = value;
            }
        }

		public string Password
		{
			get
			{
				return FindViewById<EditText>(Resource.Id.passwordEditText).Text;
			}
			set
			{
				FindViewById<EditText>(Resource.Id.passwordEditText).Text = value;
			}
		}

        public void LoadMenu(User user)
        {
            //send the current user to the next window...
        }

        public void ShowMessage(string message)
        {
            Toast.MakeText(this,message,ToastLength.Short).Show();
        }
    }
}

