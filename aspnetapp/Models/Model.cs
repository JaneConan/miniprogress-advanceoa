namespace aspnetapp
{
    public class Counter
    {
        public int id { get; set; }
        public int count { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
    
    public class Menu
    {
        public int id { get; set; }
        public string MenuName { get; set; }
        public string MenuEname { get; set; }
        public string MenuDetail { get; set; }
        public string icon { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}