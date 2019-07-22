using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class StudentsMock
    {
        public List<RegisterModel> Students { get; set; }

        public List<RegisterModel> GetMockData()
        {
            Students = new List<RegisterModel>();
            Students.Add(new RegisterModel("Anna Taylor",90,85,86,89));
            Students.Add(new RegisterModel("Mark Smith", 82, 75, 89, 86));
            Students.Add(new RegisterModel("John Doe", 89, 76, 94, 82));
            Students.Add(new RegisterModel("Jack Jones", 93, 73, 97, 90));
            Students.Add(new RegisterModel("Melody Queens", 87, 89, 80, 83));
            Students.Add(new RegisterModel("Noah Menac", 86, 90, 83, 85));
            return Students;
        }

    }
}