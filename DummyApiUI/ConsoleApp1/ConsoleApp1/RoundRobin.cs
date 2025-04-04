using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RoundRobin
    {
        private readonly IList<String> listofServers;
        private readonly int size;
        private int position;

        public RoundRobin(List<string> servers)
        {
            listofServers = servers;
            size = listofServers.Count;
        }

        public string Next()
        {
            if (size == 1)
                return listofServers[0];

           
            var mod = position % size;
            Interlocked.Increment(ref position);
            return listofServers[mod];
        }
        public void PerformLoadBalance()
        {
            Next();
        }
    }
}
