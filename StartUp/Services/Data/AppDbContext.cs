using StartUp.Models;
using StartUp.Models.CandidateFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Services.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }  //eager
        public DbSet<Attempt> Attempts { get; set; }  //eager
        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<CandidateDetails> CandidateDetails { get; set; }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Scores> Scores { get; set; }


        public AppDbContext() : base("name=MyConnection") 
        {

        }


    }
}
