using BettingSystem.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Verifies core linked-list node operations: add, remove, and clear.
/// </summary>
[TestClass]
public class MyLinkedListTests
{
    /// <summary>
    /// Verifies that a newly created linked list has a count of zero and a null head node.
    /// </summary>
    [TestMethod]
    public void Constructor_StartsEmpty()
    {
        var list = new MyLinkedList<int>();

        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.First);
    }

    /// <summary>
    /// Confirms that AddFirst inserts nodes at the head and correctly maintains previous and next pointer links.
    /// </summary>
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

    /// <summary>
    /// Checks that removing the current head node updates the head pointer to the next node and decrements count.
    /// </summary>
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

    /// <summary>
    /// Verifies that removing a middle node correctly relinks its neighboring nodes to each other.
    /// </summary>
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

    /// <summary>
    /// Ensures that passing null to Remove returns false without throwing an exception.
    /// </summary>
    [TestMethod]
    public void Remove_NullNode_ReturnsFalse()
    {
        var list = new MyLinkedList<int>();

        bool removed = list.Remove(null!);

        Assert.IsFalse(removed);
    }

    /// <summary>
    /// Checks that calling Clear resets the list to an empty state with zero count and a null head.
    /// </summary>
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
