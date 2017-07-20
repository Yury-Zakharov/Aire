using Aire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aire.Data
{
    class SqlLocalDataProvider : IDataProvider
    {
        public void AddApplication(LoopApplication application)
        {
            using (var db = new LoopData())
            {
                db.Applications.Add(application);
                try
                {
                    var result = db.SaveChanges();
                }
                catch (Exception)
                {
                    // do nothing, I don't care for duplicates for now...
                    // use normal logger here...
                    Console.WriteLine($"Duplicate record. Id:{application.a}");
                }
            }
        }

        public IEnumerable<LoopApplication> GetApplications()
        {
            using (var db = new LoopData())
            {
                return db.Applications.ToList().AsEnumerable();
            }

        }
    }
}
