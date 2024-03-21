namespace LMS.Models {
    public class Module {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ContentItem> Content { get; set; }

        public Module() {
            Name = "";
            Description = "";
            Content = new List<ContentItem>();
        }
    }
}