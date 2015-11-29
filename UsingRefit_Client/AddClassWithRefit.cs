using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace UsingRefit_Client
{
    class AddClassWithRefit
    {
        public int Add(int num1, int num2)
        {
            return CallAdd(num1,num2).Result;
        }

        private async Task<int> CallAdd(int num1,int num2)
        {
            var addApi = RestService.For<IAddWithRefit>("http://localhost:52899");
            var result = await addApi.Add(5,10);
            return result;
        }
    }
}
