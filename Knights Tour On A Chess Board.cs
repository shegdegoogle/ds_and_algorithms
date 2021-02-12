    /*
     * Complete the function below.
2
7
0
5
1
1
== -1

     */
    static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col) {
        
        // Queue for BFS
        Queue<int[]> bfs = new Queue<int[]>();
        
        // visited for not going to same location
        Dictionary<string,bool> visited = new Dictionary<string,bool>();
        
        // enqueue start position , count no of BFS pop queue
        int[] start = new int[3]{start_row,start_col,0};
        bfs.Enqueue(start);
        
        //Console.WriteLine($"{start_row}{start_col}");
        visited.Add($"{start_row}{start_col}", true);
    
        while(bfs.Count() >0)
        {
            int count = bfs.Count();
            
            var curr = bfs.Dequeue();
            
            if(curr[0] == end_row && curr[1] == end_col)
            {
                return curr[2];
            }
            
            var nextMoves = Directions(rows, cols, curr[0], curr[1]);
  
            foreach( var next in nextMoves)
            {
                string nextKey = $"{next[0]}{next[1]}";
                if(!visited.ContainsKey(nextKey))
                {
                     visited.Add(nextKey, true);
                     int[] startnext = new int[3]{next[0],next[1], curr[2]+1};
                     bfs.Enqueue(startnext);
                }
            }
        }
        
        return -1;

    }
  
   static List<int[]> Directions(int row, int col, int i, int j)
   {
       
       List<int[]> res = new List<int[]>();
       
       // first set 
       
       if(i -2 >=0 && j -1 >=0)
       {
           int[] temp = new int[2];
           temp[0] = i-2;
           temp[1] = j-1;
           res.Add(temp);
       }
       
       if(i -2 >=0 && j + 1 < col)
       {
           int[] temp = new int[2];
           temp[0] = i-2;
           temp[1] = j+1;
           res.Add(temp);
       }
       
       
       if(i +2 < row && j - 1 >= 0)
       {
           int[] temp = new int[2];
           temp[0] = i+2;
           temp[1] = j-1;
           res.Add(temp);
       }
       
       if(i +2 < row && j + 1 < col)
       {
           int[] temp = new int[2];
           temp[0] = i+2;
           temp[1] = j+1;
           res.Add(temp);
       }
       
       // 2nd set
       if(i-1 >=0 && j -2 >=0)
       {
           int[] temp = new int[2];
           temp[0] = i-1;
           temp[1] = j-2;
           res.Add(temp);
       }
       
       if(i -1 >=0 && j + 2 < col)
       {
           int[] temp = new int[2];
           temp[0] = i-1;
           temp[1] = j+2;
           res.Add(temp);
       }
       
       
       if(i +1 < row && j - 2 >= 0)
       {
           int[] temp = new int[2];
           temp[0] = i+1;
           temp[1] = j-2;
           res.Add(temp);
       }
       
       if(i +1 < row && j + 2 < col)
       {
           int[] temp = new int[2];
           temp[0] = i+1;
           temp[1] = j+2;
           res.Add(temp);
       }
       
       return res;
   }
