using CoffeShop.DAL;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMenuRepository : GenericRepositories<Menu>, IMenuDal
    {
        public EFMenuRepository(AppDbContext db) : base(db)
        {
          
        }

    }
}


