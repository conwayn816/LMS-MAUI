namespace LMS.Models
{
    public class Submission
    {
        public Guid guid { get; set; }
        public string Content { get; set; }
        public Guid studentGuid { get; set; }
        public decimal Points { get; set; }

        public Submission()
        {
            guid = Guid.NewGuid();
            Content = "";
            studentGuid = Guid.Empty;
            Points = 0;
        }
        public override string ToString()
        {
            return $"{Content} ({Points})";
        }
    }
}