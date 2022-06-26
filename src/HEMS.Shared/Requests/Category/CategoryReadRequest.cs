using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.Category
{
    public class CategoryReadRequest
    {
        public int Id { get; set; }

        public CategoryReadRequest(int id)
        {
            Id = id;
        }
    }
}
