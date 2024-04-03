namespace LMS.Models {
    public class ContentItem {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public ContentItem() {
            guid = Guid.NewGuid();
            Name = "";
            Description = "";
            Path = "";
        }
    }
}