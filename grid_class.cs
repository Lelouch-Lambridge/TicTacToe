using System;
  
namespace TicTacToe {
 public class Grid {
  /*---*/
  private static readonly Lazy<Grid> grid_inst = new Lazy<Grid>(() => new Grid(3));

  private Grid(int size){
   this.size = size;
   this.grid = new char[size,size];
   this.clear();
   this.print();
  }


  public static Grid make{
   get{
    return grid_inst.Value;
   }
  }
  /*---*/
  private char[,] grid;
  private int size;
  private bool move = false;
  public bool over = false;
  private Dictionary<bool,char> tu = new Dictionary<bool,char>
  (){{false,Player.X.letter},{true,Player.O.letter}};

  public char this[int index1,int index2]{
   get{
    return grid[index1,index2];
   }
   set{
    grid[index1,index2] = value;
   }
  }

  public void resize(int size){
   this.size = size;
   this.grid = new char[size,size];
   this.clear();
   this.print();
  }

  public void turn(int r, int c){
   if (this.grid[r,c] != ' ') return;
   this.grid[r,c] = tu[move];
   move = !move;
   this.update();
  }

  private void print(){
   string row_out = " ";
   for (int r = 0; r < size; r++){
    for (int c = 0; c < size; c++){
     row_out += grid[r,c];
     if (c == size-1) continue;
     row_out += " | ";
    }
    if (r == size-1){
     System.Console.WriteLine(row_out + "\n");
     return;
    }
    row_out += "\n";
    for (int i = 0; i++ < size; row_out += "----");
    row_out += "\n ";
   }
  }

  private void update(){
   this.print();
   for (int r = 0; r < size; r++){
    for (int c = 0; c < size; c++){
     if (grid[r,c] == ' ') return;
    }
   }
   this.over = true;
  }

  private void clear(){
   for (int r = 0; r < size; r++){
    for (int c = 0; c < size; c++){
     grid[r,c] = ' ';
    }
   }
  }
 }

 public class Player{
  /*---*/
  private static readonly Lazy<Player> x = new Lazy<Player>(() => new Player('x'));

  private Player(char c){
   this.letter = c;
  }

  public static Player X{
   get{
    return x.Value;
   }
  }
  /*---*/

  private static readonly Lazy<Player> o = new Lazy<Player>(() => new Player('o'));
  public static Player O{
   get{
    return o.Value;
   }
  }

  public char letter{get;}
 }

 class Game{
  static void Main(string[] args){
   Grid grid = Grid.make;
   while (!grid.over){
    grid.turn(0,0);
    grid.turn(2,2);
    grid.turn(0,2);
    grid.turn(2,0);
    grid.turn(1,1);
    grid.turn(1,2);
    grid.turn(2,0);
    grid.turn(2,1);
    grid.turn(0,1);
    grid.turn(2,1);
    grid.turn(1,0);
   }
  }
 }
}
