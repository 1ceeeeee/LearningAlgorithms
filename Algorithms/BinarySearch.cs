using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class BinarySearch
    {
        public static int Search(List<int> nums, int target)
        {
            // левый указатель инициализируем фиктивным значением,
            // чтобы он мог указывать на самое левое "истиное значение" 
            var l = -1;

            //правый указатель инициализируем фиктивным значением,
            // чтобы он мог указывать на самое правое "ложное значение" 
            var r = nums.Count;

            while (r - l > 1)
            {
                var m = (l + r) / 2;
                if (nums[m] <= target)
                    l = m;
                else
                    r = m;
            }
            return nums[l] != target ? -1 : 1;
        }
    }
}