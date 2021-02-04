/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        
          if(root == null)
            return new List<IList<int>>();;
        Queue<Node> st = new Queue<Node>();
        st.Enqueue(root);
        IList<IList<int>> res = new List<IList<int>>();
        while (st.Count() >0)
        {
            int count = st.Count();
            IList<int> tempRes = new List<int>();
            while(count > 0)
            {
                
                Node temp = st.Dequeue();
                tempRes.Add(temp.val);
                foreach(var child in temp.children)
                {
                    st.Enqueue(child);
                }
                count--;
            }
               
            res.Add(tempRes);
        }
        
        return res;
    }
}
