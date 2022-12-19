using System;
using System.Linq;

namespace MoveElementToEnd
{

    class Program
        {
            static void Main(string[] args)
            {
                var array = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
                var toMove = 2;

                MoveElement.MoveElementsToEnd(array, toMove);
               
            }
        }
    
}