using System;
using NUnit.Framework;

namespace Deque.Tests
{
	public class OtherTest
	{
		private Deque<int> _intTestDeque;
		private Deque<Tuple<int,string>> _tupleTestDeque;


		[SetUp]
		public void Setup()
		{
			_intTestDeque = new Deque<int>();
			_tupleTestDeque = new Deque<Tuple<int,string>>();
		}

		[Test]
		public void EraseCollection_WithEmptyCollection_ShouldThrowInvalidOperation()
		{
			Assert.Catch<InvalidOperationException>(() => _intTestDeque.Erase());
		}

		[Test]
		public void EraseCollection_UsingCollectionWithItems_ShouldEraseAllItems()
		{
			var first_item = 5;
			var second_item = 6;
			var third_item = 1;

			_intTestDeque.InsertBack(first_item);
			_intTestDeque.InsertBack(second_item);
			_intTestDeque.InsertFront(third_item);
			_intTestDeque.Erase();

			var expectedSize = 0;
			Assert.AreEqual(expectedSize, _intTestDeque.Size);
		}
	}
}
