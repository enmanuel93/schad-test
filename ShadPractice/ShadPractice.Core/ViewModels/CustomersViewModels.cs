using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.ViewModels
{
    public class CustomersViewModels
    {
        public string SelectCustomer { get; set; }

        public List<SelectListItem> CustomersSelectList { get; set; }
    }
}
