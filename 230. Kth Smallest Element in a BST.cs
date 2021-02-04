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
 
 
 TC: O(log N * log K) ???????????
 SC: O(long N) + O(log K)
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        if(root == null)
            return -1;
        
        SortedSet<int> pqMax = new SortedSet<int>();
        pqMax.Add(int.MaxValue);
        
        Helper_Inorder(root, k, ref pqMax);
        
        return pqMax.Max();
        
    }
    
    public void Helper_Inorder(TreeNode root, int k, ref SortedSet<int> pqMax)
    {
        if(root!= null)
        {
           
            Helper_Inorder(root.left, k, ref pqMax);
            if( pqMax.Max() > root.val || pqMax.Count() < k)
            {
                  if(pqMax.Max() == int.MaxValue)
                       pqMax.Remove(pqMax.Max());
                  pqMax.Add(root.val);
            }
          
            if(pqMax.Count() > k)
            {
                pqMax.Remove(pqMax.Max());
            }
            if ( root.right != null && (pqMax.Max() < root.right.val && pqMax.Count() < k) ) 
               Helper_Inorder(root.right, k, ref pqMax);
        }
    }
}
