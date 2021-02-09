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
 
 // TC: Visiting every node O(N) SC: HashMap space O(Log N) --> O(N) , auxilary space of call stack O(N)
public class Solution {
    public IList<IList<int>> FindLeaves(TreeNode root) {
        
        IList<IList<int>> res = new List<IList<int>>();
        Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
        int max = int.MinValue;
        int min = int.MaxValue;
        
        
        DFS(root, ref d, ref max, ref min);
        
        for(int i = min; i<=max; i++)
        {
            if(d.ContainsKey(i))
            {
                 res.Add(new List<int>(d[i]));
            }
        }
        return res;
    }
    
    public int DFS(TreeNode root, ref Dictionary<int, List<int>> d, ref int max, ref int min)
    {
        if(root == null)
            return -1;
        
        int leftH = DFS(root.left, ref d , ref max, ref min);
        int rightH = DFS(root.right, ref d , ref max, ref min);
        
        int currH = Math.Max(leftH,rightH)+1;
        
        if(d.ContainsKey(currH))
        {
            d[currH].Add(root.val);
        }
        else
        {
            var temp = new List<int>();
            temp.Add(root.val);
            d.Add(currH, new List<int>(temp));
        }
        min = Math.Min(min, currH);
        max= Math.Max(max, currH);
        
        return currH+1;
    }
}
