using System.Collections.Generic;
using System.Text;
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

        public static string ToDetailHtml(this AssaultItemDetailModel item)
        {
            var sb = new StringBuilder();

            sb.Append("<ul><li>");

            foreach (var image in item.Images)
                sb.Append("<img src=\"../../Content/Images/").Append(image).Append("\" />");

            sb.Append("</li>");
            sb.Append("<li><strong>Type:</strong> ").Append(item.Type).Append("</li>");
            sb.Append("<li><strong>Description:</strong> ").Append(item.Description).Append("</li>");
            sb.Append("<li><strong>Load Value:</strong> ").Append(item.LoadValue).Append("</li>");

            sb.Append("</ul>");

            return sb.ToString();
        }
    }
}