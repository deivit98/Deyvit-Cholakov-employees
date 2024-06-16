using LibraryHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryHelper
{
    public static class HighestPairFinder
    {
        public static List<object> GetHighestPair(List<FileInput> empl, bool shouldAddProject = false)
        {
            var pairs = new Dictionary<string, List<object>>();
            var daysTogether = new Dictionary<string, int>();

            if (empl != null)
            {
                for (int i = 0; i < empl.Count; i++)
                {
                    for (int j = i + 1; j < empl.Count; j++)
                    {
                        var el1 = empl[i];
                        var el2 = empl[j];

                        if (el1.EmployeeID != el2.EmployeeID)
                        {
                            var startDate1 = el1.StartDate;
                            var endDate1 = el1.EndDate;
                            var startDate2 = el2.StartDate;
                            var endDate2 = el2.EndDate;

                            if (el1.ProjectID == el2.ProjectID)
                            {
                                if (startDate1 <= endDate2 && startDate2 <= endDate1)
                                {
                                    var start = startDate1 <= startDate2 ? startDate2 : startDate1;
                                    var end = endDate1 <= endDate2 ? endDate1 : endDate2;

                                    if (end >= startDate2)
                                    {
                                        var diffTime = (end - start).TotalDays;
                                        var diffDays = (int)Math.Ceiling(diffTime);
                                        var key = $"{el1.EmployeeID}{el2.EmployeeID}";

                                        if (!daysTogether.ContainsKey(key))
                                        {
                                            daysTogether[key] = 0;
                                        }

                                        daysTogether[key] += diffDays;

                                        if (!pairs.ContainsKey(key))
                                        {
                                            pairs[key] = new List<object>();
                                        }

                                        if (shouldAddProject)
                                        {
                                            pairs[key].Add(new
                                            {
                                                EmployeeID1 = el1.EmployeeID,
                                                EmployeeID2 = el2.EmployeeID,
                                                ProjectID = el1.ProjectID,
                                                DaysWorked = diffDays
                                            });
                                        }
                                        else
                                        {
                                            pairs[key].Add(new
                                            {
                                                EmployeeID1 = el1.EmployeeID,
                                                EmployeeID2 = el2.EmployeeID,
                                                DaysWorked = diffDays
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var maxPairKey = daysTogether.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            return pairs[maxPairKey];
        }
    }
}
