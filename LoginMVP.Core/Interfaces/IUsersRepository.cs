using System;
using LoginMVP.Core.Models;
namespace LoginMVP.Core.Interfaces
{
    public interface IUsersRepository
    {
        User Find(string username, string password);		
    }
}
