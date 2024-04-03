namespace LMS.Models {
    public class Course {
        public Guid guid { get; set; }
        public string Code { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Student> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public Course() {
            guid = Guid.NewGuid();
            Code = "";
            Name = "";
            Description = "";
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public override string ToString() 
        {
            return $"[{Code}] {Name}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description}\n\n" +
                $"Roster:\n{string.Join("\n", Roster.Select(s => s.ToString()).ToArray())}\n\n" +
                $"Assignments:\n{string.Join("\n", Assignments.Select(a => a.ToString()).ToArray())}\n\n";
            }
        }
    }
}