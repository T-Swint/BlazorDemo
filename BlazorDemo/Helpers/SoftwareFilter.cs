using BlazorDemo.Data;
using BlazorDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Helpers
{
    public class SoftwareFilter
    {
        public static List<Software> FilterSoftware(string s)
        {
            var formattedInput = KeepFirstOccurance(s, '.').Replace(" ", string.Empty);
            var filteredList = new List<Software>();
            var response = SoftwareManager.GetAllSoftware();
            foreach (var item in response)
            {
                var tempVersion = KeepFirstOccurance(item.Version, '.').Replace(" ", string.Empty);
                if (decimal.Parse(tempVersion) >= decimal.Parse(formattedInput))
                    filteredList.Add(item);
            }
            return filteredList;
        }
        public static string KeepFirstOccurance(string str, char c)
        {
            try
            {
                //add a decimal to prevent exception if none is entered
                //TODO update Regex to account for this
                if (!str.Contains("."))
                    str = str.Replace(str, str + ".");
                
                int position = str.IndexOf(c);
                return str.Substring(0, position + 1) +
                str.Substring(position, str.Length - position)
                .Replace(c, ' ').Trim();
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                return (e.Message + "Error");
            }
          
        }
    }
}
