using System;
using NUnit.Framework;

namespace Deque.Tests
{
	public class DeleteTests
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
		public void RemoveFront_WithNonEmptyCollection_ShouldRemoveFront()
		{
			var first_item = 5;
			var second_item = 6;

			_intTestDeque.InsertFront(first_item);
			_intTestDeque.InsertFront(second_item);

			_intTestDeque.DeleteFront();

			var expectedItem = 5;
			Assert.AreEqual(expectedItem,_intTestDeque.GetFront());

		}

		[Test]
		public void RemoveBack_WithNonEmptyCollection_ShouldRemoveBack()
		{
			var first_item = 5;
			var second_item = 6;

			_intTestDeque.InsertBack(first_item);
			_intTestDeque.InsertBack(second_item);

			_intTestDeque.DeleteBack();

			var expectedItem = 5;
			Assert.AreEqual(expectedItem,_intTestDeque.GetBack());

		}

		[Test]
		public void RemoveFront_WithEmptyCollection_ShouldThrowInvalidOperation()
		{
			Assert.Catch<InvalidOperationException>(() => _intTestDeque.DeleteFront());
		}

		[Test]
		public void RemoveBack_WithEmptyCollection_ShouldThrowInvalidOperation()
		{
			Assert.Catch<InvalidOperationException>(() => _intTestDeque.DeleteBack());
		}
	}
}
