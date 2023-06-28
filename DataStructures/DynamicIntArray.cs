using System;
using System.Drawing;

namespace DataStructures
{
    public class DynamicIntArray
    {
        private int?[] _items;
        private int _size = 0;
        private int _resizeValue = 0;
        private const int MaxDoubledSizeValue = 100;
        private const int ResizeArrayAfterExceedsValue = 200;


        public int Count => _size;

        public DynamicIntArray()
        {
            _items = new int? [3];
        }

        public DynamicIntArray(int capacity)
        {
            _items = new int?[capacity];
        }

        public void Add(int element)
        {
            if (_size == 0 || _size + 1 <= _items.Length)
                _items[_size] = element;
            else
                AddWithResize(element);
            _size++;
        }

        private void AddWithResize(int element)
        {
            var newCapacity = _size >= MaxDoubledSizeValue
                ? (int) (_items.Length * 0.2 + _items.Length)
                : _size * 2;

            if (newCapacity > Array.MaxLength)
                newCapacity = Array.MaxLength;

            if (newCapacity < _size + 1)
                newCapacity = _size + 1;

            var newArray = new int? [newCapacity];

            _items.CopyTo(newArray, 0);
            _items = newArray;
            _items[_size] = element;
        }

        public bool DeleteByIndex(int index)
        {
            if (_size == 0 || index > _size - 1)
                return false;

            _items[index] = default;

            return true;
        }

        public bool Remove(int element)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i] != element)
                    continue;

                _items[i] = default;
                _size--;
                return true;
            }

            return false;
        }
    }
}