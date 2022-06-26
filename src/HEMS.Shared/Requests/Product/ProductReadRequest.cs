using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.Product
{
    public class ProductReadRequest
    {
        public int Id { get; set; }

        public ProductReadRequest(int id)
        {
            Id = id;
        }
    }
}
