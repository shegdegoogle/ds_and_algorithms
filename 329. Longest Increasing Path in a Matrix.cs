/// TC: n*m SC: n*m

public class Solution {
    int[][] cache;
    public int LongestIncreasingPath(int[][] matrix) {
  
        int row = matrix.Length;
        int col = matrix[0].Length;
        
        cache = new int[row][];
        for (int i = 0; i < row; i++)
        {
             cache[i] = new int[col];
        }
           
        int result = int.MinValue;
        for(int i =0; i < row; i++)
        {
            for(int j =0 ; j < col; j++)
            {
                result = Math.Max(result, DFS(matrix, i, j, row, col));
            }
        }
        
        return result;
    }
    
    public int DFS(int[][] matrix, int i, int j, int row, int col)
    {
        if(cache[i][j]!=0)
            return cache[i][j];
       
        int curr = matrix[i][j];
        if( i < row -1 && matrix[i+1][j] > curr )
             cache[i][j] = Math.Max(cache[i][j], DFS(matrix, i+1, j, row, col));
        if(i > 0 && matrix[i-1][j] >curr)
             cache[i][j] = Math.Max(cache[i][j], DFS(matrix, i-1, j, row, col));
        if(j < col-1 && matrix[i][j+1] >curr)
             cache[i][j] = Math.Max(cache[i][j], DFS(matrix, i, j+1, row, col));
        if(j > 0 && matrix[i][j-1] > curr)
             cache[i][j] = Math.Max(cache[i][j], DFS(matrix, i, j-1, row, col));
        
        cache[i][j]++;
        
        return cache[i][j];
        
    }
}
