﻿using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    internal class LandFormBuilder
    {
        internal static Dictionary<AxialCoordinate, LandForm> Build(IEnumerable<AxialCoordinate> axialCoords, Dictionary<LandForm, int> landFormPercent)
        {
            var dict = new Dictionary<AxialCoordinate, LandForm?>();
            foreach(var axialCoord in axialCoords.OrderBy(_=> GRandom.Get()))
            {
                dict.Add(axialCoord, null);
            }

            BuildWater(ref dict, landFormPercent[LandForm.Water]);
            BuildHill(ref dict, landFormPercent[LandForm.Hill]);
            BuildMount(ref dict);

            foreach (var pair in dict.Where(x=>x.Value == null).ToArray())
            {
                dict[pair.Key] = LandForm.Plain;
            }

            return dict.Where(p => p.Value != null).ToDictionary(p => p.Key, p => p.Value.Value);
        }

        private static void BuildMount(ref Dictionary<AxialCoordinate, LandForm?> dict)
        {
            var local = dict;

            var emptyAxialCoords = local.Keys.Where(k => local[k] == LandForm.Hill).ToArray();

            var hillCount = emptyAxialCoords.Count();

            while(true)
            {
                var groups = emptyAxialCoords.GroupBy(x => x.GetNeighbors().Count(n => local.ContainsKey(n) && local[n] == LandForm.Hill));
                foreach (var group in groups.OrderByDescending(x => x.Key))
                {
                    foreach(var axialCoord in group)
                    {
                        local[axialCoord] = LandForm.Mount;

                        if (local.Values.Count(x => x == LandForm.Mount) == hillCount * 20 / 100)
                        {
                            return;
                        }
                    }

                }
            }

        }

        private static void BuildHill(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent)
        {
            float[] random = { 0.001f, 0.8f, 0.6f, 0.3f, 0.3f, 0.6f, 0.8f };

            BuildLandForm(ref dict, LandForm.Hill, random, percent);
        }

        private static void BuildWater(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent)
        {
            float[] random = { 0.0005f, 0.3f, 0.5f, 0.5f, 0.7f, 0.8f, 0.9f };

            BuildLandForm(ref dict, LandForm.Water, random, percent);
        }

        private static void BuildLandForm(ref Dictionary<AxialCoordinate, LandForm?> dict, LandForm landForm, float[] randoms, int percent)
        {
            var local = dict;

            while(true)
            {
                var emptyAxialCoords = local.Keys.Where(k=> local[k] == null).ToArray();

                foreach (var axialCoord in emptyAxialCoords)
                {
                    var neighborCount = axialCoord.GetNeighbors().Count(n => local.ContainsKey(n) && local[n] == landForm);

                    if (!GRandom.IsPercentOccur(randoms[neighborCount]))
                    {
                        continue;
                    }

                    local[axialCoord] = landForm;

                    if (local.Values.Count(x => x == landForm) == percent * local.Count() / 100)
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

        internal static int Get()
        {
            return rand.Next(0, 10000);
        }

        internal static bool IsPercentOccur(float percent)
        {
            float labelNum = percent * 10000;
            if(labelNum < 1)
            {
                return false;
            }

            if (labelNum > 10000)
            {
                return true;
            }

            float randomNum = rand.Next(0, 10000);

            return !(randomNum - labelNum > 0f);
        }
    }
}
