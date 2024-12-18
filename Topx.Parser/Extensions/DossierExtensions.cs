﻿using System;
using System.Linq;
using Topx.Data;

namespace Topx.Creator.Extensions
{
    public static class DossierExtensions
    {
        public static bool IsElementEmpty(this Dossier dossier, string fieldNameStart)
        {
            var properties = typeof(Dossier).GetProperties().Where(p => p.Name.StartsWith(fieldNameStart, StringComparison.OrdinalIgnoreCase));

            foreach (var property in properties)
            {
                var value = property.GetValue(dossier) as string;
                if (!string.IsNullOrEmpty(value)) return false;
            }

            return true;
        }

        public static bool IsElementEmptyOrComplete(this Dossier dossier, string fieldNameStart)
        {
            var properties = typeof(Dossier).GetProperties().Where(p => p.Name.StartsWith(fieldNameStart, StringComparison.OrdinalIgnoreCase)) .ToList();
            int count = 0;
            
            foreach (var property in properties)
            {
                var value = property.GetValue(dossier) as string;
                if (string.IsNullOrEmpty(value))
                {
                    count++;
                }
            }
            if (count == 0)
                return true;  // empty element
            return count == properties.Count; // true if element is complete filled
        }
    }
}
