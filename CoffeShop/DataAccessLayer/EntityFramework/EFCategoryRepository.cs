﻿using CoffeShop.DAL;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryRepository:GenericRepositories<Category>,ICategoryDal
    {
        public EFCategoryRepository(AppDbContext db) : base(db)
        {
        }


    }
}
