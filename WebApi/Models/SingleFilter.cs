using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SingleFilter
    {
        public string Mark { get; set; }
        public string Value { get; set; }
    }

    public class AllFieldsFilters
    {
        public string Student { get; set; }
        public int LanguageAndArts { get; set; }
        public int Science { get; set; }
        public int SocialStudies { get; set; }
        public int Maths { get; set; }
    }
}