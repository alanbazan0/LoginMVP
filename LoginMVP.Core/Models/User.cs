using System;
using System.ComponentModel.DataAnnotations;

namespace LoginMVP.Core.Models
{
    public class User
    {
        [Required]
        public string Username
		{
			get;
			set;
		}

        [Required]
		public string Password
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}
    }
}
