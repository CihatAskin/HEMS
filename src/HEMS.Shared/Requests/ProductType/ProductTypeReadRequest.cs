using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.ProductType
{
    public class ProductTypeReadRequest
    {
        public int Id { get; set; }

        public ProductTypeReadRequest(int id)
        {
            Id = id;
        }
    }
}
