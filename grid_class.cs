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

 public class Player{
  private static readonly Lazy<Player> x = new Lazy<Player>(() => new Player('x'));
  private static readonly Lazy<Player> o = new Lazy<Player>(() => new Player('o'));
  public char letter{get;}

  public static Player X{
   get{
    return x.Value;
   }
  }

  public static Player O{
   get{
    return o.Value;
   }
  }

  private Player(char c){
    this.letter = c;
  }
 }

 class Game{
  static void Main(string[] args){
   Grid grid = new Grid(3);
   System.Console.WriteLine(grid[1,1]);

   Player p1 = Player.X;
   Player p2 = Player.O;

   System.Console.WriteLine(p1.letter);
   System.Console.WriteLine(p2.letter);

   grid.turn(p1.letter,2,1);
   System.Console.WriteLine(grid[2,1]);
  }
 }
}
