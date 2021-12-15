using Notlarım101.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static NotlarimContext db;
        private static object _lockSync = new object();

        public RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (db == null)
            {
                lock (_lockSync) //Birden fazla contex gönderme durumu olursa birbirlerini bozmasın diye kurduğumuz bir yapıdır.
                {
                    if (db == null)
                    {
                        db = new NotlarimContext();
                    }
                }
            }
        }

    }


}
