using BettingSystem.Data_Structures;

namespace BettingSystemsTests;

[TestClass]
public class MyLinkedListTests
{
    [TestMethod]
    public void Constructor_StartsEmpty()
    {
        var list = new MyLinkedList<int>();

        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.First);
    }

    [TestMethod]
    public void AddFirst_AddsAtHead_AndUpdatesCount()
    {
        var list = new MyLinkedList<int>();

        var n1 = list.AddFirst(10);
        var n2 = list.AddFirst(20);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(20, list.First.Value);
        Assert.AreEqual(10, n2.Next.Value);
        Assert.IsNull(n2.Previous);
        Assert.AreEqual(n2, n1.Previous);
    }

    [TestMethod]
    public void Remove_HeadNode_UpdatesHead()
    {
        var list = new MyLinkedList<int>();
        list.AddFirst(1);
        var second = list.AddFirst(2);

        bool removed = list.Remove(second);

        Assert.IsTrue(removed);
        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(1, list.First.Value);
        Assert.IsNull(list.First.Previous);
    }

    [TestMethod]
    public void Remove_MiddleNode_ReconnectsNeighbors()
    {
        var list = new MyLinkedList<int>();
        var tail = list.AddFirst(1);
        var middle = list.AddFirst(2);
        var head = list.AddFirst(3);

        bool removed = list.Remove(middle);

        Assert.IsTrue(removed);
        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(head.Next, tail);
        Assert.AreEqual(tail.Previous, head);
    }

    [TestMethod]
    public void Remove_NullNode_ReturnsFalse()
    {
        var list = new MyLinkedList<int>();

        bool removed = list.Remove(null!);

        Assert.IsFalse(removed);
    }

    [TestMethod]
    public void Clear_RemovesAllNodes()
    {
        var list = new MyLinkedList<string>();
        list.AddFirst("A");
        list.AddFirst("B");

        list.Clear();

        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.First);
    }
}
