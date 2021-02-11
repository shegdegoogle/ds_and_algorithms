// DP, TC: O(N), SC:O(N)

public class Solution {
    public int Trap(int[] height) {
        
        int n = height.Length;
        if(n ==0)
        {
            return 0;
        }
        
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        
        leftMax[0] = height[0];
        rightMax[n-1] = height[n-1];
        
        // Find max at each unit from left
        for(int i =1; i < n; i++)
        {
            leftMax[i] = Math.Max(height[i], leftMax[i-1]);
        }
        
        // Find max at each unit from right
        for(int i = n-2; i >=0; i--)
        {
            rightMax[i] = Math.Max(height[i], rightMax[i+1]);
        }
        
        int total =0;
        // find actual space to fill water 
        for(int i =0; i< n; i++)
        {
            total += Math.Min(leftMax[i],rightMax[i])-height[i];
        }
        
        return total;
    }
}
