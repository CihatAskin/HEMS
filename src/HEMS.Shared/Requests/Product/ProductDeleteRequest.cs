using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.Product
{
    public class ProductDeleteRequest
    {
        public string Code { get; set; }

        public ProductDeleteRequest(string code)
        {
            Code = code;
        }
    }
}
