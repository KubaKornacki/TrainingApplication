using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Repositories
{
    public interface IDictRepository
    {

        IEnumerable<Dict> GetDictsByName(string name);

        Dict GetDictById(int id);

        Dict GetDict(string name, int id);
    }
}
