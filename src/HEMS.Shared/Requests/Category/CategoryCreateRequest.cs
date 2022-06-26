using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.Category
{
    public class CategoryCreateRequest
    {
        public string Code { get; set; }

        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryCreateRequest(string code, string status, string name, string description)
        {
            Code = code;
            Status = status;
            Name = name;
            Description = description;
        }

    }
}
