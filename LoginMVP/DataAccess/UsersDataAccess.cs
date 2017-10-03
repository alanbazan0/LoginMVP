using System;
using LoginMVP.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
namespace LoginMVP.DataAccess
{
    public class UsersDataAccess 
    {
        
        public UsersDataAccess()
        {
        }

        public async Task<User> Find(string username, string password)
        {
            DataService<User> dataService = new DataService<User>(Constants.SERVER,"api/users/find.php");
            dataService.AddParameter("username",username);
            dataService.AddParameter("password",password);
            User user = await dataService.Execute();

            /*
            User user = null;
			using (var client = new HttpClient())
			{

                var uri = "http://www.alanbazan.com.mx/api/users/find.php";
                uri += "?Username=" + username;
                uri += "&Password=" + password;
                var result = await client.GetStringAsync(uri);
                user = JsonConvert.DeserializeObject<User>(result);
			}
			*/
			



            return user;

        }
    }
}
