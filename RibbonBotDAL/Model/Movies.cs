using Dapper.Contrib.Extensions;

namespace RibbonBotDAL.Model
{
    [Table("eponaRibbon.movies")]
    public class Movies
    {
        public long id { get; set; }
        public string movie { get; set; }
        public string? requestedby { get; set; }
        public bool watched { get; set; } = false;
        public string? genre { get; set; }
    }
}
