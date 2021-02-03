/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        if(root == null)
            return null;
        HashSet<int> hs = new HashSet<int>();
        for(int i =0; i < nodes.Length; i++)
        {
            if(!hs.Contains(nodes[i].val))
                hs.Add(nodes[i].val);
        }
        TreeNode res = null;
        DFS(root, nodes, ref res, 0, hs);
        return res;
    }
    public int DFS(TreeNode root, TreeNode[] nodes, ref TreeNode res, int curr, HashSet<int> hs)
    {
        
        if (root.left != null)
        {
            curr += DFS(root.left, nodes, ref res, 0, hs);
        }
        
        if (root.right != null)
        {
            curr += DFS(root.right, nodes, ref res,0, hs);
        }
    
        if (hs.Contains(root.val))
        {
           curr++;
        }
        
        if( curr == hs.Count() && res == null)
            res = root;
        return curr;
        
    }
}
