using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LMIChallengesCollection
{
    public class ApiCaller
    {
        public class userData
        {
            public string name { get; set; }
            public string job { get; set; }
        }
        public IRestResponse getData()
        {
            var client = new RestClient("https://reqres.in/api/users");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;

        }


        public IRestResponse getSingleUserData(int id)
        {
            var client = new RestClient($"https://reqres.in/api/users/{id}");
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return response;

        }



        public IRestResponse postData(userData sample)
        {
            var client = new RestClient("https://reqres.in/api/users");
            var request = new RestRequest(Method.POST);

            // APi documentation says it is language agnostic and accepts the content type of 
            //application/json

            request.RequestFormat = DataFormat.Json;
                                              
            request.AddParameter("application/json", JsonConvert.SerializeObject(sample), ParameterType.RequestBody);
           
            IRestResponse response = client.Execute(request);
            return response;
           
        }

    }

}

