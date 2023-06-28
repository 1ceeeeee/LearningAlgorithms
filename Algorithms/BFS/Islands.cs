using System;
using System.Collections.Generic;

namespace Algorithms.BFS
{
    public class Islands
    {
        private Queue<Tuple<int, int>> _queue = new Queue<Tuple<int, int>> ( );

        private bool IsGoodIndex ( int i, int j, char [ ] [ ] grid )
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid [ 0 ].Length;
        }

        private void Bfs ( int startX, int startY, bool [ ] [ ] visited, char [ ] [ ] grid )
        {
            var queue = new Queue<Tuple<int, int>> ( );
            queue.Enqueue ( new Tuple<int, int> ( startX, startY ) );
            var steps = new List<Tuple<int, int>>
            {
                new ( 0, 1 ),
                new ( 0, -1 ),
                new ( -1, 0 ),
                new ( 1, 0 )
            };
            visited [ startX ] [ startY ] = true;
            while ( queue.Count > 0 )
            {
                var (x, y) = queue.Dequeue ( );
                foreach ( var (deltaX, deltaY) in steps )
                {
                    var newX = x + deltaX;
                    var newY = y + deltaY;

                    if ( !IsGoodIndex ( newX, newY, grid ) )
                        continue;

                    if ( grid [ newX ] [ newY ] == '0' || visited [ newX ] [ newY ] )
                        continue;

                    queue.Enqueue ( new Tuple<int, int> ( newX, newY ) );
                    visited [ newX ] [ newY ] = true;
                }
            }
        }


        public int NumIslands ( char [ ] [ ] grid )
        {
            var result = 0;
            bool [ ] [ ] visited = new bool[ grid.Length ] [ ];
            for ( var i = 0; i < grid.Length; i++ )
                visited [ i ] = new bool[ grid [ 0 ].Length ];

            for ( var i = 0; i < grid.Length; i++ )
            {
                for ( var j = 0; j < grid [ 0 ].Length; j++ )
                {
                    if ( visited [ i ] [ j ] || grid [ i ] [ j ] == '0' )
                        continue;
                    Bfs ( i, j, visited, grid );
                    result++;
                }
            }

            return result;
        }
    }
}