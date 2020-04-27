using App_v2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.ViewModel
{
    public class FormViewModel
    {
        
       public Form Form { get; set; }
    
       public IEnumerable<SelectListItem> FreeTime { get; set; }

       public IEnumerable<SelectListItem> TrainingCategory { get; set; }
    
       public IEnumerable<SelectListItem> Goal { get; set; }

    }
}
