using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.BFS
{
    public class IslandPerimeter
    {
        private Queue<(int, int)> _queue = new ( );
        private int _sum = 0;

        private List<(int, int)> _steps = new ( )
        {
            new ( 0, 1 ),
            new ( 0, -1 ),
            new ( -1, 0 ),
            new ( 1, 0 )
        };

        public int Perimeter ( int[ ][ ] grid )
        {
            bool[ ][ ] visited = new bool[ grid.Length ][ ];
            for ( var i = 0; i < grid.Length; i++ )
                visited[ i ] = new bool[ grid[ 0 ].Length ];

            for ( int i = 0; i < grid.Length; i++ )
            {
                for ( int j = 0; j < grid[ 0 ].Length; j++ )
                {
                    if ( visited[ i ][ j ] || grid[ i ][ j ] == 0 )
                        continue;
                    BfsSearch ( i, j, visited, grid );
                }
            }

            return _sum;
        }

        private bool IsGoodIndex ( int i, int j, int[ ][ ] board )
        {
            return i >= 0 && i < board.Length && j >= 0 && j < board[ 0 ].Length;
        }

        private void BfsSearch (
            int x,
            int y,
            bool[ ][ ] visited,
            int[ ][ ] grid )
        {
            _queue.Enqueue ( ( x, y ) );
            visited[ x ][ y ] = true;
            _sum += 4;

            while ( _queue.Any ( ) )
            {
                ( x, y ) = _queue.Dequeue ( );

                foreach ( var (deltaX, deltaY) in _steps )
                {
                    var newX = x + deltaX;
                    var newY = y + deltaY;

                    if ( !IsGoodIndex ( newX, newY, grid ) )
                        continue;

                    if ( grid[ newX ][ newY ] == 0 )
                        continue;

                    if ( visited[ newX ][ newY ] )
                    {
                        // _sum -= 2;
                        continue;
                    }

                    visited[ newX ][ newY ] = true;
                    _sum += 4;
                    ProcessVisitedNeighbor (
                        newX,
                        newY,
                        grid,
                        visited );
                    _queue.Enqueue ( ( newX, newY ) );
                }
            }
        }

        private void ProcessVisitedNeighbor (
            int x,
            int y,
            int[ ][ ] grid,
            bool[ ][ ] visited )
        {
            foreach ( var (deltaX, deltaY) in _steps )
            {
                var newX = x + deltaX;
                var newY = y + deltaY;

                if ( !IsGoodIndex ( newX, newY, grid ) )
                    continue;

                if ( grid[ newX ][ newY ] == 0 )
                    continue;
                if ( visited[ newX ][ newY ] )
                {
                    _sum -= 2;
                    continue;
                }
            }
        }
    }
}