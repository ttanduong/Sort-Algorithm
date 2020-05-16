using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class Sort
    {
		private const int INSERTION_THRESHOLD = 20;
		private const int SELECTION_THRESHOLD = 15;

		/* InsertionSort(int[] A)
		 * Description: Sort an array ascending order using insertion sort algorithm
		 * Param (int[] A): non-sorted array	
		 * Return: Non
		 */
		public void InsertionSort(int[] A)
		{
			for (int j = 1; j < A.Length; j++)
			{
				int key = A[j];
				int i = j - 1;

				//Insert A[j] into the sorted sequence A[0..j-1]
				//if the key is greater than some elements of that sequence
				while ((i >= 0) && (A[i] > key))
				{
					A[i + 1] = A[i];
					i--;
				}
				A[i + 1] = key;
			}
		}

		/* InsertionSortReverse(int[] A)
		 * Description: Sort an array descending order using insertion sort algorithm
		 * Param (int[] A): non-sorted array	
		 * Return: Non
		 */
		public void InsertionSortReverse(int[] A)
		{
			for (int j = A.Length - 2; j >= 0; j--)
			{
				int key = A[j];
				int i = j + 1;

				//Insert A[j] into the sorted sequence A[j+1..Length-1]
				//if the key is greater than some elements of that sequence
				while ((i <= A.Length - 1) && (A[i] > key))
				{
					A[i - 1] = A[i];
					i++;
				}
				A[i - 1] = key;
			}
		}

		/* InsertSortRecursion(int[] A, int length)
		 * Description: Sort an array descending order using insertion sort algorithm and recursion
		 * Param1 (int[] A): non-sorted array	
		 * Param2 (int[] length): length of A[]	
		 * Return: Non
		 */
		public void InsertSortRecursion(int[] A, int length)
		{
			//Array which has 1 element doesn't need to sort
			if (length <= 1) return;

			int j = length - 1;

			//Insert A[j] into the sorted sequence A[0..j-1]		
			//so need sequence A[0..j] has already been sorted first
			InsertSortRecursion(A, j);

			int key = A[j];
			int i = j - 1;

			while ((i >= 0) && (A[i] > key))
			{
				A[i + 1] = A[i];
				i--;
			}
			A[i + 1] = key;
		}

		/* SelectionSort(int[] A)
		 * Description: Sort an array ascending order using selection sort algorithm
		 * Param (int[] A): non-sorted array	
		 * Return: Non
		 */
		public void SelectionSort(int[] a)
		{
			for (int i = 0; i < a.Length - 1; i++)
			{
				int min = a[i];
				int minIndex = i;

				//Find the smallest element of sequence a[i..Length-1]
				for (int j = i; j < a.Length; j++)
				{
					if (a[j] < min)
					{
						min = a[j];
						minIndex = j;
					}
				}

				//Swap the smallest element with the fisrt element of sequence a[i..Length-1]
				if (minIndex != i)
				{
					a[minIndex] = a[i];
					a[i] = min;
				}
			}
		}

		/* ----------------------------- Merger Sort ------------------------------ */
		/* MergeSort(int[] A, int start, int end)
		 * Description: Sort an array ascending order using merge sort algorithm
		 * Param1 (int[] A): non-sorted array	
		 * Param2 (int start): index of the first element of A[]	
		 * Param3 (int end): index of the last element of A[]
		 * Return: Non
		 */
		public void MergeSort(int[] A, int start, int end)
		{
			if (start < end)
			{
				int mid = (int)(start + end) / 2;

				//Merge sort for first sub-array
				MergeSort(A, start, mid);

				//Merge sort for second sub-array
				MergeSort(A, mid + 1, end);

				//Merge 2 sorted sub-elements
				Merge(A, start, mid, end);
			}
		}

		/* Merge(int[] A, int start, int mid, int end)
		 * Description: Merge 2 sorted sub-arrays A[start..mid], A[mid+1..end] 
		 *              to obtain an ascending array using merge sort algorithm
		 * Param1 (int[] A): A[] which contains 2 sorted sub-arrays: A[start..mid], A[mid+1..end]
		 * Param2 (int start): index of the first element of A[]	
		 * Param3 (int mid): index of the middle element of A[]
		 * Param4 (int end): index of the last element of A[]
		 * Return: Non
		 */
		private void Merge(int[] A, int start, int mid, int end)
		{
			int[] L = new int[mid - start + 1];     //Left sub-array
			int[] R = new int[end - mid];       //Right sub-array

			//Copy elements of A[] array to L[] and R[] sub-array
			for (int i = 0; i < L.Length; i++)
			{
				L[i] = A[start + i];
			}
			for (int i = 0; i < R.Length; i++)
			{
				R[i] = A[i + mid + 1];
			}

			int lIndex = 0;     //Index of L[] sub-array
			int rIndex = 0;     //Index of R[] sub-array

			//Merge 2 sub-arrays back into array A[s..e]
			for (int i = start; i <= end; i++)
			{
				if (L[lIndex] < R[rIndex]) A[i] = L[lIndex++];
				else A[i] = R[rIndex++];

				//In case all elements of L[] has already been copied to A[]
				//Copy remaining elements of R[] sub-array back into A[]
				if (lIndex >= L.Length)
				{
					Array.Copy(R, rIndex, A, i + 1, R.Length - rIndex);
					break;
				}

				//In case all elements of R[] has already been copied to A[]
				//Copy remaining elements of L[] sub-array back into A[]
				if (rIndex >= R.Length)
				{
					Array.Copy(L, lIndex, A, i + 1, L.Length - lIndex);
					break;
				}
			}
		}

		/* MixMergeInsertion(int[] A, int start, int end)
		 * Description: Sort an array ascending order using merge and insertion sort algorithm
		 * Param1 (int[] A): non-sorted array	
		 * Param2 (int start): index of the first element of A[]	
		 * Param3 (int end): index of the last element of A[]
		 * Return: Non
		 */
		public void MixMergeInsertion(int[] A, int start, int end)
		{
			if (start < end)
			{
				if ((end - start + 1) <= INSERTION_THRESHOLD)
					InsertionSort(A);
				else
				{
					int mid = (int)(start + end) / 2;

					//Merge sort for first sub-array
					MergeSort(A, start, mid);

					//Merge sort for second sub-array
					MergeSort(A, mid + 1, end);

					//Merge 2 sorted sub-elements
					Merge(A, start, mid, end);
				}
			}
		}

		/* MixMergeSelection(int[] A, int start, int end)
		 * Description: Sort an array ascending order using merge and selection sort algorithm
		 * Param1 (int[] A): non-sorted array	
		 * Param2 (int start): index of the first element of A[]	
		 * Param3 (int end): index of the last element of A[]
		 * Return: Non
		 */
		public void MixMergeSelection(int[] A, int start, int end)
		{
			if (start < end)
			{
				if ((end - start + 1) <= SELECTION_THRESHOLD)
					SelectionSort(A);
				else
				{
					int mid = (int)(start + end) / 2;

					//Merge sort for first sub-array
					MergeSort(A, start, mid);

					//Merge sort for second sub-array
					MergeSort(A, mid + 1, end);

					//Merge 2 sorted sub-elements
					Merge(A, start, mid, end);
				}
			}
		}

		/* BubbleSort(int[] A)
		 * Description: Sort an array ascending order using bubble sort algorithm
		 * Param (int[] A): non-sorted array		
		 * Return: Non
		 */
		public void BubbleSort(int[] A)
		{
			for (int i = 0; i < A.Length - 1; i++)
			{
				for (int j = A.Length - 1; j > i; j--)
				{
					if (A[j] < A[j - 1])
					{
						int temp = A[j];
						A[j] = A[j - 1];
						A[j - 1] = temp;
					}
				}
			}
		}

		/* ----------------------------- Heap Sort ------------------------------ */
		/* MaxHeapify(int[] A, int i, int heapSize)
		 * Description: Apply the max-heap property for element index i:
		 *              A[i] >= A[left] AND A[i] >= A[right]
		 * Param (int[] A): non-sorted array	
		 * Param (int i): index of parent element
		 * Param (int heapSize): Heap size
		 * Return: Non
		 */
		private void MaxHeapify(int[] A, int i, int heapSize)
		{
			int left = 2 * i;			//index of left child
			int right = 2 * i + 1;      //index of right child
			int largest = i;

			if ((left <= heapSize) && (A[left] > A[i]))			
				largest = left;

			if ((right <= heapSize) && (A[right] > A[largest]))
				largest = right;

			if (largest != i)
			{
				int temp = A[i];
				A[i] = A[largest];
				A[largest] = temp;
				
				MaxHeapify(A, largest, heapSize);
			}
		}

		/* BuildMaxHeap(int[] A)
		 * Description: Build max heap for array A (root element will be largest)
		 * Param (int[] A): non-sorted array		
		 * Return: Non
		 */
		private void BuildMaxHeap(int[] A)
		{
			int heapSize = A.Length -1;

			for (int i = (A.Length - 1) / 2; i >= 0; i--)
			{
				MaxHeapify(A, i, heapSize);
			}
		}

		/* HeapSort(int[] A)
		 * Description: Sort an array ascending order using heap sort algorithm
		 * Param (int[] A): non-sorted array		
		 * Return: Non
		 */
		public void HeapSort(int[] A)
		{
			int heapSize = A.Length - 1;
			BuildMaxHeap(A);
			for (int i = A.Length - 1; i >= 1; i--)
			{
				int temp = A[0];
				A[0] = A[i];
				A[i] = temp;

				heapSize--;
				MaxHeapify(A, 0, heapSize);
			}
		}
	}
}
