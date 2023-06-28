using DataStructures;

namespace Algorithms.Heap
{
    public class KthLargestElementInArray
    {
        public int FindKthLargest ( int[ ] nums, int k )
        {
            var maxHeap = new MaxHeap ( nums );
            for ( int i = 0; i < k-1; i++ )
            {
                maxHeap.Pop ( );
            }

            return maxHeap.Peek ( );
            // var minHeap = new MinHeap ( k );
            // var initCount = 2;
            //
            //
            // for ( int i = 0; i < nums.Length; i++ )
            // {
            //     if ( minHeap.IsEmpty ( ) || initCount > 0 )
            //     {
            //         minHeap.Add(nums[i]);
            //         initCount--;
            //     }
            //     else
            //     {
            //         if ( nums[ i ] > minHeap.Peek ( ) )
            //         {
            //             minHeap.Pop ( );
            //             minHeap.Add(nums[i]);
            //         }
            //     }
            // }
            //
            // return minHeap.Peek ( );

            // var tempArray = new int[ k ];
            // var heapLimit = k;
            // for ( int i = 0; i < k; i++ )
            // {
            //     tempArray[ i ] = nums[ i ];
            // }
            // var minHeap = new MinHeap ( k );
            // var test = new int[ ] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            // for ( var i = 0; i < nums.Length; i++ )
            // {
            //     var t = nums[ i ];
            //     if ( minHeap.IsEmpty() || heapLimit != 0 )
            //     {
            //         minHeap.Add(nums[i]);
            //         heapLimit--;
            //     }
            //     else
            //     {
            //         var tt = minHeap.Peek ( );
            //         if ( nums[ i ] > minHeap.Peek ( ) )
            //         {
            //             minHeap.Pop ( );
            //             minHeap.Add ( nums[ i ] );
            //             heapLimit--;
            //         }
            //     }
            // }
            //
            // tempArray = new int[ ] { 3, 2, 1, 4 };
            // var minHeap = new MinHeap ( tempArray );
            //
            // for ( int i = 7; i < nums.Length; i++ )
            // {
            //     var peak = minHeap.Peek ( );
            //     var temp = nums[ i ];
            //     if ( temp > peak )
            //     {
            //         minHeap.Pop ( );
            //         minHeap.Add ( nums[ i ] );
            //     }
            // }

            //return minHeap.Peek ( );
        }
    }
}