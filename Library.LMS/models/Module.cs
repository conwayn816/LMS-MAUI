namespace LMS.Models {
    public class Module {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ContentItem> Content { get; set; }

        public Module() {
            guid = Guid.NewGuid();
            Name = "";
            Description = "";
            Content = new List<ContentItem>();
        }
    }
}