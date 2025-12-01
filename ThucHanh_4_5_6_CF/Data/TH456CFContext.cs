using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThucHanh_4_5_6_CF.Models;

namespace ThucHanh_4_5_6_CF.Data
{
    public class TH456CFContext : DbContext
    {
        public TH456CFContext(DbContextOptions<TH456CFContext> options) : base(options)
        {
            
        }

        public DbSet<Major> Major {get; set;}
        public DbSet<Course> Course {get; set;}
        public DbSet<Learner> Learner {get; set;}
        public DbSet<Enrollment> Enrollment {get; set;}
    }
}