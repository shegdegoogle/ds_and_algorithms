public class Solution {
    public string MinWindow(string S, string T) {
        
        string res ="";
        int n = S.Length;
        int m = T.Length;
        int j =0;
        
        for(int i =0; i < n; i++)
        {
            if(S[i] == T[j])
            {
                j++;
                if(j >= m)
                {
                    int end = i+1;
                    j--;
                    while(j >=0)
                    {
                        if(S[i] == T[j])
                        {
                            j--;
                        }
                        i--;
                    }
                    i++;
                   
                    string temp = S.Substring(i, end-i);
                    if(res.Length == 0 || temp.Length < res.Length)
                    {
                        res = temp;
                    }
                    j = 0;
                }
            }
        }
        
        return res;
    }
}

// O(nm), O(1)
