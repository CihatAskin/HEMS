﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEMS.Shared.Requests.Category
{
    public class CategoryEditRequest
    {
        public int Id { get; set; }

        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
    }
}
