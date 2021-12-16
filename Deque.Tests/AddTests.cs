using System;

using NUnit.Framework;

namespace Deque.Tests
{
	public class AddTests
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
		public void AddToFront_UsingValueType_ShouldAddItemToFront()
		{
			var first_item = 5;
			var second_item = 6;

			_intTestDeque.InsertFront(first_item);
			_intTestDeque.InsertFront(second_item);

			var expectedItem = 6;
			Assert.AreEqual(expectedItem,_intTestDeque.GetFront());

		}

		[Test]
		public void AddToBack_UsingValueType_ShouldAddItemToBack()
		{
			var first_item = 5;
			var second_item = 6;

			_intTestDeque.InsertBack(first_item);
			_intTestDeque.InsertBack(second_item);

			var expectedItem = 6;
			Assert.AreEqual(expectedItem,_intTestDeque.GetBack());
		}

		[Test]
		public void AddToBack_UsingNonNullReferenceType_ShouldAddItemToBack()
		{
			var firstItem = new Tuple<int,string>(5, "five");
			var secondItem = new Tuple<int,string>(5, "five");

			_tupleTestDeque.InsertBack(firstItem);
			_tupleTestDeque.InsertBack(secondItem);

			var expectedItem = secondItem;
			Assert.AreEqual(expectedItem,_tupleTestDeque.GetBack());
		}

		[Test]
		public void AddToFront_UsingNonNullReferenceType_ShouldAddItemToFront()
		{
			var firstItem = new Tuple<int,string>(5, "five");
			var secondItem = new Tuple<int,string>(5, "five");

			_tupleTestDeque.InsertFront(firstItem);
			_tupleTestDeque.InsertFront(secondItem);

			var expectedItem = secondItem;
			Assert.AreEqual(expectedItem,_tupleTestDeque.GetFront());
		}

		[Test]
		public void AddToFront_UsingNullReferenceType_ShouldThrowArgumentException()
		{
			var firstItem = new Tuple<int, string>(5, "five");

			_tupleTestDeque.InsertFront(firstItem);

			Assert.Catch<ArgumentException>(() =>
			{

				_tupleTestDeque.InsertFront(null);

			});
		}

		[Test]
		public void AddToBack_UsingNullReferenceType_ShouldThrowArgumentException()
		{
			var firstItem = new Tuple<int, string>(5, "five");

			_tupleTestDeque.InsertBack(firstItem);
			Assert.Catch<ArgumentException>(() =>
			{

				_tupleTestDeque.InsertBack(null);

			});
		}
	}
}
