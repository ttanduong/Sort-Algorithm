using System;

namespace SortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] exampleArray = new int[] { 175, 103, 187, 181, 129, 164, 122, 124 };
			Sort sort = new Sort();

			for (int i = 0; i < exampleArray.Length; i++)
			{
				Console.Write(exampleArray[i] + " ");
			}
			Console.WriteLine();

			//sort.InsertionSortReverse(exampleArray);
			//sort.SelectionSort(exampleArray);
			//sort.MergeSort(exampleArray, 0, exampleArray.Length - 1);
			sort.HeapSort(exampleArray);

			for (int i = 0; i < exampleArray.Length; i++)
			{
				Console.Write(exampleArray[i] + " ");
			}
		}
    }
}
