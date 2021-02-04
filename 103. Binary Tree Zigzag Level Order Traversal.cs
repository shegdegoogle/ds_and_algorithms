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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if(root == null)
        return new List<IList<int>>();;
        Queue<TreeNode> st = new Queue<TreeNode>();
        st.Enqueue(root);
        IList<IList<int>> res = new List<IList<int>>();
        
        int level = 0;
        while (st.Count() >0)
        {
            int count = st.Count();
            LinkedList<int> tempRes = new LinkedList<int>(); // Insert at front is just O(1)
            
            while(count > 0)
            {
                
                TreeNode temp = st.Dequeue();
                
                if(temp.left != null)
                        st.Enqueue(temp.left);
                if(temp.right != null)
                        st.Enqueue(temp.right);
                
                if (level %2 == 0)
                {
                    tempRes.AddLast(temp.val);
                }
                else
                {
                    tempRes.AddFirst(temp.val);
                }
                
                count--;
            }
            level++;
            res.Add(tempRes.ToList());
        }
        
        return res;
    }
}
