using Microsoft.Phone.Globalization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using XBMCRemoteWP.Models.Common;

namespace XBMCRemoteWP.Helpers
{
    public class GroupingHelper
    {
        public delegate string GetNameDelegate<T>(T item);

        private static string GetTrimmedName(string itemName)
        {
            if (itemName.StartsWith("a ", StringComparison.InvariantCultureIgnoreCase))
            {
                itemName = itemName.Remove(0, 2);
            }
            else if (itemName.StartsWith("an ", StringComparison.InvariantCultureIgnoreCase))
            {
                itemName = itemName.Remove(0, 3);
            }
            else if (itemName.StartsWith("the ", StringComparison.InvariantCultureIgnoreCase))
            {
                itemName = itemName.Remove(0, 4);
            }
            return itemName;
        }

        public static List<ListGroup<T>> GroupList<T>(IEnumerable<T> listToGroup, GetNameDelegate<T> getName, bool sort)
        {
            List<ListGroup<T>> groupedList = new List<ListGroup<T>>();
            SortedLocaleGrouping slg = new SortedLocaleGrouping(CultureInfo.InvariantCulture);
            foreach (string key in slg.GroupDisplayNames)
            {
                groupedList.Add(new ListGroup<T>(key));
            }

            foreach (T item in listToGroup)
            {
                string itemName = GetTrimmedName(getName(item));                

                int index = slg.GetGroupIndex(itemName);
                if (index >= 0 && index < groupedList.Count)
                {
                    groupedList[index].Add(item);
                }
            }

            if (sort)
            {
                foreach (ListGroup<T> group in groupedList)
                {
                    group.Sort((c0, c1) => { return CultureInfo.InvariantCulture.CompareInfo.Compare(GetTrimmedName(getName(c0)), GetTrimmedName(getName(c1))); });
                }
            }

            return groupedList;
        }
    }
}
