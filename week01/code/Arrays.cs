public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // First, I create a fixed-size array of type double using the length provided by length.

        var fixedArr = new double[length];

        // Then, I iterate through each position in the array, starting at index 0 and ending at length - 1.

        
        for (int i = 0; i < length; i++)
        {
            // At each position, I store the value of number multiplied by i + 1, because array indexes start at 0, but the multiples should start at 1.
            fixedArr[i] = number * (i + 1);
        }

        return fixedArr; // Finally, I return the array containing all the calculated multiples.
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

    // Find the index where the last amount elements begin.
    
    int startIndex = data.Count - amount;


    // Create a temporary list where to store
    // the elements in their new rotated order.
    
    List<int> rotated = new List<int>();


    // Copy the last "amount" elements to the beginning of the temporary array.
    
    for (int i = startIndex; i < data.Count; i++)
    {
        rotated.Add(data[i]);
    }


    // Copy the elements that were originally at the beginning and they will be now at the end of the temporary array
    
    for (int i = 0; i < startIndex; i++)
    {
        rotated.Add(data[i]);
    }

    // Replace the contents of the original list with the elements from the rotated list.
    
    data.Clear();

    for (int i = 0; i < rotated.Count; i++)
    {
        data.Add(rotated[i]);
    }
    }
}
