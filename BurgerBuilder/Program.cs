namespace BurgerBuilder
{
    class Program
    {
        static void Main()
        {
            QueshionFunc();

        }



        static void QueshionFunc()
        {
            Console.Write("hello, enter your name:");
            string? userName = Console.ReadLine();
            userName = userName?.ToLower();
            Console.WriteLine($"hello, {userName}");
            Console.WriteLine("Do you want our burger ? :)");


            Console.WriteLine("if you want  standart burgers choose : 1 ");
            Console.WriteLine("if you want built your own burger choose : 2 ");
            Console.Write("choose burger version there :");

            int burgerOpshion = Convert.ToInt32(Console.ReadLine());
            if (burgerOpshion == 1)
            {
                StandartBurgerMenu();
            }
            else
            {
                SelfBuild();

            }
        }


        //standart burger
        public static void StandartBurgerMenu()
        {
            Console.WriteLine(" You Choose standart burgers menu <3 ");
            Console.WriteLine(" There are burger list : ");

            List<string> burgers = new List<string>();

            burgers.Add("   hamburger");
            burgers.Add("   cheeseburger");
            burgers.Add("   brandburger");

            foreach (string burgerList in burgers)
            {
                Console.WriteLine(burgerList);
            }





            Console.Write(" choose which one do you want - ");
            string? burgerInput = Console.ReadLine();
            burgerInput = burgerInput?.ToLower();
            if (burgerInput == "hamburger")
            {

                Console.WriteLine(" You Choose Hamburger, there are hamburger ingredient list : ");
                Hamburgerlist();
            }
            else if (burgerInput == "cheeseburger")
            {
                Console.WriteLine(" You Choose cheeseburger, there are cheeseburger ingredient list : ");
                Chesburgerlist();
            }
            else if (burgerInput == "brandburger")
            {
                Console.WriteLine(" You Choose brandburger, there are brandburger ingredient list : ");
                BrandBurgerList();
            }
            else
            {
                Console.WriteLine("please, change name and wrote again !");
            }

            Console.WriteLine("  Enjoy it! Have a nice day !");


        }

        public static void Hamburgerlist()
        {
            List<string> burgersIngredients = new List<string>();

            burgersIngredients.Add("   breed");
            burgersIngredients.Add("   cheese");
            burgersIngredients.Add("   salad");
            burgersIngredients.Add("   pickled Cucumber");
            burgersIngredients.Add("   meat");
            burgersIngredients.Add("   sweet sauce");



            foreach (string burgerIngr in burgersIngredients)
            {
                Console.WriteLine(burgerIngr);
            }
        }
        public static void Chesburgerlist()
        {
            List<string> burgersIngredients = new List<string>();

            burgersIngredients.Add("   breed");
            burgersIngredients.Add("   cheese");
            burgersIngredients.Add("   salad");
            burgersIngredients.Add("   pickled Cucumber");
            burgersIngredients.Add("   spicy sauce");



            foreach (string burgerIngr in burgersIngredients)
            {
                Console.WriteLine(burgerIngr);
            }
        }
        public static void BrandBurgerList()
        {
            List<string> burgersIngredients = new List<string>();

            burgersIngredients.Add("   breed");
            //  burgersIngredients.Add("cheese");
            burgersIngredients.Add("   salad");
            burgersIngredients.Add("   pickled Cucumber");
            burgersIngredients.Add("   chicken");
            burgersIngredients.Add("   brand sauce");



            foreach (string burgerIngr in burgersIngredients)
            {
                Console.WriteLine(burgerIngr);
            }



        }



        // build burger
        public static void SelfBuild()
        {
            Console.WriteLine(" You Choose self builder burger menu :) ");
            Console.WriteLine(" Choose burger ingredients  :  ");
            List<string> burgersIngredientOfMyChoice = new List<string>();
            // foreach (string burgerbuilder in burgersIngredientOfMyChoice)
            // {
            //     Console.WriteLine(burgerbuilder);
            // }
            Console.WriteLine("   Do you want Salad ? [yes/no] ");
            string? salad = Console.ReadLine();
            salad = salad?.ToLower();
            if (salad == "yes")
            {
                burgersIngredientOfMyChoice.Add("salad");
            }

            Console.WriteLine("   Do you want Cheese ? [yes/no] ");
            string? cheese = Console.ReadLine();
            cheese = cheese?.ToLower();
            if (cheese == "yes")
            {
                burgersIngredientOfMyChoice.Add("cheese");
            }

            Console.WriteLine("   Do you want pickled Cucumber ? [yes/no] ");
            string? pickledCucumber = Console.ReadLine();
            pickledCucumber = pickledCucumber?.ToLower();
            if (pickledCucumber == "yes")
            {
                burgersIngredientOfMyChoice.Add("pickled Cucumber");
            }

            Console.WriteLine("   Which meat do  you want ? [ chicken / beef / none ] ");
            string? meat = Console.ReadLine();
            meat = meat?.ToLower();

            if (meat == "chicken")
            {
                burgersIngredientOfMyChoice.Add("chicken");
            }
            else if (meat == "beef")
            {
                burgersIngredientOfMyChoice.Add("beef");
            }
            else if (meat == "none")
            {
            }

            Console.WriteLine("   Which sauce do  you want ? [ spicy / sweet / brand / none ] ");
            string? sauce = Console.ReadLine();
            sauce = sauce?.ToLower();

            if (sauce == "spicy")
            {
                burgersIngredientOfMyChoice.Add("spicy sauce");
            }
            else if (sauce == "sweet")
            {
                burgersIngredientOfMyChoice.Add("sweet sauce");
            }
            else if (sauce == "brand")
            {
                burgersIngredientOfMyChoice.Add("brand sauce");
            }
            else if (sauce == "none")
            {
            }






            Console.WriteLine("         you choose burger, which has ingredients :");
            foreach (string burgerbuilder in burgersIngredientOfMyChoice)
            {
                Console.WriteLine(burgerbuilder);
            }

            Console.WriteLine("        You order burger, Congrat!  ");
            Console.WriteLine("    Will you order another burger? [yes / no]");
            string? orderAg = Console.ReadLine();
            orderAg = orderAg?.ToLower();
            if (orderAg == "yes")
            {
                OrderAgain();
            }
            else
            {
                Console.WriteLine("Goodbye :)");
            }





        }
        //order again
        public static void OrderAgain()
        {
            QueshionFunc();
        }


    }



}
