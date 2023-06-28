namespace Algorithms
{
    public class SortedSquaresSolution
    {
        //time O(n)
        //mem O(n);
        public int[ ] SortedSquares( int[ ] nums )
        {
            var left = 0;
            var right = nums.Length - 1;
            var ansIndex = nums.Length - 1;
            var answer = new int[ nums.Length ];

            while( left <= right )
            {
                var leftSquared = nums[ left ] * nums[ left ];
                var rightSquared = nums[ right ] * nums[ right ];

                if( leftSquared <= rightSquared )
                {
                    right--;
                    answer[ ansIndex ] = rightSquared;
                    ansIndex--;
                    continue;
                }
                
                if( rightSquared < leftSquared )
                {
                    left++;
                    answer[ ansIndex ] = leftSquared;
                    ansIndex--;
                }
            }

            return answer;
        }
    }
}