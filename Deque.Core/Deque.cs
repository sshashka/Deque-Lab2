
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Deque
{
	public class Deque<T> : IDeque<T>, IEnumerable<T>
	{

		public event CollectionChangeEventHandler OnItemAdded;
		public event CollectionChangeEventHandler OnItemDeleted;

		private Node<T> _front;
		private Node<T> _back;
		private int _size = 0;
		public int Size => _size;

		public Deque()
		{
			_size = 0;
		}

		public void PrintAll()
		{
			if (IsEmpty()) return;
			var item = _front;
			do
			{
				Console.WriteLine(item.Data);
				item = item.Next;
			} while (item != null);
		}

		public bool IsEmpty()
		{
			return (_front == null || _back == null);
		}

		private void Validate(T data)
		{
			if (data == null)
			{
				throw new ArgumentException("Reference is null", nameof(data));
			}
		}

		public void InsertFront(T data)
		{
			Validate(data);

			var newNode = new Node<T>(data);

			if (IsEmpty())
			{
				_back = newNode;
				_front = newNode;
			}
			// Inserts node at the front end
			else
			{
				newNode.Next = _front;
				_front.Prev = newNode;
				_front = newNode;
			}
			ItemAdded(new CollectionChangeEventArgs(CollectionChangeAction.Add,newNode));

			_size++;
		}

		public void InsertBack(T data)
		{
			Validate(data);

			var newNode = new Node<T>(data);

			if (IsEmpty())
			{
				_back = newNode;
				_front = newNode;
			}
			else
			{
				newNode.Prev = _back;
				_back.Next = newNode;
				_back = newNode;
			}
			ItemAdded(new CollectionChangeEventArgs(CollectionChangeAction.Add,newNode));

			_size++;
		}

		public void DeleteFront()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Sequence contains no elements");

			// Deletes the node from the front end and makes
			// the adjustment in the links
			var temp = _front;
			_front = _front.Next;

			// If only one element was present
			if (_front == null)
				_back = null;
			else
				_front.Prev = null;

			ItemDeleted(new CollectionChangeEventArgs(CollectionChangeAction.Remove, temp));
			_size--;
		}

		public void DeleteBack()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Sequence contains no elements");

			// Deletes the node from the rear end and makes
			// the adjustment in the links

			var temp = _back;
			_back = _back.Prev;

			// If only one element was present
			if (IsEmpty())
				_front = null;
			else
				_back.Next = null;
			ItemDeleted(new CollectionChangeEventArgs(CollectionChangeAction.Remove, temp));

			_size--;
		}

		public T GetFront()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Sequence contains no elements");
			return _front.Data;
		}

		public T GetBack()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Sequence contains no elements");
			return _back.Data;
		}

		public void Erase()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Collection is already empty");
			}
			_back = null;
			while (_front != null)
			{
				var temp = _front;
				_front = _front.Next;
				ItemDeleted(new CollectionChangeEventArgs(CollectionChangeAction.Remove, temp));

			}

			_size = 0;
		}

		protected virtual void ItemAdded(CollectionChangeEventArgs e)
		{
			OnItemAdded?.Invoke(this, e);
		}

		protected virtual void ItemDeleted(CollectionChangeEventArgs e)
		{
			OnItemDeleted?.Invoke(this, e);
		}

		public IEnumerator<T> GetEnumerator()
		{
			var node = _front;
			do
			{
				yield return node.Data;
				node = node.Next;
			} while (node != null);

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
