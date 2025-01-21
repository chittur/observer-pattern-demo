/******************************************************************************
 * Filename    = NodeNavigatorUnitTests.cs
 *
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = UnitTests
 *
 * Description = Unit tests for the observer pattern demo.
 *****************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using ObserverPatternDemo;

namespace UnitTests;

/// <summary>
/// Listener that records the numbers visited by the node navigator.
/// </summary>
class NodeListener : INodeNavigationListener
{
    /// <summary>
    /// Creates an instance of the node listener.
    /// </summary>
    public NodeListener()
    {
        Numbers = new List<int>();
    }

    /// <summary>
    /// Gets the list of numbers visited by the node navigator.
    /// </summary>
    public List<int> Numbers { get; private set; }

    /// <summary>
    /// Called when a node is visited.
    /// </summary>
    /// <param name="data">The data of the node being visited.</param>
    public void OnNodeVisited(int data)
    {
        Numbers.Add(data);
    }
}

/// <summary>
/// Unit tests for the observer pattern demo.
/// </summary>
[TestClass]
public class NodeNavigatorUnitTests
{
    /// <summary>
    /// Tests navigation callbacks.
    /// </summary>
    [TestMethod]
    public void TestNavigationCallbacks()
    {
        Logger.LogMessage("Running TestNavigationCallbacks");
        NodeListener listener = new();
        int[] numbers = { 1, 2, 3, 4, 5 };
        NodeNavigator navigator = new(numbers);
        navigator.Subscribe(listener);
        navigator.Navigate();

        Assert.IsTrue(Enumerable.SequenceEqual(numbers, listener.Numbers));
    }

    /// <summary>
    /// Tests that there are no navigation callbacks when there are no nodes.
    /// </summary>
    [TestMethod]
    public void TestEmptyNavigationHasNoCallback()
    {
        Logger.LogMessage("Running TestEmptyNavigationHasNoCallback");
        NodeListener listener = new();
        int[] numbers = { };
        NodeNavigator navigator = new(numbers);
        navigator.Subscribe(listener);
        navigator.Navigate();

        Assert.IsTrue(Enumerable.SequenceEqual(numbers, listener.Numbers));
    }
}
