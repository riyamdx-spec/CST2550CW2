using BettingSystem.Data_Structures;
using BettingSystem.Models;

namespace BettingSystemsTests;

[TestClass]
public class MyListTests
{
    private static void AssertThrows<TException>(Action action) where TException : Exception
    {
        try
        {
            action();
            Assert.Fail($"Expected exception of type {typeof(TException).Name}, but no exception was thrown.");
        }
        catch (TException)
        {
            // Expected path.
        }
    }

    [TestMethod]
    public void Constructor_EmptyList_StartsWithZeroCount()
    {
        var list = new MyList<int>();

        Assert.AreEqual(0, list.Count);
        Assert.IsTrue(list.IsEmpty());
    }

    [TestMethod]
    public void Add_ItemsIncreaseCount_AndKeepOrder()
    {
        var list = new MyList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(10, list[0]);
        Assert.AreEqual(20, list[1]);
        Assert.AreEqual(30, list[2]);
    }

    [TestMethod]
    public void Indexer_GetOutOfRange_Throws()
    {
        var list = new MyList<int>();
        list.Add(1);

        AssertThrows<IndexOutOfRangeException>(() => _ = list[-1]);
        AssertThrows<IndexOutOfRangeException>(() => _ = list[1]);
    }

    [TestMethod]
    public void Remove_RemovesFirstMatchingValue()
    {
        var list = new MyList<int>();
        list.Add(5);
        list.Add(8);
        list.Add(5);

        list.Remove(5);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(8, list[0]);
        Assert.AreEqual(5, list[1]);
    }

    [TestMethod]
    public void RemoveAll_RemovesOnlyMatchingValues()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        list.RemoveAll(i => i % 2 == 0);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(3, list[1]);
    }

    [TestMethod]
    public void Reverse_ReversesElementsInPlace()
    {
        var list = new MyList<string>();
        list.Add("A");
        list.Add("B");
        list.Add("C");

        list.Reverse();

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("C", list[0]);
        Assert.AreEqual("B", list[1]);
        Assert.AreEqual("A", list[2]);
    }

    [TestMethod]
    public void AddRange_AppendsAllElementsFromOtherList()
    {
        var list = new MyList<int>();
        list.Add(1);

        var more = new MyList<int>();
        more.Add(2);
        more.Add(3);

        list.AddRange(more);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);
        Assert.AreEqual(3, list[2]);
    }

    [TestMethod]
    public void InsertMatch_InsertsByGameDateDescending()
    {
        var list = new MyList<FootballMatch>();
        var older = new FootballMatch(1, 1, 10, 20, new DateTime(2026, 1, 1));
        var newer = new FootballMatch(2, 1, 11, 21, new DateTime(2026, 2, 1));
        var middle = new FootballMatch(3, 1, 12, 22, new DateTime(2026, 1, 15));

        list.InsertMatch(older);
        list.InsertMatch(newer);
        list.InsertMatch(middle);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(2, list[0].GameID);
        Assert.AreEqual(3, list[1].GameID);
        Assert.AreEqual(1, list[2].GameID);
    }
}
