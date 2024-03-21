using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MAUI.LearningManagement.ViewModels
{
    public class InstructorViewViewModel
    {
        private IEnumerable<string> students;
        public IEnumerable<string> Students { 
            get
            {
                return students;
            } 
        }

        public InstructorViewViewModel()
        {
            students = new List<string>
            {
                "John Doe",
                "Jane Doe",
                "John Smith",
                "Jane Smith"
            };
        }
    }

}
