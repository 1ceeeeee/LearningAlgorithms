using System;

namespace DataStructures
{
    public class MinHeap
    {
        private readonly int[ ] _elements;
        private int _size;

        public MinHeap( int size )
        {
            _elements = new int [ size ];
        }

        public MinHeap( int[ ] elements ) : this ( elements.Length )
        {
            _elements = elements;
            _size = elements.Length;
            for( var i = elements.Length - 1; i >= 0; i-- )
            {
                ShiftUp ( i );
            }
        }

        private static int GetParentIndex( int elementIndex )
            => ( elementIndex - 1 ) / 2;

        private static int GetLeftChildIndex( int elementIndex )
            => elementIndex * 2 + 1;

        private static int GetRightChildIndex( int elementIndex )
            => elementIndex * 2 + 2;

        private int GetParent( int elementIndex )
            => _elements[ GetParentIndex ( elementIndex ) ];

        private int GetLeftChild( int elementIndex )
            => _elements[ GetLeftChildIndex ( elementIndex ) ];

        private int GetRightChild( int elementIndex )
            => _elements[ GetRightChildIndex ( elementIndex ) ];

        private bool HasLeftChild( int elementIndex )
            => GetLeftChildIndex ( elementIndex ) <= _size;

        private bool HasRightChild( int elementIndex )
            => GetRightChildIndex ( elementIndex ) <= _size;

        private bool IsRoot( int index ) => index == 0;

        private void ShiftDown( int index = 0 )
        {
            while( HasLeftChild ( index ) )
            {
                var smallerIndex = GetLeftChildIndex ( index );
                if( HasRightChild ( index ) && GetRightChild ( index ) < GetLeftChild ( index ) )
                {
                    smallerIndex = GetRightChildIndex ( index );
                }

                if( _elements[ smallerIndex ] >= _elements[ index ] )
                {
                    break;
                }

                Swap ( smallerIndex, index );
                index = smallerIndex;
            }
        }

        private void ShiftUp( int? index = null )
        {
            var idx = 0;
            if( index == null )
                idx = _size - 1;
            else
                idx = index.Value;
            while( !IsRoot ( idx ) && _elements[ idx ] < GetParent ( idx ) )
            {
                var parentIndex = GetParentIndex ( idx );
                Swap ( parentIndex, idx );
                idx = parentIndex;
            }
        }

        private void Swap( int firstIndex, int secondIndex )
        {
            var firstElement = _elements[ firstIndex ];
            _elements[ firstIndex ] = _elements[ secondIndex ];
            _elements[ secondIndex ] = firstElement;
        }

        public bool IsEmpty( )
        {
            return _size == 0;
        }

        public int Peek( )
        {
            if( _size == 0 )
                throw new IndexOutOfRangeException ( );

            return _elements[ 0 ];
        }

        public int Pop( )
        {
            if( _size == 0 )
                throw new IndexOutOfRangeException ( );

            var result = _elements[ 0 ];

            _elements[ 0 ] = _elements[ _size - 1 ];
            _size--;

            ShiftDown ( );

            return result;
        }

        public void Add( int element )
        {
            if( _size == _elements.Length )
                throw new IndexOutOfRangeException ( );

            _elements[ _size ] = element;
            _size++;

            ShiftUp ( );
        }
    }
}