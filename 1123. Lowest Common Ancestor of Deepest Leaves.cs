/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    int max = int.MinValue;
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        if(root == null)
            return null;
        if(root.left == null && root.right == null)
            return root;
        TreeNode res = null;
        DFS(root, 0, ref res);
        return res;
    }
    
    public int DFS(TreeNode root, int depth, ref TreeNode res)
    {
        if(root.left == null && root.right == null)
            return depth;
        
       int left =   (root.left != null)? DFS(root.left, depth+1, ref res): 0;
             
       int right =  ( root.right != null)? DFS(root.right, depth+1, ref res):0;
        
             
       if(left == right && left >=max)
       {
           res = root;
           max = left;
       }
       else if ( left > max && left > right)
       {
           res = root.left;
           max = left;
       }
       else if(right > max && right > left)
       {
           res = root.right;
           max = right;
       }
        
       return Math.Max(left, right);

    }
}
/*
[0,1,3,null,2]
DFS

1. find the deepest depth 
2. add the nodes in that depth and its parent

if ( root.left == null && root.right == null)
{
    maxD = Max (maxD, currD) 
    
    leftD = DFS(left)
    rightD = DFS(right)
    
    if (leftD == rightD && leftD > max)
        add (left,right node);
    
}


depth  =0

DFS(left, depth+1)
 
 
 



*/
