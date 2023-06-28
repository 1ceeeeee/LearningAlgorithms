using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algorithms.BFS
{
    public class SurroundedRegions
    {
        private Queue<(int, int)> _queue = new ( );

        private List<(int, int)> _steps = new ( )
        {
            new ( 0, 1 ),
            new ( 0, -1 ),
            new ( -1, 0 ),
            new ( 1, 0 )
        };

        public void Solve ( char [ ] [ ] board )
        {
            bool [ ] [ ] visited = new bool[ board.Length ] [ ];
            for ( var i = 0; i < board.Length; i++ )
                visited [ i ] = new bool[ board [ 0 ].Length ];

            // проверяем наличие осторовов по верхней границе
            for ( var j = 0; j < board [ 0 ].Length; j++ )
            {
                if ( visited [ 0 ] [ j ] || board [ 0 ] [ j ] == 'X' )
                    continue;
                BfsSearch ( ( 0, j ), visited, board );
            }

            // проверяем наличие осторовов по нижней границе
            var bottom = board.Length - 1;
            for ( var j = 0; j < board [ bottom ].Length; j++ )
            {
                if ( visited [ bottom ] [ j ] || board [ bottom ] [ j ] == 'X' )
                    continue;
                BfsSearch ( ( bottom, j ), visited, board );
            }
            
            // проверяем наличие осторовов по левой границе
            for ( var i = 0; i < board.Length; i++ )
            {
                if ( visited [ i ] [ 0 ] || board [ i ] [ 0 ] == 'X' )
                    continue;
                BfsSearch ( ( i, 0 ), visited, board );
            }
            
            // проверяем наличие осторовов по правой границе
            var right = board [ 0 ].Length - 1;
            for ( var i = 0; i < board.Length; i++ )
            {
                if ( visited [ i ] [ right ] || board [ i ] [ right ] == 'X' )
                    continue;
                BfsSearch ( ( i, right ), visited, board );
            }

            for ( var i = 0; i < visited.Length; i++ )
            {
                for ( var j = 0; j < visited[0].Length; j++ )
                {
                    if ( !visited [ i ] [ j ] )
                        board [ i ] [ j ] = 'X';
                }
            }
        }

        private bool IsGoodIndex ( int i, int j, char [ ] [ ] board )
        {
            return i >= 0 && i < board.Length && j >= 0 && j < board [ 0 ].Length;
        }

        private void BfsSearch (
            (int, int) item,
            bool [ ] [ ] visited,
            char [ ] [ ] board )
        {
            _queue.Enqueue ( item );

            visited [ item.Item1 ] [ item.Item2 ] = true;
            
            while ( _queue.Count > 0 )
            {
                var (x, y) = _queue.Dequeue ( );
                foreach ( var (deltaX, deltaY) in _steps )
                {
                    var newX = x + deltaX;
                    var newY = y + deltaY;

                    if ( !IsGoodIndex ( newX, newY, board ) )
                        continue;

                    if ( visited [ newX ] [ newY ] || board [ newX ] [ newY ] == 'X' )
                        continue;

                    visited [ newX ] [ newY ] = true;

                    _queue.Enqueue ( ( newX, newY ) );
                }
            }
        }
    }
}