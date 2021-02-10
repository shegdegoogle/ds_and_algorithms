public class Solution {
    public bool IsBipartite(int[][] graph) {
        
        Dictionary<int, int> visited = new Dictionary<int, int>();
        for(int i =0 ; i < graph.Length;i++)
        {
            visited.Add(i,-1);
        }
        
        for(int i =0; i < visited.Count() ; i++)
        { 
            if(visited[i] == -1)
            {
            
                if(!DFS(i, 0, ref visited, ref graph ))
                    return false;
            }
        }
        return true;
    }
    
    public bool DFS(int node, int color , ref Dictionary<int, int> visited, ref int[][] graph)
    {
     
        visited[node] = color;
        
            for(int i = 0; i < graph[node].Length; i++)
            {
                
                if(visited[graph[node][i]] == -1)
                {
                    
                    if(!DFS(graph[node][i], 1-color, ref visited, ref graph))
                        return false;
                }
                else if (visited[graph[node][i]] == color)
                    return false;
            }
      
        return true;
        
    }
}
