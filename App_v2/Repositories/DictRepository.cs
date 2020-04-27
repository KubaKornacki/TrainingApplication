using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;

namespace App_v2.Repositories
{
    public class DictRepository : IDictRepository
    {
        private readonly AppDbContext _db;

        public DictRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }


        public Dict GetDictById(int id)
        {
           return _db.Dicts.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Dict> GetDictsByName(string name)
        {
            return _db.Dicts.Where(x => x.DictName == name).ToList();
        }
    }
}
