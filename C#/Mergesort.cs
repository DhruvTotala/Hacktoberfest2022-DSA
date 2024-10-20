using System;

class MergeSort
{
    // Function to merge two subarrays of arr[]
    // First subarray is arr[l..m]
    // Second subarray is arr[m+1..r]
    void Merge(int[] arr, int left, int middle, int right)
    {
        // Find the sizes of two subarrays to be merged
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Create temporary arrays to hold the data
        int[] LeftArray = new int[n1];
        int[] RightArray = new int[n2];

        // Copy data to temporary arrays LeftArray[] and RightArray[]
        for (int i = 0; i < n1; i++)
            LeftArray[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            RightArray[j] = arr[middle + 1 + j];

        // Merge the temporary arrays back into arr[left..right]

        // Initial indices of first and second subarrays
        int leftIndex = 0, rightIndex = 0;

        // Initial index of merged subarray
        int mergedIndex = left;

        // Merge the arrays by comparing elements from both arrays
        while (leftIndex < n1 && rightIndex < n2)
        {
            if (LeftArray[leftIndex] <= RightArray[rightIndex])
            {
                arr[mergedIndex] = LeftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                arr[mergedIndex] = RightArray[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }

        // Copy any remaining elements of LeftArray[], if any
        while (leftIndex < n1)
        {
            arr[mergedIndex] = LeftArray[leftIndex];
            leftIndex++;
            mergedIndex++;
        }

        // Copy any remaining elements of RightArray[], if any
        while (rightIndex < n2)
        {
            arr[mergedIndex] = RightArray[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
    }

    // Main function that sorts arr[left..right] using merge()
    void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point
            int middle = left + (right - left) / 2;

            // Recursively sort the first and second halves
            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            // Merge the sorted halves
            Merge(arr, left, middle, right);
        }
    }

    // Utility function to print the array
    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    // Driver code to test the sorting algorithm
    public static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Given Array:");
        PrintArray(arr);

        MergeSort ob = new MergeSort();
        ob.Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nSorted array:");
        PrintArray(arr);
    }
}
