public class Program
{
    public class BinaryTreeNode
    {
        public int Value;
        public BinaryTreeNode? Left;
        public BinaryTreeNode? Right;

        public BinaryTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public static List<int> BranchSums(BinaryTreeNode root)
    {
        var sum = new List<int>();
        // ...

        MainBranchSum(root, 0, sum);
        return sum;
    }
    public static void MainBranchSum(BinaryTreeNode node, int lastSum, List<int> sumNodes)
    {

        if (node == null)
        {
            return;
        }


        var currentSum = lastSum + node.Value;


        while (node.Right == null && node.Left == null)
        {
            sumNodes.Add(currentSum);
            return;

        }

        MainBranchSum(node.Left, currentSum, sumNodes);
        MainBranchSum(node.Right, currentSum, sumNodes);

    }




    public static void Main()
    {
        var root = new BinaryTreeNode(1);

        root.Left = new BinaryTreeNode(2);
        root.Right = new BinaryTreeNode(3);

        root.Left.Left = new BinaryTreeNode(4);
        root.Left.Right = new BinaryTreeNode(5);
        root.Right.Left = new BinaryTreeNode(6);
        root.Right.Right = new BinaryTreeNode(7);

        root.Left.Left.Left = new BinaryTreeNode(8);
        root.Left.Left.Right = new BinaryTreeNode(9);

        root.Left.Right.Left = new BinaryTreeNode(10);

        var sums = BranchSums(root);
        Console.WriteLine(string.Join(", ", sums)); // უნდა გამოიტანოს 15, 16, 18, 10, 11
    }
}