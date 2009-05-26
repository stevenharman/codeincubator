using System.Collections.Generic;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Models
{
    public static class ModelExtensions
    {
        public static AssaultItemDetailModel ToDetailModel(this AssaultItem item)
        {
            var m = new AssaultItemDetailModel
            {
                Id = item.Id,
                Description = item.Description,
                Type = item.Type,
                LoadValue = item.LoadValue,
                Images = new List<string>()
            };

            var keywords = new Dictionary<string, string>
                               {
                                   {"Shock", "Shock_trooper_icon.png"},
                                   {"Scout", "Scout_trooper_icon.png"},
                                   {"Dark", "Dark_trooper_icon.png"},
                                   {"Storm", "Stormtrooper_icon.png"},
                                   {"AT-ST", "at_st.jpg"},
                                   {"Bike", "speeder_bike.jpg"},
                                   {"Blaster", "heavy_blaster.jpg"}
                               };

            if (item.Description != null)
            {
                foreach (var k in keywords)
                {
                    if (item.Description.ToLower().Contains(k.Key.ToLower()))
                    {
                        m.Images.Add(k.Value);
                    }
                }
            }

            return m;
        }
    }
}