using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WeightedRoundRobin
    {
        List<string> availableServersList;
        List<int> weightToHold;
        int currentIndex;
        int currentWeight;

        public WeightedRoundRobin(List<string> servers, List<int> weight)
        {
            availableServersList = servers;
            this.weightToHold = weight;
            currentIndex = -1;
            currentWeight = 0;
        }

        public string GetNextServer()
        {
            while (true)
            {
                currentIndex = (currentIndex + 1) % availableServersList.Count();
                if (currentIndex == 0)
                {
                    currentWeight--;
                }
                if (currentWeight <= 0)
                {
                    currentWeight = getMaxWeight();
                }
                if (weightToHold[currentIndex] >= currentWeight)
                {
                    return availableServersList[currentIndex];
                }
            }
        }
        private int getMaxWeight()
        {
            return weightToHold.DefaultIfEmpty(0).Max();
        }
    }
}
