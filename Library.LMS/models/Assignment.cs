namespace LMS.Models {
    public class Assignment {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment() {
            guid = Guid.NewGuid();
            Name = "";
            Description = "";
            TotalAvailablePoints = 0;
            DueDate = DateTime.Now;
        }
        public override string ToString()
        {
            return $"({DueDate}) {Name}";
        }
    }
}