using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.ViewModels
{
    public class CustomerTypeModels
    {
        public string SelectCustomerType { get; set; }

        public List<SelectListItem> CustomerTypesSelectList { get; set; }
    }
}
