using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.JQuery.Web.Helpers
{
    public static class RandomizerExtensions
    {
        public static string RandomStringWithNumberSuffix(this Randomizer randomizer, string strBase)
        {
            return strBase + randomizer.RandomInt();
        }
    }
}
