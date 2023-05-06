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
     this.grid[r,c] = '\0';
    }
   }
  }

  static void Main(string[] args){
   Grid grid = new Grid(3);
   System.Console.WriteLine(grid[1,1]);
   x_Player p1 = x_Player.Instance;
   System.Console.WriteLine(p1.letter);
   y_Player p2 = y_Player.Instance;
   System.Console.WriteLine(p2.letter);
  }
 }

 public abstract class Player<T> where T : class, new(){
  private static readonly Lazy<T> instance = new Lazy<T>(() => CreateInstanceofT());

  public static T Instance{
   get{
    return instance.Value;
   }
  }

  private static T CreateInstanceofT(){
   return Activator.CreateInstance(typeof(T), true) as T;
  }
 }

 class x_Player : Player<x_Player>{
  public char letter = 'x';
 }

 class y_Player : Player<y_Player>{
  public char letter = 'o';
 }
}


