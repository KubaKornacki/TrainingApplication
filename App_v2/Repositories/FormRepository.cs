using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;

namespace App_v2.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _db;
        public FormRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public void CreateForm(Form form)
        {
            _db.Forms.Add(form);
            _db.SaveChanges();
        }

        public Form GetUserForm(string id)
        {
           return _db.Forms.FirstOrDefault(x => x.User.Id==id);
        }

        public void UpdateForm(Form form)
        {
            _db.Forms.Update(form);
            _db.SaveChanges();
        }
    }
}
