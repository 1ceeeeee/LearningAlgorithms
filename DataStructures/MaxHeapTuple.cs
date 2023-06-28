using System;

namespace DataStructures
{
    public class MaxHeapTuple
    {
        //private readonly(int, string)[ ] _elements;
        private readonly Tuple<int, string>[ ] _elements;
        private int _size;

        public MaxHeapTuple( int size )
        {
            _elements = new Tuple<int, string>[ size ];
        }

        public MaxHeapTuple( Tuple<int, string>[ ] elements ) : this( elements.Length )
        {
            _elements = elements;
            _size = elements.Length;
            for( var i = elements.Length - 1; i >= 0; i-- )
            {
                ShiftUp( i );
            }
        }

        private static int GetParentIndex( int elementIndex )
            => ( elementIndex - 1 ) / 2;

        private static int GetLeftChildIndex( int elementIndex )
            => elementIndex * 2 + 1;

        private static int GetRightChildIndex( int elementIndex )
            => elementIndex * 2 + 2;

        private Tuple<int, string> GetParent( int elementIndex )
            => _elements[ GetParentIndex( elementIndex ) ];

        private Tuple<int, string> GetLeftChild( int elementIndex )
            => _elements[ GetLeftChildIndex( elementIndex ) ];

        private Tuple<int, string> GetRightChild( int elementIndex )
            => _elements[ GetRightChildIndex( elementIndex ) ];

        private bool HasLeftChild( int elementIndex )
            => GetLeftChildIndex( elementIndex ) < _size;

        private bool HasRightChild( int elementIndex )
            => GetRightChildIndex( elementIndex ) < _size;

        private bool IsRoot( int index ) => index == 0;

        private void ShiftDown( int index = 0 )
        {
            while( HasLeftChild( index ) )
            {
                var biggerIndex = GetLeftChildIndex( index );
                if( HasRightChild( index ) && GetRightChild( index ).Item1 > GetLeftChild( index ).Item1 )
                {
                    biggerIndex = GetRightChildIndex( index );
                }

                if( _elements[ biggerIndex ].Item1 < _elements[ index ].Item1 )
                {
                    break;
                }

                Swap( biggerIndex, index );
                index = biggerIndex;
            }
        }

        private void ShiftUp( int? index = null )
        {
            var idx = 0;
            if( index == null )
                idx = _size - 1;
            else
                idx = index.Value;
            while( !IsRoot( idx ) && _elements[ idx ].Item1 >= GetParent( idx ).Item1 )
            {
                //TODO add alphabetic check
                if( _elements[ idx ].Item1 == GetParent( idx ).Item1 )
                {
                    //if(_elements[ idx ].Item2.CompareTo())
                }
                var parentIndex = GetParentIndex( idx );
                Swap( parentIndex, idx );
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

        public Tuple<int, string> Peek( )
        {
            if( _size == 0 )
                throw new IndexOutOfRangeException( );

            return _elements[ 0 ];
        }

        public Tuple<int, string> Pop( )
        {
            if( _size == 0 )
                throw new IndexOutOfRangeException( );

            var result = _elements[ 0 ];

            _elements[ 0 ] = _elements[ _size - 1 ];
            _size--;

            ShiftDown( );

            return result;
        }

        public void Add( Tuple<int, string> element )
        {
            if( _size == _elements.Length )
                throw new IndexOutOfRangeException( );

            _elements[ _size ] = element;
            _size++;

            ShiftUp( );
        }
    }
}