﻿using System;
using System.Net.Http;
using IdentityModel.Client;

namespace PwdClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var dico = DiscoveryClient.GetAsync("http://localhost:5000").Result;

            //token
            var tokenClient = new TokenClient(dico.TokenEndpoint, "pwdClient", "secret");
            var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("wyt", "123456").Result;
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;

            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");


            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            var response = httpClient.GetAsync("http://localhost:5001/api/values").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}