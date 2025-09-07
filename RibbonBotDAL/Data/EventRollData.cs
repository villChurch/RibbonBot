using Dapper.Contrib.Extensions;
using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public class EventRollData(ISqlDataAccess db) : IEventRollData
{
    public async Task<List<EventRoll>> GetEventRolls()
    {
        var res = await db.LoadData<EventRoll, dynamic>("SELECT * FROM eponaribbon.eventrolls", new { });
        return res.ToList();
    }

    public async Task SaveEventRoll(EventRoll eventRoll)
    {
        await db.SaveData("insert into eponaribbon.eventrolls (eventtype, event, eventoutput)" +
                          "values (@eventtype, @eventname, @eventoutput)", new
        {
            eventRoll.eventtype,
            eventname = eventRoll.Event,
            eventRoll.eventoutput
        });
    }

    public async Task DeleteEventRoll(EventRoll eventRoll)
    {
        await db.DeleteData("delete from eponaribbon.eventrolls where id = @id", new { eventRoll.id });
    }

    public async Task UpdateEventRoll(EventRoll eventRoll)
    {
        await db.SaveData("update eponaribbon.eventrolls set event = @eventname, eventoutput = @eventoutput, eventtype = @eventtype where id = @id",
            new { eventname = eventRoll.Event, eventoutput = eventRoll.eventoutput, eventtype = eventRoll.eventtype, id = eventRoll.id });
    }
}