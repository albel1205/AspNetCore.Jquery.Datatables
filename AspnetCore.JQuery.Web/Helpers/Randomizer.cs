using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.JQuery.Web.Helpers
{
    public class Randomizer
    {
        private Random random = null;

        public static Randomizer Instance { get; } = new Randomizer();

        public Randomizer()
        {
            this.random = new Random();
        }

        public int RandomInt()
        {
            return this.random.Next();
        }

        public int RandomInt(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
