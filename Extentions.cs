using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace MyLabyrinth
{
    public static partial class Extentions
    {
        public static int LineLength(this string self)
        {
            return self.Length;
        }
		
        public static Dictionary<T, int> ElementFrequency<T>(this List<T> self)
        {
            Dictionary<T, int> frequency = new Dictionary<T, int>();

            for (int i = 0; i < self.Count; i++)
            {
                if (frequency.ContainsKey(self[i]))
                {
                    frequency[self[i]]++;
                }
                else
                {
                    frequency.Add(self[i], 1);
                }
            }

            return frequency;
        }
		
        public static Dictionary<T, int> ElementFrequencyLinq<T>(this List<T> self)
        {
            var temporaryFrequency = self.GroupBy(u => u).
                Select(u => new {u.Key, Count = u.Count()});
            var frequency = temporaryFrequency.
                ToDictionary(u => u.Key, u => u.Count);
            return frequency;
        }

        public static Single ToSingle(this string self)
        {
            return Convert.ToSingle(self);
        }
        
        public static bool ToBool(this string self)
        {
            return Convert.ToBoolean(self);
        }
    }
}

