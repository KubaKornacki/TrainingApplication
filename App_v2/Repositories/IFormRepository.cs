using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Repositories
{
    public interface IFormRepository
    {
        void CreateForm(Form form);

        void UpdateForm(Form form);

        Form GetUserForm(string id);
       
    }
}
