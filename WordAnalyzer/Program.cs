
namespace WordsAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new(LongestWord);
            Thread thread2 = new(ShortestWord);

            thread1.Start();
            thread2.Start();

            //Task.Run(() => {
            //    ShortestWord();
            //});

            //Task.Run(() => {
            //    LongestWord();
            //});


            Console.ReadKey();
        }


        public static void TopWords()
        {
            string path = @"C:\Users\varda\Desktop\CredoBankAssignments\WordAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"Number Of Words : {words.Count}");


            if (words.Count > 0)
            {

                string longestWord = words[0];
                for (int i = 0; i < 100; i++)
                {

                    string item = words[i];
                    if (item.Length > longestWord.Length)
                    {
                        longestWord = item;

                    }
                }
                Console.WriteLine($"Longest Word: {longestWord}  \n Lenght is : {longestWord.Length} ");
            }





        }


        public static void LongestWord()
        {
            string path = @"C:\Users\varda\Desktop\Practice4\practice 4\WordsAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"Number Of Words : {words.Count}");
            if (words.Count > 0)
            {

                string longestWord = words[0];
                for (int i = 0; i < words.Count; i++)
                {
                    string item = words[i];
                    if (item.Length > longestWord.Length)
                    {
                        longestWord = item;

                    }
                }
                Console.WriteLine($"Longest Word in this file is : {longestWord}  \n Lenght is : {longestWord.Length} ");

            

            }

            Thread.Sleep(1500);
            Console.WriteLine("Longest Word is found!");

        }

        public static void ShortestWord()
        {
            // Thread.Sleep(2000);
            string path = @"C:\Users\varda\Desktop\CredoBankAssignments\WordAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"Number Of Words : {words.Count}");
            if (words.Count > 0)
            {

                string ShortestWord = words[0];
                for (int i = 0; i < words.Count; i++)
                {
                    string item = words[i];
                    if (item.Length < ShortestWord.Length)
                    {
                        ShortestWord = item;

                    }
                }
                Console.WriteLine($"Shortest Word in this file is: {ShortestWord} \n Lenght is : {ShortestWord.Length}   ");

            
            }
            Thread.Sleep(1000);
            Console.WriteLine("Shortest Word is found!");
        }

    }
}

