using Dapper.Contrib.Extensions;

namespace RibbonBotDAL.Model
{
    [Table("eponaRibbon.pets")]
    public class Pets
    { 
        public long id { get; set; }
        public string? childlink { get; set; }
        public string? adultlink { get; set; }
    }
}
