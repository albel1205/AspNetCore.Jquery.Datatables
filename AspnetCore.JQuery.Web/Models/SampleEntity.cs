using AspnetCore.JQuery.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.JQuery.Datatables.Models
{
    public class SampleEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDirty { get; set; }

        public int Count { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public SampleEntity RandomizeInstance()
        {
            return new SampleEntity()
            {
                Id = Guid.NewGuid(),
                Name = Randomizer.Instance.RandomStringWithNumberSuffix("test"),
                IsDirty = true,
                Count = Randomizer.Instance.RandomInt(),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
        }
    }
}
