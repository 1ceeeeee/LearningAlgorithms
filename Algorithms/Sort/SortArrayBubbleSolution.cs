namespace Algorithms
{
    public class SortArraySolution
    {
        //912
        public int[ ] SortArray( int[ ] nums )
        {
            var iterations = nums.Length;
            while( iterations != 0 )
            {
                for( var i = 0; i < iterations - 1; i++ )
                {
                    if( nums[ i ] > nums[ i + 1 ] )
                    {
                        ( nums[ i ], nums[ i + 1 ] ) = ( nums[ i + 1 ], nums[ i ] );
                    }
                }

                iterations--;
            }

            return nums;
        }
    }
}