﻿using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    internal class LandFormBuilder
    {
        internal static Dictionary<AxialCoordinate, LandForm> Build(MapInit init, AxialCoordinate[] rivers)
        {
            var centerSector = new AxialCoordinate(0, 0).GetSector(3);

            var dict = new Dictionary<AxialCoordinate, LandForm?>();
            foreach(var axialCoord in HexBuilder.Build(init.size).Where(x=>!centerSector.Contains(x)).OrderBy(_=>GRandom.Get()))
            {
                dict.Add(axialCoord, null);
            }

            var riverBank = rivers.SelectMany(x => x.GetRiverBank(init.size)).Distinct().ToArray();
            var waterSeeds = riverBank.OrderBy(_ => GRandom.Get()).Take(3).ToArray();

            BuildWater(ref dict, init.landFormPercent[LandForm.Water], waterSeeds);
            BuildHill(ref dict, init.landFormPercent[LandForm.Hill] + init.landFormPercent[LandForm.Mount]);
            BuildMount(ref dict, init.landFormPercent[LandForm.Mount], riverBank);
            BuildMarsh(ref dict, init.landFormPercent[LandForm.Marsh], riverBank);

            foreach (var axialCoord in dict.Where(x=>x.Value == null).Select(x=>x.Key).Concat(centerSector).ToArray())
            {
                dict[axialCoord] = LandForm.Plain;
            }

            return dict.Where(p => p.Value != null).ToDictionary(p => p.Key, p => p.Value.Value);
        }

        private static void BuildMarsh(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent, AxialCoordinate[] riverBank)
        {
            var local = dict;

            while (true)
            {
                var waterAxialCoords = local.Keys.Where(k => local[k] == LandForm.Water || local[k] == LandForm.Marsh || riverBank.Contains(k)).ToArray();

                foreach (var axialCoord in waterAxialCoords.SelectMany(w => w.GetNeighbors().Where(n => local.ContainsKey(n) && local[n] == null)))
                {
                    if(axialCoord.GetNeighbors().Any(x=> local.ContainsKey(x) && (local[x] == LandForm.Hill || local[x] == LandForm.Mount)))
                    {
                        continue;
                    }

                    if (GRandom.IsPercentOccur(1))
                    {
                        local[axialCoord] = LandForm.Marsh;

                        if (local.Values.Count(x => x == LandForm.Marsh) == percent* local.Count() / 100)
                        {
                            return;
                        }
                    }
                }
            }

        }

        private static void BuildMount(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent, AxialCoordinate[] riverBank)
        {
            var local = dict;

            var HillAxialCoords = local.Keys.Where(k => local[k] == LandForm.Hill && !riverBank.Contains(k)).ToArray();

            while(true)
            {
                var groups = HillAxialCoords.GroupBy(x => x.GetNeighbors().Count(n => local.ContainsKey(n) && local[n] == LandForm.Hill));
                foreach (var axialCoord in groups.OrderByDescending(x => x.Key).SelectMany(x=>x))
                {
                    local[axialCoord] = LandForm.Mount;

                    if (local.Values.Count(x => x == LandForm.Mount) == percent * local.Count() / 100)
                    {
                        return;
                    }

                }
            }

        }

        private static void BuildHill(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent)
        {
            float[] random = { 0.01f, 0.8f, 0.6f, 0.3f, 0.3f, 0.6f, 0.8f };

            BuildLandForm(ref dict, LandForm.Hill, random, percent);
        }

        private static void BuildWater(ref Dictionary<AxialCoordinate, LandForm?> dict, int percent, AxialCoordinate[] waterSeeds)
        {
            float[] random = { 0.001f, 0.1f, 0.5f, 0.5f, 0.7f, 0.8f, 0.9f };

            foreach(var waterSeed in waterSeeds)
            {
                dict[waterSeed] = LandForm.Water;
            }

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
