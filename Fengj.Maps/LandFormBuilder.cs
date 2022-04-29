using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    internal class LandFormBuilder
    {
        internal static Dictionary<AxialCoordinate, LandForm> Build(IEnumerable<AxialCoordinate> axialCoords, Dictionary<LandForm, int> landFormPercent)
        {
            var dict = new Dictionary<AxialCoordinate, LandForm>();

            BuildWater(axialCoords, ref dict, landFormPercent[LandForm.Water]);
            //foreach (var axialCoord in axialCoords.Except(dict.Keys))
            //{
            //    dict.Add(axialCoord, LandForm.Plain);
            //}
            return dict;
        }

        private static void BuildWater(IEnumerable<AxialCoordinate> axialCoords, ref Dictionary<AxialCoordinate, LandForm> dict, int percent)
        {
            float[] random = { 0.001f, 0.1f, 0.2f, 0.3f, 0.5f, 0.7f, 0.9f };

            BuildLandForm(axialCoords, ref dict, LandForm.Water, random, percent);
        }

        private static void BuildLandForm(IEnumerable<AxialCoordinate> axialCoords, ref Dictionary<AxialCoordinate, LandForm> dict, LandForm landForm, float[] randoms, int percent)
        {

            var local = dict;

            while(true)
            {
                var emptyAxialCoords = axialCoords.Except(local.Keys).ToArray();

                foreach (var axialCoord in emptyAxialCoords)
                {
                    var neighborCount = axialCoord.GetNeighbors().Count(n => local.ContainsKey(n) && local[n] == landForm);

                    if (!GRandom.IsPercentOccur(randoms[neighborCount]))
                    {
                        continue;
                    }

                    local.Add(axialCoord, landForm);

                    if (local.Values.Count(x => x == landForm) == percent * axialCoords.Count() / 100)
                    {
                        return;
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
            float labelNum = percent * 10000;
            if(labelNum < 1)
            {
                return false;
            }

            float randomNum = rand.Next(0, 10000);

            return !(randomNum - labelNum > 0f);
        }
    }
}
