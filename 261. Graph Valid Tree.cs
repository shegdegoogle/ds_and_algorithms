public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // Visited should only ocntains 1's
        // all nodes must be visted in one DFS/BFS
        
        // Graph
        Dictionary<int, List<int>> adjList =  new Dictionary<int, List<int>>();
        foreach(var edge in edges)
        {
            if(adjList.ContainsKey(edge[0]))
            {
                adjList[edge[0]].Add(edge[1]);
            }
            else
            {
                var temp = new List<int>();
                temp.Add(edge[1]);
                adjList.Add(edge[0], new List<int>(temp));
            }
            
            
            if(adjList.ContainsKey(edge[1]))
            {
                adjList[edge[1]].Add(edge[0]);
            }
            else
            {
                var temp = new List<int>();
                temp.Add(edge[0]);
                adjList.Add(edge[1], new List<int>(temp));
            }
        }
        
        
        // Visited
        int[] visited = new int[n];
        int[] parent = new int[n];
        int connected = 0;
        
        for(int i =0; i <n ; i++)
        {
            
            if(visited[i] == 0)
            {
                if(connected == 1)
                {
                    return false;
                }
                connected++;
                if(!DFS(i,  ref adjList, ref visited, ref parent))
                    return false;
            }
        }
        
        return true;
    }
    
    public bool DFS(int node, ref Dictionary<int, List<int>> adjList, ref int[] visited, ref int[] parent )
    {
        visited[node] ++;
        if(visited[node] >1)
            return false;

        if (adjList.ContainsKey(node))
        {
            foreach(var edge in adjList[node])
            {
                if(visited[edge] ==0)
                {
                    parent[edge] = node;
                    if(!DFS(edge, ref adjList, ref visited, ref parent))
                         return false;
                }
                else
                {
                    if(parent[node] != edge)
                        return false;
                }
            }
        }
       return true;
    }
    
}
