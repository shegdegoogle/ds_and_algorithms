public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res = new List<IList<int>>();
        if(numRows ==0)
            return res;
        
         IList<int> prevRow = new List<int>(); 
        
         prevRow.Add(1);
        
         res.Add(prevRow);
        
         for(int i =1; i<numRows; i++)
         {
             prevRow = res[i-1];
             int prevRowCount =prevRow.Count();
             IList<int> currRow = new List<int>(); 
             currRow.Add(1);
             
             for(int j =1; j < prevRowCount; j++)
             {
                 currRow.Add(prevRow[j] + prevRow[j-1]);
             }
             
             currRow.Add(1);
             res.Add(currRow);
         }
        return res;
    }
}
