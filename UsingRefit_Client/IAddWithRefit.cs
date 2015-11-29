using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace UsingRefit_Client
{
    public interface IAddWithRefit
    {
        [Get("/add")]
        Task<int> Add(int num1, int num2);
    }
}
