namespace LMS.Models {
    public class ContentItem {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public ContentItem() {
            Name = "";
            Description = "";
            Path = "";
        }
    }
}