public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int[] inDegree = new int[numCourses];
        
        //O(v)
        for(int i =0; i < prerequisites.Length; i++)
        {
            inDegree[prerequisites[i][0]]++;
        }
        
        Stack<int> zeroDegree = new Stack<int>();
        
        for(int j =0; j < numCourses ;j++)
        {
            if(inDegree[j] == 0)
            {
               zeroDegree.Push(j);
            }
        }
        
        if(zeroDegree.Count() == 0)
            return false;
            
        //O(E)
        while(zeroDegree.Count() >0)
        {
            int course = zeroDegree.Pop();
             
            for(int k = 0; k < prerequisites.Length; k++)
            {
                if( prerequisites[k][1] == course)
                {
                   
                    inDegree[prerequisites[k][0]]--;
                    if(inDegree[prerequisites[k][0]] == 0)
                    {
                     
                         zeroDegree.Push(prerequisites[k][0]);
                    }
                }    
            }
        }
                                              
        for(int x =0; x < numCourses ;x++)
        {
            if(inDegree[x] != 0)
                return false;
        }      
        return true;
    }
}

/*

TC : O(V+E)
S : O(V)






*/
