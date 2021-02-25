using System.Collections.Generic;

namespace CMS.Domain.Tests.Helpers
{
    public static class HelperBase
    {
        public static bool CheckListsMatch<T>(HashSet<T> initialArray, HashSet<T> receivedArray)
        {
            var arraysMatch = true;

            foreach (var arrayElement in initialArray)
            {
                if (!receivedArray.Contains(arrayElement))
                {
                    arraysMatch = false;
                }
            }

            return arraysMatch;
        }
    }
}
