using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LoginMVP.Models;
using System.Collections.Generic;

namespace LoginMVP.DataAccess
{
    public class DataService<T>
    {
        public DataService()
        {
            Parameters = new List<HTTPParameter>();
        }

		public DataService(string url)
		{
            Url = url;
            Parameters = new List<HTTPParameter>();
		}

		public DataService(string server, string path)
		{
            Url = server+ "/" + path;
             Parameters = new List<HTTPParameter>();
		}

        public void AddParameter(string name, string value)
        {
            Parameters.Add(new HTTPParameter(name,value));        
        }

        public async Task<T> Execute()
		{
			T data = default(T);
			using (var client = new HttpClient())
			{
                string queryString = GetQueryString(Parameters);
				var result = await client.GetStringAsync(Url);
				data = JsonConvert.DeserializeObject<T>(result);
			}
			return data;
		}

        public async Task<T> Execute(string url)
        {
            T data = default(T);
			using (var client = new HttpClient())
			{					
				var result = await client.GetStringAsync(url);
				data = JsonConvert.DeserializeObject<T>(result);
			}
            return data;
        }

		public async Task<T> Execute(string url, List<HTTPParameter> parameters)
		{
			T data = default(T);
			using (var client = new HttpClient())
			{
                string queryString = GetQueryString(parameters);
				var result = await client.GetStringAsync(url);
				data = JsonConvert.DeserializeObject<T>(result);
			}
			return data;
		}

        private string GetQueryString(List<HTTPParameter> parameters)
        {
            string queryString= string.Empty;
            if(parameters.Count>0)
            {
                queryString = "?";
                for (int i = 0; i < parameters.Count; i++)
                {
                    HTTPParameter parameter = parameters[i];
                    queryString += parameter.Name + "=" + parameter.Value;
                    if(i< parameters.Count-1)
                        queryString+="&";
                }
            }
            return queryString;
        }

		public string Url
		{
			get;
			set;
		}

		public List<HTTPParameter> Parameters
		{
			get;
			set;
		}

    }
}
