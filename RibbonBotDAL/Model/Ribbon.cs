using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace RibbonBotDAL.Model
{
    [Dapper.Contrib.Extensions.Table("eponaRibbon.ribbon")]
    public class Ribbon
    {
        [Key]
        public long id { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("description")]
        public string? description { get; set; }

        [Column("path")]
        public string? path { get; set; }
    }
}
