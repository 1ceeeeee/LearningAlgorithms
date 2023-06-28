using System.Linq;

namespace Algorithms
{
    //204
    //time O( n * log log n)
    //mem O(n)
    public class CountPrimesSolution
    {
        public int CountPrimes( int n )
        {
            if( n <= 2 )
                return 0;

            var notPrimes = new bool[ n ];
            notPrimes[ 0 ] = true;
            notPrimes[ 1 ] = true;

            for( long i = 2; i < n; i++ )
            {
                if( notPrimes[ i ] )
                    continue;
                
                for( long j = i * i; j < n; j += i )
                {
                    notPrimes[ j ] = true;
                }
            }

            return notPrimes.Count( x => !x );
        }
        
        public int CountPrimes2(int n)
        {
            bool[] isComposite = new bool[n];
            int count = 0; 
            for (long i = 2; i < n; i++)        
                if (!isComposite[i])
                { 
                    count++; 
                    for (long j = i * i; j < n; j += i)                
                        isComposite[j] = true;                
                }
        
            return count;
        }
}

}