using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.ViewModel
{
    public class TrainingTypeViewModel
    {
        public IEnumerable<SelectListItem> TrainingTypes { get; set; }

        public IEnumerable<SelectListItem> TrainingKinds { get; set; }

        public int TrainingTypeId { get; set; }
        public int TrainingKindId { get; set; }
    }
}
