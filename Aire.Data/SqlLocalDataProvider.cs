using Aire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aire.Data
{
    class SqlLocalDataProvider : IDataProvider
    {
        public void AddApplication(LoopApplication application)
        {
            using (var db = new LoopModel())
            {
                db.Applications.Add(application);
                // todo: check the result.
              var result=  db.SaveChanges();
            }
        }

        public IEnumerable<LoopApplication> GetApplications()
        {
            using (var db = new LoopModel())
            {
                return db.Applications.ToList().AsEnumerable();
            }
            
        }
    }
}
