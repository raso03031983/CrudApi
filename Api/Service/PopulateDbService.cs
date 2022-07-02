using Data.PopulateDB.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PopulateDbService : IPopulateDbService
    {
        private readonly IPopulateDB _populateDB;
        public PopulateDbService(IPopulateDB populateDB)
        {
            _populateDB = populateDB;
        }

        public void PopulateTables()
        {
            _populateDB.PopulateTables();
        }
    }
}
