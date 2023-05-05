using System;
  
namespace TicTacToe {
 class Grid {
  private char[,] grid;
  private int size;

  public Grid(int size){
   this.size = size;
   this.grid = new char[size,size];
   this.clear();
  }

  private char this[int index1,int index2]{
   get{
    return this.grid[index1,index2];
   }
   set{
    this.grid[index1,index2] = value;
   }
  }

  public void clear(){
   for (int r = 0; r < size; r++){
    for (int c = 0; c < size; c++){
     this.grid[r,c] = '0';
    }
   }
  }

  

  static void Main(string[] args){
   Grid grid = new Grid(3);
   System.Console.WriteLine(grid[1,1]);
  }
 }

 class Player{
  private int key;
  private char;
 }
}