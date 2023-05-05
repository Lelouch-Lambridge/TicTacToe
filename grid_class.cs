using System;
  
namespace TicTacToe {
 class Grid {
  public char[,] grid;
  public int size;

  public Grid(int size){
   this.size = size;
   grid = new char[size,size];
  }

  public char this[int index1,int index2]{
   get{
    return grid[index1,index2];
   }
   set{
    grid[index1,index2] = value;
   }
  }

  static void Main(string[] args){
   Grid grid = new Grid(3);
   char duff = 'o';
   for (int i = 0; i < grid.size; i++){
    for (int j = 0; j < grid.size; j++){
     grid[i,j] = duff;
     if (duff == 'x'){
      duff = 'x';
     } else {
      duff = 'o';
     }
    }
   }
  }
 }
}
