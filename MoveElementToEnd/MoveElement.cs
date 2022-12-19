namespace MoveElementToEnd
{
    public class MoveElement
    {

        public static void MoveElementsToEnd(List<int> array, int ToMove)
        {

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == 2)
                {
                    ToMove++;

                    array.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < ToMove; i++)
            {

                array.Add(2);
            }

            for (int i = 0; i < array.Count; i++)
            {

                Console.Write(string.Join(", ", array[i]) + " ");
            }
        }

    }
    
}