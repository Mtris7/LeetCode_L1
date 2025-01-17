﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class _743
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {

            var graph = new Dictionary<int, List<(int, int)>>();
            foreach (var time in times)
            {
                if (!graph.ContainsKey(time[0]))
                {
                    graph[time[0]] = new List<(int, int)>();
                }
                graph[time[0]].Add((time[1], time[2]));
            }
            var compare = Comparer<(int v, int cost)>.Create((a, b) => a.cost.CompareTo(b.cost));
            var heap = new Heap<(int, int)>(HeapType.MinHeap, compare);
            heap.Push((k, 0));

            var res = new int[n];
            for (int i = 0; i < n; i++)
            {
                res[i] = int.MaxValue;
            }
            res[k - 1] = 0;

            while (!heap.IsEmpty())
            {
                var curr = heap.Pop();
                if (graph.ContainsKey(curr.Item1))
                {
                    foreach (var pointCost in graph[curr.Item1])
                    {
                        if (pointCost.Item2 + curr.Item2 < res[pointCost.Item1 - 1])
                        {
                            heap.Push((pointCost.Item1, pointCost.Item2 + curr.Item2));
                            res[pointCost.Item1 - 1] = pointCost.Item2 + curr.Item2;
                        }
                    }
                }

            }
            var max = res.Max();
            if (max == int.MaxValue) return -1;
            return max;
        }
    }
}
