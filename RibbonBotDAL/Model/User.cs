using Dapper.Contrib.Extensions;

namespace RibbonBotDAL.Model;

[Table("eponaRibbon.users")]
public class User
{
    [Key]
    public long id { get; set; }
    
    public string name { get; set; }
    
    public string role { get; set; } = "user"; 
    
    public string discordid { get; set; }
    
}