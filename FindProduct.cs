using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_8_2
{
    class FindProduct
    {
        static public List<Prod> Intersection<Prod>(List<Prod> List1, List<Prod> List2)
        {
            List<Prod> intersection = new List<Prod>();

            for(int i = 0; i < List1.Count; i++)
            {
                for(int j = 0; j < List2.Count; j++)
                {
                    if(List1[i].Equals(List2[j]) && !intersection.Contains(List1[i]))
                    {
                        intersection.Add(List1[i]);
                    }
                }
            }

            return intersection;
        }

        static public List<Prod> DifferenceFirstStorage<Prod>(List<Prod> List1, List<Prod> List2)
        {
            List<Prod> difference = new List<Prod>();

            for (int i = 0; i < List1.Count; i++)
            {
               if(!List2.Contains(List1[i]))
               {
                   difference.Add(List1[i]);
               }
            }

            return difference;
        }

        static public List<Prod> Difference<Prod>(List<Prod> List1, List<Prod> List2)
        {
            List<Prod> difference = new List<Prod>();

            for(int i = 0; i < List1.Count; i++)
            {
                if (!List2.Contains(List1[i]))
                {
                    difference.Add(List1[i]);
                }
            }

            for(int i = 0; i < List2.Count; i++)
            {
                if (!List1.Contains(List2[i]))
                {
                    difference.Add(List2[i]);
                }
            }

            return difference;
        }
    }
}
