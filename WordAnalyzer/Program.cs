
using System.Diagnostics;

namespace WordsAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();

            Thread counter = new(Counter);

            Thread thread1 = new(LongestWord);
            Thread thread2 = new(ShortestWord);
            //Thread thread3 = new(Top100Words); 

            counter.Start();
            thread1.Start();
            thread2.Start();
           // thread3.Start();



            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            return;

            
        }


        //finds all words which contains vowel

        public static void Top100Words()
        {

            string path = @"C:\Users\varda\Desktop\Practice4\practice 4\WordsAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
           

            int vowelCount = 0;
            int consCount = 0;
            var len = result.Length;
            for (int i = 0; i < len; i++)
            {
                if (result[i] == 'a' || result[i] == 'e' || result[i] == 'i' || result[i] == 'o' || result[i] == 'u' ||
                    result[i] == 'A' || result[i] == 'E' || result[i] == 'I' || result[i] == 'O' || result[i] == 'U')
                {
                    vowelCount++;

                }
                else
                {
                    consCount++;
                }
            }


            var vowel = vowelCount.ToString(result);
            Console.WriteLine(vowel);
        }


        public static void LongestWord()
        {
            Thread.Sleep(500);
            Console.WriteLine("Longest Word is found!");
            Thread.Sleep(1500);


            string path = @"C:\Users\varda\Desktop\Practice4\practice 4\WordsAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries));
          //  Console.WriteLine($"Number Of Words : {words.Count}");
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

            

        }

        public static void ShortestWord()
        {
            Thread.Sleep(500);
            Console.WriteLine("Shortest Word is found!");
            Thread.Sleep(1500);


            string path = @"C:\Users\varda\Desktop\CredoBankAssignments\WordAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries));
          //  Console.WriteLine($"Number Of Words : {words.Count}");
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
            
        }

        public static void Counter()
        {
            string path = @"C:\Users\varda\Desktop\CredoBankAssignments\WordAnalyzer\File\words_alpha.txt";
            string result = File.ReadAllText(path);
            var words = new List<string>(result.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"Number Of Words : {words.Count}");
        }

    }
}

