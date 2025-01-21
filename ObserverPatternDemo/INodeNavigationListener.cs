/******************************************************************************
 * Filename    = INodeNavigationListener.cs
 *
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = ObserverPatternDemo
 *
 * Description = Contract for a listener that is notified when a node is visited.
 *****************************************************************************/

namespace ObserverPatternDemo;

/// <summary>
/// Interface for a listener that is notified when a node is visited.
/// </summary>
public interface INodeNavigationListener
{
    /// <summary>
    /// Called when a node is visited.
    /// </summary>
    /// <param name="data">The data of the node being visited.</param>
    void OnNodeVisited(int data);
}
