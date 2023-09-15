namespace RibbonBotDAL.Model
{
    public class Movies
    {
        public long id { get; set; }
        public string movie { get; set; }
        public string? requestedBy { get; set; }
        public bool watched { get; set; } = false;
        public string? genre { get; set; }
    }
}
