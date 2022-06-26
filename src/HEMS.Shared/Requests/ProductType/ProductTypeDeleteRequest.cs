using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.ProductType
{
    public class ProductTypeDeleteRequest
    {
        public string Code { get; set; }

        public ProductTypeDeleteRequest(string code)
        {
            Code = code;
        }
    }
}
