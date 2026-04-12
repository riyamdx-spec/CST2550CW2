using BettingSystem.Data_Structures;

namespace BettingSystemsTests;

/// <summary>
/// Verifies key behaviors of MyDictionary: add/update, remove, lookup, resize, and null-key guards.
/// </summary>
[TestClass]
public class MyDictionaryTests
{
    /// <summary>
    /// Lightweight exception assertion helper used for custom collection guard checks.
    /// </summary>
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

    /// <summary>
    /// Verifies adding a new key stores the value and increments dictionary count.
    /// </summary>
    [TestMethod]
    public void Add_NewKey_AddsEntryAndIncreasesCount()
    {
        var dict = new MyDictionary<string, int>();

        dict.Add("one", 1);

        Assert.AreEqual(1, dict.Count);
        Assert.AreEqual(1, dict["one"]);
    }

    /// <summary>
    /// Verifies adding an existing key updates its value without increasing count.
    /// </summary>
    [TestMethod]
    public void Add_ExistingKey_UpdatesValueWithoutChangingCount()
    {
        var dict = new MyDictionary<string, int>();
        dict.Add("k", 1);

        dict.Add("k", 99);

        Assert.AreEqual(1, dict.Count);
        Assert.AreEqual(99, dict["k"]);
    }

    /// <summary>
    /// Verifies removing an existing key succeeds and the key is no longer present.
    /// </summary>
    [TestMethod]
    public void Remove_ExistingKey_ReturnsTrueAndRemovesValue()
    {
        var dict = new MyDictionary<string, string>();
        dict.Add("x", "value");

        bool removed = dict.Remove("x");

        Assert.IsTrue(removed);
        Assert.AreEqual(0, dict.Count);
        Assert.IsFalse(dict.ContainsKey("x"));
    }

    /// <summary>
    /// Verifies removing a missing key returns false and does not throw.
    /// </summary>
    [TestMethod]
    public void Remove_MissingKey_ReturnsFalse()
    {
        var dict = new MyDictionary<string, int>();

        bool removed = dict.Remove("missing");

        Assert.IsFalse(removed);
    }

    /// <summary>
    /// Verifies TryGetValue returns expected boolean and out values for hit and miss.
    /// </summary>
    [TestMethod]
    public void TryGetValue_ExistingAndMissingKeys_ReturnExpectedResult()
    {
        var dict = new MyDictionary<int, string>();
        dict.Add(10, "ten");

        bool found = dict.TryGetValue(10, out string existing);
        bool missing = dict.TryGetValue(999, out string notExisting);

        Assert.IsTrue(found);
        Assert.AreEqual("ten", existing);
        Assert.IsFalse(missing);
        Assert.IsNull(notExisting);
    }

    /// <summary>
    /// Verifies ContainsKey returns true only for keys that exist in the dictionary.
    /// </summary>
    [TestMethod]
    public void ContainsKey_ReturnsTrueOnlyForExistingKeys()
    {
        var dict = new MyDictionary<int, int>();
        dict.Add(1, 100);

        Assert.IsTrue(dict.ContainsKey(1));
        Assert.IsFalse(dict.ContainsKey(2));
    }

    /// <summary>
    /// Verifies values remain accessible after enough inserts to trigger internal resize.
    /// </summary>
    [TestMethod]
    public void Resize_AfterManyInsertions_AllValuesRemainAccessible()
    {
        var dict = new MyDictionary<int, string>();

        for (int i = 0; i < 60; i++)
        {
            dict.Add(i, $"v{i}");
        }

        Assert.AreEqual(60, dict.Count);
        for (int i = 0; i < 60; i++)
        {
            Assert.AreEqual($"v{i}", dict[i]);
        }
    }

    /// <summary>
    /// Verifies null reference-type keys throw ArgumentNullException across key APIs.
    /// </summary>
    [TestMethod]
    public void NullKey_OnReferenceTypeKey_ThrowsArgumentNullException()
    {
        var dict = new MyDictionary<string, int>();

        AssertThrows<ArgumentNullException>(() => dict.Add(null!, 1));
        AssertThrows<ArgumentNullException>(() => dict.ContainsKey(null!));
        AssertThrows<ArgumentNullException>(() => dict.Remove(null!));
    }
}
