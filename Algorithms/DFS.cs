using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class DFS
    {
        //private readonly Dictionary<int, List<int>> _matrix = new();
        private readonly List<List<int>> _matrix = new();
        private int[] _colors;

        public bool CanFinish(
            int numCourses, 
            int[][] prerequisites)
        {
            _colors = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                _colors[i] = 0;
                _matrix.Add(new List<int>());
            }

            foreach (var prerequisite in prerequisites)
            {
                _matrix[prerequisite[0]].Add(prerequisite[1]);
            }

            foreach (var course in Enumerable.Range(0, numCourses))
                if (hasCycle(course))
                    return false;

            return true;
        }

        private bool hasCycle(int courseNum)
        {
            // если мы в нее зашли, но не вышли, то это цикл
            if (_colors[courseNum] == 1)
                return true;

            // если мы из нее вышли, то не обрабатываем
            if (_colors[courseNum] == 2)
                return false;

            // зашли в вершину
            _colors[courseNum] = 1;

            foreach (var item in _matrix[courseNum])
            {
                if (hasCycle(item))
                    return true;
            }

            _colors[courseNum] = 2;

            return false;
        }
    }
}