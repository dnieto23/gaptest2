using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class RegisterModel
    {
        public string Student { get; set; }
        public int LanguageAndArts { get; set; }
        public int Science { get; set; }
        public int SocialStudies { get; set; }
        public int Maths { get; set; }
        public RegisterModel(string student, int languageAndArts,int science, int socialStudies, int maths)
        {
            Student = student;
            LanguageAndArts = languageAndArts;
            Science = science;
            SocialStudies = socialStudies;
            Maths = maths;
        }
    }
}