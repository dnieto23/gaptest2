using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        /// <summary>
        /// Method to validate if the services are up
        /// </summary>
        /// <returns>I'm Alive if the services are up</returns>
        /// 
        public string getStatus()
        {
            return "I'm Alive!!!!";
        }

        /// <summary>
        /// Get all the information without filters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Students/GetAllData")]
        public HttpResponseMessage GetAllData()
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> students = studentsMock.GetMockData();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpGet]
        [Route("api/Students/GetMarksUp80")]
        public HttpResponseMessage GetMarksUp80()
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> results = new List<Models.RegisterModel>();
            List<Models.RegisterModel> students = studentsMock.GetMockData();

            results = (from student in students
                       where student.LanguageAndArts > 80 || student.Maths > 80 || student.Science > 80 || student.SocialStudies > 80
                       select student).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpGet]
        [Route("api/Students/GetRecByField")]
        public HttpResponseMessage GetRecByField(string Mark, string Value)
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> results = new List<Models.RegisterModel>();
            List<Models.RegisterModel> students = studentsMock.GetMockData();
            switch (Mark)
            {
                case "Student":
                    results = (from student in students
                               where student.Student == Value
                               select student).ToList();
                    break;
                case "LanguageAndArts":
                    results = (from student in students
                               where student.LanguageAndArts == int.Parse(Value)
                               select student).ToList();
                    break;
                case "Science":
                    results = (from student in students
                               where student.Science == int.Parse(Value)
                               select student).ToList();
                    break;
                case "SocialStudies":
                    results = (from student in students
                               where student.SocialStudies == int.Parse(Value)
                               select student).ToList();
                    break;
                case "Maths":
                    results = (from student in students
                               where student.Maths == int.Parse(Value)
                               select student).ToList();
                    break;
                default:
                    results = students;
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        /// <summary>
        /// Get all the information without filters
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Students/GetAll")]
        public HttpResponseMessage GetAll()
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> students = studentsMock.GetMockData();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        /// <summary>
        /// returns filtered by Mark if the record has it's mark upper 80
        /// </summary>
        /// <param name="mark">Mark to filter</param>
        /// <returns>Array of Records filtered by mark</returns>
        [HttpPost]
        [Route("api/Students/GetMarksUpper80")]
        public HttpResponseMessage GetMarksUpper80()
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> results = new List<Models.RegisterModel>();
            List<Models.RegisterModel> students = studentsMock.GetMockData();

            results = (from student in students
                      where student.LanguageAndArts > 80 || student.Maths > 80 || student.Science > 80 || student.SocialStudies > 80
                       select student).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        /// <summary>
        /// Gets the information filtered by an specific field
        /// </summary>
        /// <param name="filter">Mark is the field name and Value is the value</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Students/GetByField")]
        public HttpResponseMessage GetByField(Models.SingleFilter filter)
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> results = new List<Models.RegisterModel>();
            List<Models.RegisterModel> students = studentsMock.GetMockData();
            switch (filter.Mark)
            {
                case "Student":
                    results = (from student in students
                               where student.Student == filter.Value
                               select student).ToList();
                    break;
                case "LanguageAndArts":
                    results = (from student in students
                               where student.LanguageAndArts == int.Parse(filter.Value)
                               select student).ToList();
                    break;
                case "Science":
                    results = (from student in students
                               where student.Science == int.Parse(filter.Value)
                               select student).ToList();
                    break;
                case "SocialStudies":
                    results = (from student in students
                               where student.SocialStudies == int.Parse(filter.Value)
                               select student).ToList();
                    break;
                case "Maths":
                    results = (from student in students
                               where student.Maths == int.Parse(filter.Value)
                               select student).ToList();
                    break;
                default:
                    results = students;
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        /// <summary>
        /// Retrieve records with a combination of more filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Students/GetByFiters")]
        public HttpResponseMessage GetByFilters(string Student, 
            int LanguageAndArts, 
            int Science, 
            int SocialStudies,
            int Maths)
        {
            Models.StudentsMock studentsMock = new Models.StudentsMock();
            List<Models.RegisterModel> results = new List<Models.RegisterModel>();
            List<Models.RegisterModel> students = studentsMock.GetMockData();
            
            return Request.CreateResponse(HttpStatusCode.OK, Filter(results,Student,LanguageAndArts,Science,SocialStudies,Maths));
        }


        private List<Models.RegisterModel> Filter(List<Models.RegisterModel> records,
            string student,
            int languageAndArts,
            int science,
            int socialStudies,
            int maths)
        {
            if (student != string.Empty) records = records.Where(r => r.Student == student).ToList();
            if (languageAndArts != -1) records = records.Where(r => r.LanguageAndArts == languageAndArts).ToList();
            if (science != -1) records = records.Where(r => r.Science == science).ToList();
            if (socialStudies != -1) records = records.Where(r => r.SocialStudies == socialStudies).ToList();
            if (maths != -1) records = records.Where(r => r.Maths == maths).ToList();

            return records;
        }


    }
}
