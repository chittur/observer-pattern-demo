/******************************************************************************
 * Filename    = NodeNavigator.cs
 *
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = ObserverPatternDemo
 *
 * Description = Navigates a linked list and notifies a listener when a node is visited.
 *****************************************************************************/

namespace ObserverPatternDemo
{
    /// <summary>
    /// Navigates a linked list and notifies a listener when a node is visited.
    /// </summary>
    public class NodeNavigator
    {
        private readonly LinkedList<int> _list;     // The linked list to navigate.
        private INodeNavigationListener? _listener; // The listener to notify when a node is visited.

        /// <summary>
        /// Creates an instance of the node navigator.
        /// </summary>
        /// <param name="numbers">The list of numbers to initialize the navigator with.</param>
        public NodeNavigator(int[] numbers)
        {
            _list = new LinkedList<int>();
            foreach (int n in numbers)
            {
                _list.AddLast(n);
            }
        }

        /// <summary>
        /// Subscribes a listener to the navigator.
        /// </summary>
        /// <param name="listener">The subscriber instance.</param>
        public void Subscribe(INodeNavigationListener listener)
        {
            _listener = listener;
        }

        /// <summary>
        /// Navigates the linked list.
        /// </summary>
        public void Navigate()
        {
            LinkedListNode<int>? node = _list.First;
            while (node != null)
            {
                // Notify the listener when a node is visited.
                _listener?.OnNodeVisited(node.Value);
                node = node.Next;
            }
        }
    }
}
