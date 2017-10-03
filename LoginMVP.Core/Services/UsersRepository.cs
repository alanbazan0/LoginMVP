using System;
using LoginMVP.Core.Interfaces;
using LoginMVP.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoginMVP.Core.Services
{
    public class UsersRepository : IUsersRepository
    {
		private List<User> users;
		public UsersRepository()
		{
			InitializeData();
		}
		public User Find(string username, string password)
		{
            return users.FirstOrDefault(item => item.Username == username && item.Password == password);
		}

        private void InitializeData()
        {
			users = new List<User>();
			var user1 = new User
			{
				Username = "alanbazan",
				Password = "12345",
				Name = "Alan Bazan",
				Email = "alanbazan@hotmail.com"
			};
            users.Add(user1);
        }

    }
}
