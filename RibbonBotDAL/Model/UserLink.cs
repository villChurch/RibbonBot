using Dapper.Contrib.Extensions;

namespace RibbonBotDAL.Model;

public class UserLink
{
    [Key]
    public long id { get; set; }

    public string discordid { get; set; }
    
    public string code { get; set; }
}