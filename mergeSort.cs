public class MergeSortExample
{
     public static void Main(string[] args)
    {
        int[] array = new int[5];
        int a = 0;

        Console.WriteLine("Geben Sie fuenf Nummern die zu sortieren sind ein:");
        while (a < 5)
        {
            if (int.TryParse(Console.ReadLine(), out array[a]))
                a++;
            else //failcatch keine nummer wird eingegeben
                Console.WriteLine("Ohhhoo, das war keine Nummer!\r\n Geben Sie bitte eine gueltige Nummer ein");
        }
       
        Console.WriteLine("Ihre unsortierte Liste lautet:\r\n [{0}]", string.Join(", ", array));

        var ArraySorted = MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("Ihre nach groesse sortierte Liste:\r\n [{0}]", string.Join(", ", ArraySorted));
    }

    private static int[] MergeSort(int[] array, int start, int end)
    {
        if (start < end)
        {
            int mid = (end + start) / 2;
            int[] ArrayLeftSide = MergeSort(array, start, mid);
            int[] ArrayRightSide = MergeSort(array, mid + 1, end);
            int[] ArrayMerged = MergeArray(ArrayLeftSide, ArrayRightSide);
            return ArrayMerged;
        }
        return new int[] { array[start] };
    }

    private static int[] MergeArray(int[] ArrayLeftSide, int[] ArrayRightSide)
    {
        int[] ArrayMerged = new int[ArrayLeftSide.Length + ArrayRightSide.Length];

        int IndexLeft = 0;
        int IndexRight = 0;
        int IndexMerged = 0;

        //speichert kleinste Elemente von beiden Arrays in ArrayMerge
        while (IndexLeft < ArrayLeftSide.Length && IndexRight < ArrayRightSide.Length)
        {
            if (ArrayLeftSide[IndexLeft] < ArrayRightSide[IndexRight])
            {
                ArrayMerged[IndexMerged++] = ArrayLeftSide[IndexLeft++];
            }
            else
            {
                ArrayMerged[IndexMerged++] = ArrayRightSide[IndexRight++];
            }
        }

        // letztes element wird MergeArray hinzugefuegt
        while (IndexLeft < ArrayLeftSide.Length)
        {
            ArrayMerged[IndexMerged++] = ArrayLeftSide[IndexLeft++];
        }

        //letztes Element wird MergeArray hinzugefuegt
        while (IndexRight < ArrayRightSide.Length)
        {
            ArrayMerged[IndexMerged++] = ArrayRightSide[IndexRight++];
        }

        return ArrayMerged;
    }
}
