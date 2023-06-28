using System.Collections.Generic;
using System.Xml;

namespace Algorithms
{
    public class SortArrayCountSolution
    {
        public int[ ] SortArray( int[ ] nums )
        {
            var dict = new SortedDictionary<int, int>( );
            for( var i = 0; i < nums.Length; i++ )
            {
                if( dict.TryGetValue( nums[ i ], out var item ) )
                {
                    dict[ nums[ i ] ]++;
                }
                else
                {
                    dict[ nums[ i ] ] = 1;
                }
            }

            var index = 0;
            foreach( var (key, value) in dict )
            {
                for( var i = 0; i < value; i++ )
                {
                    nums[ index ] = key;
                    index++;
                }
            }

            return nums;
        }
    }
}