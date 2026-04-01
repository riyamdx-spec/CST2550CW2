using BettingSystem.Models;
using System;
using System.Collections;

namespace BettingSystem.Data_Structures
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _capacity;
        private int _count;
        public MyList()
        {
            _capacity = 10;
            _items = new T[_capacity];
            _count = 0;
        }

        // when assigning an existing list
        public MyList(IEnumerable<T> items)
        {
            _capacity = 10;
            _items = new T[_capacity];
            _count = 0;

            foreach (T item in items)
            {
                Add(item);
            }
        }

        // define indexer
        public T this[int i]
        {
            get
            {
                if (i<0 || i >= _count)
                    throw new IndexOutOfRangeException();
                return _items[i];
            }
            set 
            {
                if (i < 0 || i >= _count)
                    throw new IndexOutOfRangeException();

                _items[i] = value;
            }
        }

        //get count of list
        public int Count => _count;

        //check if list is empty
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Add element
        public void Add(T item)
        {
            if (_count == _capacity)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        // resizing dynamic array
        private void Resize()
        {
            //increase capacity
            _capacity = _capacity * 2;

            T[] resizedArr = new T[_capacity];

            for (int i=0; i < _count; i++)
            {
                resizedArr[i] = _items[i];
            }
            _items = resizedArr;
        }

        // remove an element
        public void Remove(T value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(value))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        // remove many elements
        public void RemoveAll(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_items[i]))
                {
                    RemoveAt(i);
                    i--;
                }
            }
        }

        //remove an element at a specific index
        private void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (int i=index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[_count - 1] = default(T);
            _count --;
        }

        // reverse list
        public void Reverse()
        {
            int maxIndex = _count - 1;
            int startIndex = 0;
            T temp;

            while (startIndex < maxIndex)
            {
                temp = _items[startIndex];
                _items[startIndex] = _items[maxIndex];
                _items[maxIndex] = temp;
                startIndex++;
                maxIndex--;
            }
        }

        //insert match at correct position
        public void InsertMatch(FootballMatch newMatch)
        {
            if (_count + 1 >= _capacity)
                Resize();

            DateTime itemDate = newMatch.GameDate;
            int i = _count - 1;
            while (i >= 0 && (_items[i]) is FootballMatch match && match.GameDate < itemDate)
            {
                //right shift
                _items[i + 1] = _items[i];
                i--;
            }
            //insert match at correct position
            _items[i + 1] = (T)(object)newMatch;
            _count++;
        }

        // return index of a value
        public int IndexOf(T value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(value))
                {
                    return i;
                }
            }
            return -1; //if value is not found
        }

        // check if list contains a value
        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        // merge lists
        public void AddRange(MyList<T> combiningList)
        {
            for (int i = 0; i < combiningList._count; i++)
            {
                Add(combiningList._items[i]);
            }
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < _count; i++)
            {
                action(_items[i]);
            }
        }

        public void Clear()
        {
            _items = new T[_capacity];
            _count = 0;
        }

        // to make list iterable
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}