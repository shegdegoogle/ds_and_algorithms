
    /*
        public class TreeNode {
            public int val;
            public TreeNode left_ptr;
            public TreeNode right_ptr;
        }
    */
    
    /*
        Complete the funtion below
    */

// 965. Univalued Binary Tree


public static int findSingleValueTrees(TreeNode root){
        if(root == null)
            return 0;
        int total =0;
        helper(root, ref total);  
        return total;
            
    }
    
    public static bool helper(TreeNode root,  ref int total)
    {
        if(root.left_ptr == null && root.right_ptr == null)
        {
             total++;
             return true;
        }
               
        
        bool isUniVal = true;
        
        if(root.left_ptr != null)
        {
            isUniVal = helper(root.left_ptr, ref total) && root.val == root.left_ptr.val && isUniVal;
        }
        if(root.right_ptr != null)
        {
            isUniVal = helper(root.right_ptr, ref total) && root.val == root.right_ptr.val && isUniVal;
        }
        if (isUniVal) total++;
        return isUniVal;
    }
