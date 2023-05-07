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

  // overload [] operater of Grid objects
  public char this[int index1,int index2]{
   get{
    return grid[index1,index2];
   }
   set{
    grid[index1,index2] = value;
   }
  }
  
  // incase a larger grid is desired to play on
  public void resize(int size){
   this.size = size;
   this.grid = new char[size,size];
   this.clear();
   this.print();
  }

  public void turn((int,int) x){
   if (this.grid[x.Item1,x.Item2] != ' ') return;
   this.grid[x.Item1,x.Item2] = tu[move];
   // swap who gets to place
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
   // only check diagonals once
   if (this.over = (this.check(this.diagonal()) || this.check(this.antidiagonal()))) return;

   for (int r = 0; r < size; r++){
    // check each of the rows and columns
    if (this.over = (this.check(this.row(r)) || this.check(this.column(r)))) return;
    for (int c = 0; c < size; c++) if (grid[r,c] == ' ') return;
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
   
  // used to check if there is a winner
  private bool check(char[] arr){
   return arr.Distinct().Count() == 1 && arr[0] != ' ';
  }
  private char[] column(int columnNumber){
   return Enumerable.Range(0, size).Select(x => grid[x, columnNumber]).ToArray();
  }
  private char[] row(int rowNumber){
   return Enumerable.Range(0, size).Select(x => grid[rowNumber, x]).ToArray();
  }
  private char[] diagonal(){
   return Enumerable.Range(0,size).Select(x => grid[x,x]).ToArray();
  }
  private char[] antidiagonal(){
   return Enumerable.Range(0,size).Select(x => grid[x,size-1-x]).ToArray();
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
  // second instance of player class for player 2
  private static readonly Lazy<Player> o = new Lazy<Player>(() => new Player('o'));
  public static Player O{
   get{
    return o.Value;
   }
  }
  // letter only has get method so no way to change it
  public char letter{get;}
 }

 class Game{
  static void Main(string[] args){
   Grid grid = Grid.make;
   Dictionary<int,(int,int)> test = new Dictionary<int,(int,int)>()
   {{1,(0,0)},{2,(0,1)},{3,(0,2)},{4,(1,0)},{5,(1,1)},{6,(1,2)},{7,(2,0)},{8,(2,1)},{9,(2,2)}};

   while (!grid.over) grid.turn(test[Convert.ToInt32(System.Console.ReadLine())]);
  }
 }
}
