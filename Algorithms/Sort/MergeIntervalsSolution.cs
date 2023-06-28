using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class MergeIntervalsSolution
    {
        public int[ ][ ] Merge( int[ ][ ] intervals )
        {
            Array.Sort( intervals, ( x, y ) => x[ 0 ].CompareTo( y[ 0 ] ) );
            List<int[ ]> answer = new( );
           
            foreach( var interval in intervals )
            {
                var prevInterval = answer.LastOrDefault( );
                if( prevInterval == null )
                {
                    answer.Add(
                        new int[ ]
                        {
                            interval[ 0 ], interval[ 1 ]
                        } );
                    continue;
                }
                    
                if( IsOvelaping( prevInterval, interval ) )
                {
                    answer[^1] = MergeIntervals( prevInterval, interval );
                }
                else
                {
                    answer.Add(
                        new int[ ]
                        {
                            interval[ 0 ], interval[ 1 ]
                        } );
                }
            }

            return answer.Select( x => x.ToArray( ) ).ToArray( );
        }

        private bool IsOvelaping(
            int[ ] first,
            int[ ] second )
        {
            return Math.Max( first[ 0 ], second[ 0 ] ) <= Math.Min( first[ 1 ], second[ 1 ] );
        }

        private int[ ] MergeIntervals( int[ ] first, int[ ] second )
        {
            return new[ ] { first[ 0 ], Math.Max( first[ 1 ], second[ 1 ] ) };
        }
    }
}