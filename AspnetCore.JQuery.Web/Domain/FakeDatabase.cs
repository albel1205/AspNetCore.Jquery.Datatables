using AspnetCore.JQuery.Datatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.JQuery.Web.Domain
{
    public class FakeDatabase
    {
        public List<SampleEntity> Entities;

        private static FakeDatabase instance = null;

        public static FakeDatabase Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FakeDatabase();
                }
                return instance;
            }
        }

        private FakeDatabase()
        {
            this.Entities = new List<SampleEntity>();
            for(int i = 0; i< 10; i++)
            {
                this.Entities.Add(new SampleEntity().RandomizeInstance());
            }
        }
    }
}
