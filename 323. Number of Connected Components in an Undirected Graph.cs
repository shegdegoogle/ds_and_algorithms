public class Solution {
    public int CountComponents(int n, int[][] edges) {
       // AdjList
        Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();     
        foreach(var edge in edges)
        {
            if(!adjList.ContainsKey(edge[0]))
            {
                var temp = new List<int>();
                temp.Add(edge[1]);
                adjList.Add(edge[0], new List<int>(temp));
                
            }
            else
            {
                adjList[edge[0]].Add(edge[1]);
            }
            
             if(!adjList.ContainsKey(edge[1]))
            {
                var temp = new List<int>();
                temp.Add(edge[0]);
                adjList.Add(edge[1], new List<int>(temp));
            }
            else
            {
                 adjList[edge[1]].Add(edge[0]);
            }
            
        }
       // Visited 
        int[] visited = new int[n];
      
        // Call DFS/BFS to find no of components 
        int component =0;
        for(int i =0; i <n ;i++)
        {
            if(visited[i] == 0)
            {
                component++;
                DFS(i, ref adjList , ref visited );
            }
        }
        return component;
    }
    
    public void DFS(int node, ref Dictionary<int, List<int>> adjList, ref int[] visited )
    {
        visited[node] = 1;

        if (adjList.ContainsKey(node))
        {
             foreach(var edge in adjList[node])
            {
              
                if(visited[edge] == 0)
                {
                     DFS(edge, ref adjList, ref visited);
                }
            }
        }
       
    }
}
