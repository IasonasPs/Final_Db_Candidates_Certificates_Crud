using StartUp.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Models.CandidateFolder
{
    public class Candidate : IDisposable
    {
        public int  CandidateId { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }   

      public virtual CandidateDetails  Details { get; set; }    


        public Candidate()
        {

        }

        public Candidate(string fName, string lName)
        {
            this.fName = fName;
            this.lName = lName;
           
        }

        public Candidate(string fName, string mName, string lName)
        {
            this.fName = fName;
            this.mName = mName;
            this.lName = lName;
        }

        public override string ToString() 
        {
            return $"--->Candidate's name is {fName} {lName}." ;
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
