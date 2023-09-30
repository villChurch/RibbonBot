using RibbonBotDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonBotDAL.Data
{
    public interface IRibbonData
    {
        Task<IEnumerable<Ribbon>> GetAllRibbons();

        Task<Ribbon> GetRibbon(long id);

        Task<Ribbon> GetRibbon(string name);

        Task<IEnumerable<Ribbon>> GetUsersRibbons(string user);
    }
}
