/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/

public class Solution {
   
    public Node TreeToDoublyList(Node root) {
        if( root == null)
            return null;
    Node head = null;
    Node last = null;
         Helper(root, ref last, ref head);
         last.right = head;
         head.left = last;
        
       return head;
        
        
    }
    
    public void Helper(Node root, ref Node last, ref Node head)
    {
     
        if( root == null)
            return;
        else
        {
            Helper(root.left, ref last, ref head );
           
            if( last != null)
            {
                last.right = root;
                root.left = last;
            }
            else
            {
                head = root;
            }
           
            last = root;
            
            Helper(root.right ,ref last, ref head);
            
        }
        
    }
}
