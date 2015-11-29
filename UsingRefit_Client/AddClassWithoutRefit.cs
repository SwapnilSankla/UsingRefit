using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsingRefit_Client
{
    internal class AddClassWithoutRefit
    {
        public int Add(int num1, int num2)
        {
            return CallAdd(num1,num2).Result;
        }

        private async Task<int> CallAdd(int num1, int num2)
        {
            using (var client = new HttpClient())
            {
                var requestUri = string.Format("http://localhost:52899/add?num1={0}&num2={1}", num1, num2);
                using (var r = await client.GetAsync(new Uri(requestUri)))
                {
                    var result = await r.Content.ReadAsStringAsync();
                    return Convert.ToInt32((string) result);
                }
            }
        }
    }
}