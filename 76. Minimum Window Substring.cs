public class Solution {
    public string MinWindow(string s, string t) {
      
        int n = s.Length;
        int min = int.MaxValue;
        int count = 0;
        Dictionary<char, int> dict = new  Dictionary<char, int>();
        for(int i =0; i < t.Length; i++)
        {
            if(dict.ContainsKey(t[i]))
            {
                dict[t[i]]++;
            }
            else
            {
                dict.Add(t[i], 1);
                count++;
            }
        }
       
        
       int start =0;
       int end =0;
       string res ="";
       while(end < n)
       {
           if(dict.ContainsKey(s[end]))
           {
               dict[s[end]]--;
               if(dict[s[end]] ==0)
                    count--;
              
           }
           end++;
           while(count == 0)
           {
               
               if(end-start < min)
               {
                   min = end-start;
                   res = s.Substring(start,min);
         
               }
              
               if(dict.ContainsKey(s[start]))
               {
                   dict[s[start]]++;
                   if(dict[s[start]] >0)
                       count++;
               }
               start++;
           }
           
            
       }
        
        
    return res;
        
    }
}




// O(N+M)
// O(M)
