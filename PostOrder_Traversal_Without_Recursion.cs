
    /*
        public class TreeNode {
            public int val;
            public TreeNode left_ptr;
            public TreeNode right_ptr;
        }
    */    
    
    // Complete the function below.
    public static List<int> postorder_traversal(TreeNode root){
        if (root == null)
            return new List<int>();
       
        Stack<TreeNode> stk = new Stack<TreeNode>();
        List<int> res = new List<int>();
        
        stk.Push(root);
        TreeNode curr = root;
        while (stk.Count() >0)
        {
            curr = stk.Peek();
            if(curr.left_ptr != null)
            {
                stk.Push(curr.left_ptr);
                curr.left_ptr = null;
            }
            else if ( curr. right_ptr != null )
            {
                stk.Push(curr.right_ptr);
                curr.right_ptr = null;
            }
            else
            { 
                res.Add(stk.Pop().val);
            }
            
        }
        return res;
    }    
