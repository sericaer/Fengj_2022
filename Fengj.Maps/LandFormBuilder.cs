using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    internal class LandFormBuilder
    {
        internal static Dictionary<AxialCoordinate, LandForm> Build(IEnumerable<AxialCoordinate> axialCoords)
        {
            var dict = new Dictionary<AxialCoordinate, LandForm>();

            BuildWater(axialCoords, ref dict);
            foreach(var axialCoord in axialCoords.Except(dict.Keys))
            {
                dict.Add(axialCoord, LandForm.Plain);
            }
            return dict;
        }

        private static void BuildWater(IEnumerable<AxialCoordinate> axialCoords, ref Dictionary<AxialCoordinate, LandForm> dict)
        {
            float[] random = { 1f, 0.1f, 0.15f, 0.3f, 0.5f, 0.9f };

            BuildLandForm(axialCoords, ref dict, LandForm.Water, random);
        }

        private static void BuildLandForm(IEnumerable<AxialCoordinate> axialCoords, ref Dictionary<AxialCoordinate, LandForm> dict, LandForm landForm, float[] randoms)
        {

            var local = dict;

            var iterCount = 1;
            for(int i=0; i< iterCount; i++)
            {
                var emptyAxialCoords = axialCoords.Except(dict.Keys).ToArray();

                foreach (var axialCoord in emptyAxialCoords)
                {
                    var neighbors = axialCoord.GetNeighbors();
                    var count = neighbors.Count(x => local.ContainsKey(x) && local[x] == landForm);
                    var random = randoms[count] / iterCount;

                    if(GRandom.IsPercentOccur(random))
                    {
                        dict.Add(axialCoord, landForm);
                    }
                }
            }
        }
    }

    public class GRandom
    {
        static Random rand { get; } = new Random(System.Guid.NewGuid().GetHashCode());

        internal static bool IsPercentOccur(float percent)
        {
            int labelNum = (int)Math.Ceiling(percent * 10000);

            int randomNum = rand.Next(0, 10000);

            return randomNum <= labelNum;
        }
    }
}
