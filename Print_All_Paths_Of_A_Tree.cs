
    /*
        public class TreeNode {
            public int val;
            public TreeNode left_ptr;
            public TreeNode right_ptr;
        }
    */
    
    /*
        Complete the function below
        Input: root of the input tree
        Output: A list of integer lists denoting the node values of the paths of the tree
    */
    static List<List<int> > allPathsOfABinaryTree(TreeNode root){
        if(root == null)
            return new List<List<int>>();
        List<List<int>> res = new List<List<int>>();
        List<int> curr = new List<int>();
        Helper(root, curr, res);
        
        return res;
    }
    
    static void Helper(TreeNode root,List<int> curr, List<List<int>> res )
    {
        if( root == null )
        { 
            return;
        }
        
        curr.Add(root.val);
        if(root.left_ptr == null && root.right_ptr == null)
        {
            res.Add ( new List<int>(curr));
        }
        
        Helper(root.left_ptr, curr, res);
        Helper(root.right_ptr, curr, res);
        curr.RemoveAt(curr.Count()-1);
    } 
    
