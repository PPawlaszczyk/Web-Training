using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
namespace PartyInvites.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLenght()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http:/apress.com");
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecendent) =>
            {
                return antecendent.Result.Content.Headers.ContentLength;
            });
        }
    }
}