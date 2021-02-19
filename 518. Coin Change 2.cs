public class Solution {
    public int Change(int amount, int[] coins) {
        
        int m = amount+1;
        int n = coins.Length;
        int[][] dp = new int[n+1][]; // O(N * Amount)
        
        for(int i =0; i<= n; i++)
        {
            dp[i] = new int[m];
        }
        
        // Base case
        for(int i =1; i<= n; i++)
        {
            dp[i][0] = 1;
        }
        
        for(int i =1; i< m; i++)
        {
            dp[0][i] = 0;
        }
        
        dp[0][0] = 1;
        
        // DP formula
        for(int i = 1 ; i<= n ; i++ ) // coins O(N)
        {
            for(int j = 1; j< m; j++) // amount O(Amount)
            {
                if(j - coins[i-1] >=0)
                {
                    dp[i][j] = dp[i-1][j]+ dp[i][j - coins[i-1]]; // using current coin + previou coins
                }
                else
                {
                    dp[i][j] = dp[i-1][j]; // wihout current coin
                }
            }
        }
        
        return dp[n][amount];
        
    }
}

// TC: O(N * Amount), SC: (N * Amount) --> This can be reduced 1D array so the Space Complexity will be O(amount)
