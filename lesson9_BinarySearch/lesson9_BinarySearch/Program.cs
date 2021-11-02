﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson9_BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //852. Peak Index in a Mountain Array
            //33. Search in Rotated Sorted Array
            //153.Find Minimum in Rotated Sorted Array
            //81. Search in Rotated Sorted Array II
            //1760. Minimum Limit of Balls in a Bag


            //FindMin(new int[] { 3, 4, 5, 1, 2 } );
            //Search(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }, 2);//[1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1]
            //MinimumSize(new int[] { 4, 412, 354, 607, 587, 28, 136, 327, 929, 905, 671, 811, 572, 152, 556, 96, 205, 188, 505, 14, 602, 591, 802, 662, 543, 781, 878, 812, 539, 981, 587, 716, 531, 354, 92, 165, 352, 522, 983, 966, 378, 911, 873, 606, 392, 927, 426, 726, 892, 939, 96, 419, 769, 387, 178, 895, 41, 291, 437, 513, 37, 569, 945, 102, 460 }, 33);
            //[4,412,354,607,587,28,136,327,929,905,671,811,572,152,556,96,205,188,505,14,602,591,802,662,543,781,878,812,539,981,587,716,531,354,92,165,352,522,983,966,378,911,873,606,392,927,426,726,892,939,96,419,769,387,178,895,41,291,437,513,37,569,945,102,460]
            //33
            MySqrt(2147395599);
            Console.WriteLine("Hello World!");
        }
        //#####################################################################################
        //#####################################################################################
        //#####################################################################################
        /// <summary>
        /// 1760. Minimum Limit of Balls in a Bag
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maxOperations"></param>
        /// <returns></returns>
        public int MinimumSize(int[] nums, int maxOperations)
        {
            int high = nums.Max();
            int low = 1;
            int result = int.MaxValue;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (IsPossible(nums, mid, maxOperations))
                {
                    high = mid - 1;
                    result = Math.Min(result, mid);
                }
                else
                    low = mid + 1;

            }
            return result;
        }
        bool IsPossible(int[] nums, int mid, int maxOperations)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count += (nums[i] - 1) / mid;
                if (count > maxOperations)
                    return false;
            }
            return true;
        }
        //#####################################################################################
        /// <summary>
        /// 69. Sqrt(x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqrt(int x)
        {
            if (x == 0 || x == 1) return x;
            long left = 0;
            long right = int.MaxValue / 2 + 1;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                long powX = mid * mid;
                if (powX == x)
                    return (int)mid;
                else if (powX > x)
                    right = mid;
                else
                    left = mid + 1;

            }

            return (int)left - 1;
        }
        //#####################################################################################
        /// <summary>
        /// 81. Search in Rotated Sorted Array II
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            var n = nums.Length;

            if (n == 0) return false;

            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[mid] < nums[right])
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                else if (nums[mid] == nums[right])
                {
                    right--;
                }
                else
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }

            return nums[left] == target;
        }

        //#####################################################################################
        /// <summary>
        /// 153. Find Minimum in Rotated Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = (right - left) / 2 + left;
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return nums[right];
        }
        //#####################################################################################
        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInRotated(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            //4, 5, 6, 7, 0, 1, 2 => 0
            while (left < right)
            {
                int mid = (right - left) / 2 + left;
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if (target > nums[left] && target > nums[nums.Length - 1])
            {
                right = left - 1;
                left = 0;
            }
            else
            {
                right = nums.Length - 1;
            }
            while (left <= right)
            {
                int mid = (right - left) / 2 + left;

                if (nums[mid] == target) return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
        //#####################################################################################
        /// <summary>
        /// 852. Peak Index in a Mountain Array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            int low = 0;
            int hight = arr.Length;
            while (low <= hight)
            {
                int mid = (low + hight) / 2;
                if (mid > 0 && arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
                    return mid;
                if (mid == 0 || arr[mid] > arr[mid - 1])
                    low = mid + 1;
                if (arr[mid] > arr[mid + 1])
                    hight = mid - 1;
            }
            return -1;
        }
    }
}
