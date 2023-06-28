using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Algorithms.Heap
{
    public class TopKFrequentSolution
    {
        public IList<string> TopKFrequent( string[ ] words, int k )
        {
            var freqDictionary = new Dictionary<string, int> ( );
            
            Array.Sort(words, String.Compare);
            
            for( var i = 0; i < words.Length; i++ )
            {
                if( freqDictionary.TryGetValue ( words[ i ], out var currentCount ) )
                {
                    freqDictionary[ words[ i ] ] = currentCount + 1;
                }
                else
                {
                    freqDictionary.Add ( words[ i ], 1 );
                }
            }

            var t = freqDictionary.Select( x => new Tuple<int,string>(x.Value, x.Key) ).ToArray( );
            var maxHeap = new MaxHeapTuple ( t );
            var heapDepth = k;
            
            var result = new List<string> ( );
            while( !maxHeap.IsEmpty ( ) )
            {
                result.Add ( maxHeap.Pop ( ).Item2 );
            }

            return result;
        }
    }
}