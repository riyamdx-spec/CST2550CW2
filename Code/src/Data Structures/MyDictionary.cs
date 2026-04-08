//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;

namespace BettingSystem.Data_Structures
{
    // custom dictionary using hash table
    public class MyDictionary<TKey, TValue>: IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private class HashNode
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public HashNode Next { get; set; }

            //node keeps key-value pair
            public HashNode(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private HashNode[] _buckets;  // for seperate chaining to handle collision
        private int _size;
        private const int DEFAULT_CAPACITY = 32;
        private const double LOAD_FACTOR = 0.75;

        public MyDictionary()
        {
            _buckets = new HashNode[DEFAULT_CAPACITY];
            _size = 0;
        }

        public TValue this[TKey key]
        {
            // to access value with key
            get => Get(key);

            //to set a value
            set => Add(key, value);
        }
        public int Count => _size;

        //calculate index of bucket for a key
        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % _buckets.Length);
        }

        // insert key-value pair to dictionary if it does not exists
        // update value if key exists
        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (_size >= _buckets.Length * LOAD_FACTOR)
            {
                Resize();
            }

            int bucketIndex = GetBucketIndex(key);
            HashNode node = _buckets[bucketIndex];

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    return;
                }
                node = node.Next;
            }

            HashNode newNode = new HashNode(key, value);
            newNode.Next = _buckets[bucketIndex];
            _buckets[bucketIndex] = newNode;
            _size++;
        }

        //Remove key-value pair
        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            HashNode node = _buckets[bucketIndex];
            HashNode prev = null;

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    if (prev == null)
                    {
                        _buckets[bucketIndex] = node.Next;
                    }
                    else
                    {
                        prev.Next = node.Next;
                    }
                    _size--;
                    return true;

                }
                prev = node;
                node = node.Next;
            }

            return false;
        }

        //get value associated with a key
        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            HashNode node = _buckets[bucketIndex];

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
                node = node.Next;
            }
            throw new KeyNotFoundException();
        }

        //Checks if key exists
        public bool ContainsKey(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            HashNode node = _buckets[bucketIndex];

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        //attempts to retrieve value
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            HashNode node = _buckets[bucketIndex];

            while (node != null)
            {
                if (node.Key.Equals(key))
                {
                    value = node.Value;
                    return true;
                }
                node = node.Next;
            }
            value = default;
            return false;
        }

        //doubles capacity
        private void Resize()
        {
            int newCapacity = _buckets.Length * 2;
            HashNode[] newBuckets = new HashNode[newCapacity];

            for (int i=0; i < _buckets.Length; i++)
            {
                HashNode node = _buckets[i];
                while (node != null)
                {
                    HashNode next = node.Next;
                    int index = Math.Abs(node.Key.GetHashCode() % newCapacity);
                    node.Next = newBuckets[index];
                    newBuckets[index] = node;
                    node = next;
                }
            }
            _buckets = newBuckets;
        }

        //allow iteration through key-value pairs
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _buckets.Length; i++)
            {
                HashNode node = _buckets[i];

                while (node != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
                    node = node.Next;
                }
            }
        }

        //allow iteration through keys
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach(var pair in this)
                {
                    yield return pair.Key;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}