namespace aspnetapp
{
    /// <summary>
    /// 
    /// </summary>
    public class Counter
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createdAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime updatedAt { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MenuNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? MenuName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? MenuEname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? MenuDetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? herf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime createdAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime updatedAt { get; set; }
    }
}