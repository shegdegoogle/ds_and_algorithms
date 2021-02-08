public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        
        int[] inDegree = new int[numCourses];
        
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
            return new int[0];
        
        int[] res = new int[numCourses];
        int count =0;
        while(zeroDegree.Count() >0)
        {
            int course = zeroDegree.Pop();
            res[count++] = course;
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
                return new int[0];
        }      
        return res;
    }
}
