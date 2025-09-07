using System.ComponentModel.DataAnnotations.Schema;

namespace RibbonBotDAL.Model;
public class EventRoll
{
    public long id { get; set; }
    public string eventtype { get; set; }
    public string Event { get; set; }
    public string eventoutput { get; set; }
}