using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altab.Entries;

namespace Altab.Auxiliaries
{
    public class SortedLinkedList<TKey, T> : IEnumerable<T> where T : class where TKey : object
    {
        private readonly IComparer<TKey> _comparer;
        SortedLinkedListNode<TKey, T> _head;
        public int Count { get; private set; }

        public SortedLinkedList()
        {
            _comparer = Comparer<TKey>.Default;
        }

        public SortedLinkedList(IComparer<TKey> comparer)
        {
            _comparer = comparer;
        }

        public void Add(TKey key, T item)
        {
            ++Count;
            SortedLinkedListNode<TKey, T> newItem = new SortedLinkedListNode<TKey, T>(key, item);
            if (_head == null)
            {
                _head = newItem;
                return;
            }
            SortedLinkedListNode<TKey, T> prev = null;
            SortedLinkedListNode<TKey, T> current = _head;
            while (current != null)
            {
                if (_comparer.Compare(newItem.Key, current.Key) > 0)
                {
                    newItem.Next = current;
                    newItem.Prev = current.Prev;
                    current.Prev = newItem;
                    if (current == _head)
                    {
                        _head = newItem;
                    }
                    else
                    {
                        newItem.Prev.Next = newItem;
                    }
                    return;
                }
                prev = current;
                current = current.Next;
            }
            newItem.Prev = prev;
            prev.Next = newItem;
        }

        public bool ContainsValue(Entry entry)
        {
            SortedLinkedListNode<TKey, T> current = _head;
            while (current != null)
            {
                if (entry == current.Item)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator() => new SortedLinkedListEnumerator<TKey, T>(_head);
        IEnumerator IEnumerable.GetEnumerator() => new SortedLinkedListEnumerator<TKey, T>(_head);
    }

    public class SortedLinkedListNode<TKey, T> where T : class
    {
        public TKey Key;
        public T Item { get; set; }
        public SortedLinkedListNode<TKey, T> Prev { get; set; }
        public SortedLinkedListNode<TKey, T> Next { get; set; }

        public SortedLinkedListNode(TKey key, T item, SortedLinkedListNode<TKey, T> prev = null, SortedLinkedListNode<TKey, T> next = null)
        {
            Key = key;
            Item = item;
            Prev = prev;
            Next = next;
        }

    }

    public class SortedLinkedListEnumerator<TKey, T> : IEnumerator<T> where T : class
    {
        public T Current { get; private set; }
        object IEnumerator.Current => Current;

        private readonly SortedLinkedListNode<TKey, T> _head;
        private SortedLinkedListNode<TKey, T> _currentNode;

        public SortedLinkedListEnumerator(SortedLinkedListNode<TKey, T> head)
        {
            _head = head;
            _currentNode = head;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_currentNode == null) return false;
            Current = _currentNode.Item;
            _currentNode = _currentNode.Next;
            return true; 
        }

        public void Reset() {
            _currentNode = _head;
            Current = null;
        }
    }
}
