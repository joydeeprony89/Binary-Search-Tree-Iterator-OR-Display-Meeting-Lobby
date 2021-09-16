using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree_Iterator_OR_Display_Meeting_Lobby
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode("Jeanette");
            root.left = new TreeNode("Elia");
            root.right = new TreeNode("Latasha");
            root.left.left = new TreeNode("Caryl");
            root.left.right = new TreeNode("Elvira");
            root.right.left = new TreeNode("Lala");
            root.right.right = new TreeNode("Lyn");
            root.left.left.left = new TreeNode("Antoinette");
            root.left.left.right = new TreeNode("Charity");
            root.left.right.right = new TreeNode("Iliana");
            root.right.left.left = new TreeNode("Kandice");
            root.left.left.left.left = new TreeNode("Albert");
            root.left.left.left.right = new TreeNode("Anya");
            root.left.left.right.left = new TreeNode("Cassie");
            root.left.left.right.right = new TreeNode("Cherlyn");
            DisplayLobby lobby = new DisplayLobby(root);
            var participants = lobby.Next_Page();
            Console.WriteLine(string.Join(",", participants));
            participants = lobby.Next_Page();
            Console.WriteLine(string.Join(",", participants));
            participants = lobby.Next_Page();
            Console.WriteLine(string.Join(",", participants));
        }
    }

    public class TreeNode
    {
        public string val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(string val = "", TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class DisplayLobby
    {
        readonly Stack<TreeNode> stack;
        public DisplayLobby(TreeNode node)
        {
            stack = new Stack<TreeNode>();
            Push_All(node);
        }

        public void Push_All(TreeNode node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
        }

        public string Next_Name()
        {
            var next = stack.Pop();
            Push_All(next.right);
            return next.val;
        }

        public bool Has_Next()
        {
            return stack.Count > 0;
        }

        public List<string> Next_Page()
        {
            List<string> result = new List<string>();
            int counter = 10;
            while (counter-- > 0)
            {
                if (Has_Next())
                    result.Add(Next_Name());
            }

            return result;
        }
    }
}
