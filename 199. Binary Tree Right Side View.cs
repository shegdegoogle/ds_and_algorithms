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
 
TC: O(N)
SC: O(Q) +O(N), where Q is the size of the queue, O(N) for output
 */
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if(root == null)
            return new List<int>();
        
        Queue<TreeNode> st = new Queue<TreeNode>();
        st.Enqueue(root);
        IList<int> res = new List<int>();
        while (st.Count() >0)
        {
            int count = st.Count();
            
            while(count > 0)
            {
                
                TreeNode temp = st.Dequeue();
                if (count ==1)
                res.Add(temp.val);
                
                if(temp.left != null)
                    st.Enqueue(temp.left);
                if(temp.right != null)
                    st.Enqueue(temp.right);
                count--;
            }
        }
        
        return res;
    }
}
