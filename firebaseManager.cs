﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Grasshopper.Kernel;

namespace firehopper
{
    public

    class firebaseManager
    {
        /// <summary>
        /// This is a method that does the GET request asynchronously to Firebase.
        /// </summary>
        public static async Task<string> getAsync(string _apiKey, string _databaseURL, string _databaseNode)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_databaseURL);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", "Bearer " + _apiKey);
            HttpResponseMessage res = await httpClient.GetAsync(_databaseURL + _databaseNode + ".json");
            string responseBodyAsText = await res.Content.ReadAsStringAsync();

            return responseBodyAsText;
        }


        /// <summary>
        /// This is a method that does the PUT request asynchronously to Firebase.
        /// </summary>
        public static async Task<string> putAsync(string _apiKey, string _databaseURL, string _databaseNode, string _keyValuePair)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_databaseURL);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", "Bearer " + _apiKey);

            HttpContent httpContent = new StringContent(_keyValuePair);
            HttpResponseMessage res = await httpClient.PutAsync(_databaseURL + _databaseNode + ".json", httpContent);

            return res.StatusCode.ToString();
        }
    }
}
