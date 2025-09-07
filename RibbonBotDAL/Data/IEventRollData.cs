using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public interface IEventRollData
{
    Task<List<EventRoll>> GetEventRolls();
    Task SaveEventRoll(EventRoll eventRoll);
    Task DeleteEventRoll(EventRoll eventRoll);
    Task UpdateEventRoll(EventRoll eventRoll);
}