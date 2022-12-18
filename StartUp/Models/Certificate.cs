using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Models
{
    public class Certificate
    {
        public int CertificateId { get; set; }

        public string Title { get; set; }

        //public int AssessmentTestCode { get; set; }

        public string TopicDescription { get; set; }


        public Certificate()
        {

        }

        public Certificate(  string title,  string topicDescription)
        {
            
            Title = title;
            //AssessmentTestCode = assessmentTestCode;
            TopicDescription = topicDescription;
        }


        public override string ToString()
        {
            return $"{Title}\nDescription:{TopicDescription}\n-----------------------\n ";
        }
    }





    

}
