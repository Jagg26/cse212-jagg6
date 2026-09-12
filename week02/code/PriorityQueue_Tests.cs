using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with priorities 1, 5, and 3, then dequeue once.
    // Expected Result: The value with priority 5 should be returned.
    // Defect(s) Found: None after the test case was written. This verifies that Dequeue returns
    // the highest-priority item.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority and dequeue all items.
    // Expected Result: Items with the same highest priority should be returned in FIFO order, followed
    // by lower-priority items.
    // Defect(s) Found: The item with the same priority closest to the back was returned first because
    // the code used >= when comparing priorities. Dequeued items were also not removed from the queue.
    public void TestPriorityQueue_FifoWhenPrioritiesTie()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 7);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Second High", 7);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items where the last item has the highest priority, then dequeue once.
    // Expected Result: The last item should be returned because it has the highest priority.
    // Defect(s) Found: The last item was skipped while searching for the highest priority because
    // the loop ended before checking the final queue item.
    public void TestPriorityQueue_LastItemCanHaveHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 9);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty."
    // Defect(s) Found: None after the test case was written. This verifies the required exception type
    // and message.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}
