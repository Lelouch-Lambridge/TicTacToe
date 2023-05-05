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
   Player p1 = new Player();
   Player p2 = new Player(); 
   Player p3 = new Player(); 
   System.Console.WriteLine(p1.player);
   System.Console.WriteLine(p2.player);
   System.Console.WriteLine(p3.player);
  }
 }

 class Player{
  private static int players = 0;
  public char player = '0';
  public Player(){
   if (players < 1){
    player = 'x';
    players++;
   } else if (players < 2){
    player = 'o';
    players++;
   }
   
  }
 }
}