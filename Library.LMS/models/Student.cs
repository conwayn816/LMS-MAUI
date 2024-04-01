namespace LMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentClassifcation Classification { get; set; }
        public Dictionary<Guid, double> Grades { get; set; }

        public Student()
        {
            Name = "";
            Grades = new Dictionary<Guid, double>();
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
    }

    public enum StudentClassifcation
    {
        Freshman, Sophomore, Junior, Senior
    }
}