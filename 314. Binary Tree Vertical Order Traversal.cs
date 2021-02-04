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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
         IList<IList<int>> res = new List<IList<int>>();
        if(root ==null)
            return res;
        Dictionary<int, List<int>> d = new Dictionary<int,List<int>>();

        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
        
        q.Enqueue((root, 0));
        int min = int.MaxValue;
        int max = int.MinValue;
        while(q.Count() >0)
        {
            int count = q.Count();
            
            while(count >0)
            {
                (TreeNode node, int col) = q.Dequeue();
                if(d.ContainsKey(col))
                {
                    d[col].Add(node.val);
                }
                else
                {
                    List<int> tempList = new List<int>();
                    tempList.Add(node.val);
                    d.Add(col, new List<int>(tempList) );
                }
                
                if(node.left!= null)
                   q.Enqueue((node.left, col-1));  
                if(node.right!= null)
                   q.Enqueue((node.right, col+1));  
                
                max = Math.Max(max, col);
                min = Math.Min(min, col);
                
                count--;
            }
        }
        
        for(int i = min; i <= max; i++)
        {
           
            res.Add(new List<int>(d[i]));
        }
        
     return res;
    }
        
}     
  
