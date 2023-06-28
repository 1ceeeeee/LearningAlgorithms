using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Algorithms.BFS;
using Algorithms.Heap;
using DataStructures;

namespace Algorithms
{
    class Program
    {
        static void Main( string[ ] args )
        {
            //DynamicIntArrayTest( );
            //BFSTest();
            //DFSTest();
            //SurroundedRegionsTest ( );
            //IslandPerimeter ( );
            //MinHeapTest ( );
            //MaxHeapTest();
            //KthLargestElementInArrayTest ( );
            //TopKFrequentSolutionTest();
            //CountPrimesSolutionTest();
            //SortArrayBubbleSolutionTest();
            //SortArrayCountSolutionTest( );
            //MoveZeroesSolutionTest( );
            //SortedSquaresSolutionTest( );
            MergeIntervalsSolution();
        }

        private static void MergeIntervalsSolution( )
        {
            var testArray = new int[ ][ ]
            {
                new[ ] { 2, 6 },
                new[ ] { 8, 10 },
                new[ ] { 1, 3 },
                new[ ] { 15, 18 }
            };
            var t = new MergeIntervalsSolution( );
            var result = t.Merge( testArray );
        }

        private static void SortedSquaresSolutionTest( )
        {
            var t = new SortedSquaresSolution( );
            var result = t.SortedSquares( new int[ ] { -7, -3, 2, 3, 11 } );
        }

        private static void MoveZeroesSolutionTest( )
        {
            var t = new MoveZeroesSolution( );
            var nums = new int[ ] { 0, 1, 0, 3, 12 };
            t.MoveZeroes( nums );
        }

        private static void SortArrayCountSolutionTest( )
        {
            var t = new SortArrayCountSolution( );
            var result = t.SortArray( new int[ ] { 5, 2, 3, 1 } );
        }

        private static void SortArrayBubbleSolutionTest( )
        {
            var t = new SortArraySolution( );
            var result = t.SortArray( new int[ ] { 5, 2, 3, 1 } );
        }

        private static void CountPrimesSolutionTest( )
        {
            var t = new CountPrimesSolution( );
            var result = t.CountPrimes( 10 * 10 * 10 * 10 * 10 * 10 );
            var result2 = t.CountPrimes2( 10 * 10 * 10 * 10 * 10 * 10 );
        }

        private static void TopKFrequentSolutionTest( )
        {
            var test = new string[ ]
            {
                "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"
            };

            var t = new TopKFrequentSolution( );
            var result = t.TopKFrequent( test, 4 );
        }

        private static void KthLargestElementInArrayTest( )
        {
            var test = new int[ ] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var t = new KthLargestElementInArray( );
            var result = t.FindKthLargest( test, 4 );
        }

        private static void MinHeapTest( )
        {
            var testArray = new int[ ] { 1, 7, 5, 3 };
            var minHeap = new MinHeap( testArray );
            // for ( var i = 0; i < testArray.Length; i++ )
            // {
            //     var t = testArray[ i ];
            //     minHeap.Add ( testArray[ i ] );
            // }
        }

        private static void MaxHeapTest( )
        {
            var testArray = new int[ ] { 1, 7, 5, 3 };
            var minHeap = new MaxHeap( testArray );
        }

        private static void IslandPerimeter( )
        {
            var board = new int[ ][ ]
            {
                new int[ ] { 1, 1 },
                new int[ ] { 1, 1 }
                // new int[ ] { 0, 1, 0, 0 },
                // new int[ ] { 1, 1, 1, 0 },
                // new int[ ] { 0, 1, 0, 0 },
                // new int[ ] { 1, 1, 0, 0 },
            };

            var perimeter = new IslandPerimeter( );
            var t = perimeter.Perimeter( board );
        }

        // [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]

        private static void SurroundedRegionsTest( )
        {
            var board = new char[ ][ ]
            {
                new char[ ] { 'X', 'X', 'X', 'X' },
                new char[ ] { 'X', 'O', 'O', 'X' },
                new char[ ] { 'X', 'X', 'O', 'X' },
                new char[ ] { 'X', 'O', 'X', 'X' }
            };

            var surroundedRegion = new SurroundedRegions( );
            surroundedRegion.Solve( board );
            //board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
        }

        private static void DFSTest( )
        {
            var numCourses = 3;
            int[ ][ ] prerequisites = new int[ ][ ]
            {
                new int[ ] { 1, 0 },
                new int[ ] { 2, 1 },
                new int[ ] { 0, 2 },
            };

            var dfs = new DFS( );
            var t = dfs.CanFinish( numCourses, prerequisites );
        }

        private static void BFSTest( )
        {
            // char[][] grid = new char[][]
            // {
            //     new char[] {'1', '1', '1', '1', '0'},
            //     new char[] {'1', '1', '0', '1', '0'},
            //     new char[] {'1', '1', '0', '0', '0'},
            //     new char[] {'0', '0', '0', '0', '0'}
            // };

            char[ ][ ] grid = new char[ ][ ]
            {
                new char[ ] { '1', '0', '1', '1', '0', '1', '1' }
            };

            var bfs = new BFS.Islands( );
            var t = bfs.NumIslands( grid );
        }

        //[["1","0","1","1","0","1","1"]]

        // Input: grid = [
        // ["1","1","1","1","0"],
        // ["1","1","0","1","0"],
        // ["1","1","0","0","0"],
        // ["0","0","0","0","0"]
        // ]
        // Output: 1

        private static void LinkedIntList( )
        {
            var linkedList = new LinkedIntList( );
            var test = linkedList.Test( );
            var t = linkedList.Get( 1 );
            linkedList.AddAtHead( 2 );
            test = linkedList.Test( );
            linkedList.AddAtHead( 1 );
            linkedList.AddAtTail( 3 );
            linkedList.AddAtTail( 4 );
            linkedList.AddAtIndex( 1, 5 );
            linkedList.DeleteAtIndex( 1 );
            test = linkedList.Test( );
        }

        private static void DynamicIntArrayTest( )
        {
            var dynamicIntArray = new DynamicIntArray( );

            for( var i = 1; i <= 10; i++ )
            {
                dynamicIntArray.Add( i );
            }

            dynamicIntArray.Remove( 10 );
            dynamicIntArray.Remove( 9 );
            dynamicIntArray.Remove( 8 );
            dynamicIntArray.Remove( 7 );
            dynamicIntArray.Remove( 6 );
            dynamicIntArray.Remove( 5 );
            dynamicIntArray.Remove( 4 );
            dynamicIntArray.Remove( 3 );
            dynamicIntArray.Remove( 2 );
            dynamicIntArray.Remove( 1 );
        }

        private static void QueueIntTest( )
        {
            var t = new Stack<int>( );
            t.Push( 1 );
            t.Push( 2 );
            t.Push( 3 );

            var test = new QueueInt( );
            test.Push( 1 );
            test.Push( 2 );
            test.Push( 3 );
            var peek = test.Peek( );
            var empty1 = test.Empty( );
            test.Pop( );
            test.Pop( );
            test.Pop( );
            var empty = test.Empty( );
            LinkedIntList( );
        }
    }
}