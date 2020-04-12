using System;

using Microsoft.EntityFrameworkCore;

using RealDeal.AppLogic.Models;

namespace RealDeal.DataAcces
{
    public class DataAccesDbContext : DbContext
    {
        public DataAccesDbContext(DbContextOptions<DataAccesDbContext> options)
            : base(options)
        {
        }


    }
}
