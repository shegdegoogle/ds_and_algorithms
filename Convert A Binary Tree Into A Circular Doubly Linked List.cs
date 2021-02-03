
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

    public static TreeNode BTtoLL(TreeNode root){
        if(root == null)
            return null;
        
        TreeNode head = null;
        TreeNode last = null;
        
        Inorder_DFS(root, ref last, ref head);
        
        head.left_ptr = last;
        last.right_ptr = head;
        
        return head;
    }
    
    public static void Inorder_DFS(TreeNode root, ref TreeNode last, ref TreeNode head)
    {
        if( root == null)
            return;
        else
        {
            
            Inorder_DFS(root.left_ptr, ref last, ref head);
            if(head == null)
                head = root;
            if(last != null)
            {
                last.right_ptr = root;
                root.left_ptr = last;
            }
            
            last = root;
            Inorder_DFS(root.right_ptr, ref last, ref head);
        }
    }
/*
By SH: 
head , last -> last processes node 

head can only be left most node or root node 

once Inorder is completed Last node can only be root or right most node.

when root is null return back 

once we find the left mode node assign that to head 

DFS(left)
when last node is not null
   last.right = root
   root.left = last 
N:
 then node becomes last
DFS(right)

in main function before returning the result 

last.right = head
head.left = last

return head


*/
