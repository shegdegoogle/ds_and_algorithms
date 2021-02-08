public class Solution {
    public string AlienOrder(string[] words) {
        StringBuilder sb = new StringBuilder();
        
       // Step 0: Create data structures and find all unique letters.
        Dictionary<char,List<char>> graph = new Dictionary<char, List<char>>();
        Dictionary<char, int> inDegree = new Dictionary<char,int>();
        
        foreach(var word in words)
        {
            foreach(var c in word)
            {
                if(!inDegree.ContainsKey(c))
                {
                    inDegree.Add(c,0);
                    graph.Add(c, new List<char>());
                }
            }
        }
        
        for (int i = 0; i < words.Length - 1; i++) 
        {
            string word1 = words[i];
            string word2 = words[i + 1];
            if(word1.Length > word2.Length && word1.StartsWith(word2)) // avoid word like wzy, wz as lexicographically this false
                return "";
            for(int j =0; j < (Math.Min(word1.Length, word2.Length)); j++)
            {
                if(word1[j] != word2[j])
                {
                    var outChar = word1[j];
                    var inChar = word2[j];
                  
                    graph[outChar].Add(inChar);
                    inDegree[inChar]++;
                     break;
                }
            }
            
        }
        
        Queue<char> zeroDegree = new Queue<char>();
        foreach(var c in inDegree)
        {
            if(c.Value == 0)
            {
           
                zeroDegree.Enqueue(c.Key);
            }
                
        }
        
        if(zeroDegree.Count() == 0)
            return "";
 
        
        while (zeroDegree.Count() >0)
        {
            var tempC = zeroDegree.Dequeue();
            sb.Append(tempC);
          
                foreach(var edge in graph[tempC])
                {
                    inDegree[edge] -=1;
                 
                    if(inDegree[edge] == 0)
                    {
                  
                          zeroDegree.Enqueue(edge);
                    }
                      
                }
        }
        if (sb.Length != graph.Count())
            return "";
        return sb.ToString();
    }
}
