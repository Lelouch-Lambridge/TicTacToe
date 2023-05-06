using System;
  
namespace TicTacToe {
 class Grid {
  private char[,] grid;
  private int size;

  public Grid(int size){
   this.size = size;
   this.grid = new char[size,size];
   clear();
  }

  public char this[int index1,int index2]{
   get{
    return grid[index1,index2];
   }
   set{
    grid[index1,index2] = value;
   }
  }

  public void turn(char ch, int r, int c){
   this.grid[r,c] = ch;
  }

  private void clear(){
   for (int r = 0; r < size; r++){
    for (int c = 0; c < size; c++){
     grid[r,c] = '\0';
    }
   }
  }
 }

 public abstract class Player<T> where T : class, new(){
  private static readonly Lazy<T> instance = new Lazy<T>(() => CreateInstanceofT());

  private static T CreateInstanceofT(){
   return Activator.CreateInstance(typeof(T), true) as T;
  }
  public static T Instance{
   get{
    return instance.Value;
   }
  }
 }

 class x_Player : Player<x_Player>{
  public char letter = 'x';
 }

 class y_Player : Player<y_Player>{
  public char letter = 'o';
 }

 class Game{

  static void Main(string[] args){
   Grid grid = new Grid(3);
   System.Console.WriteLine(grid[1,1]);
   x_Player p1 = x_Player.Instance;
   System.Console.WriteLine(p1.letter);
   y_Player p2 = y_Player.Instance;
   System.Console.WriteLine(p2.letter);

   grid.turn(p1.letter,2,1);
   System.Console.WriteLine(grid[2,1]);
  }
 }
}