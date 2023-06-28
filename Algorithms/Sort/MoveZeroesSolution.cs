namespace Algorithms
{
    public class MoveZeroesSolution
    {
        //time O(n) т.к. проходим каждым указателем только один раз по всему массиву
        public void MoveZeroes( int[ ] nums )
        {
            var p1 = 0;
            var p2 = 1;

            while( p2 < nums.Length )
            {
                if( nums[ p1 ] != 0 )
                {
                    p1++;
                    p2 = p1 + 1;
                    continue;
                }

                if( nums[ p2 ] == 0 )
                {
                    p2++;
                    continue;
                }

                ( nums[ p2 ], nums[ p1 ] ) = ( nums[ p1 ], nums[ p2 ] );
                p1++;
                p2++;
            }
        }
    } 
}