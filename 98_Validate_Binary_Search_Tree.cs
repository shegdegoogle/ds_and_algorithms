    public static bool isBST(TreeNode root){
       
       return HelperIsBst(root, int.MinValue, int.MaxValue);
    }
    
    public static bool HelperIsBst(TreeNode root, int min, int max)
    {
        if(root == null)
                return true;
        if(root.val < min || root.val > max )
                return false;
        
        return HelperIsBst(root.left_ptr, min, root.val) &&  HelperIsBst(root.right_ptr, root.val, max);
       
    }
