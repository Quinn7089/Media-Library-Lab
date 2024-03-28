using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);

MovieFile movieFile = new MovieFile(scrubbedFile);

string input;

AddMovie addMovie = new AddMovie();
movie movie = new movie();
DateTime today = DateTime.Now;
string moiveTxt = " ";
Console.WriteLine("1) Add Movie");
Console.WriteLine("2) Display All Movies");
Console.WriteLine("Enter to quit");
string resp = Console.ReadLine();

if(resp == "1"){



Console.WriteLine("{0:yyy}.{0:MM}.{0:dd} |INFO|MediaLibrary.Program|User choice: 1", today );

Console.WriteLine("Enter movie title");

addMovie.title = Console.ReadLine();

Console.WriteLine("Enter movie year");

addMovie.year = Console.ReadLine();


      do
      {
        // ask user to enter genre
        Console.WriteLine("Enter genre (or done to quit)");
        // input genre
        input = Console.ReadLine();
        // if user enters "done"
        // or does not enter a genre do not add it to list
        if (input != "done" && input.Length > 0)
        {
          movie.genres = input;
        }
      } while (input != "done");
      // specify if no genres are entered
     
Console.WriteLine("Enter movie director");

addMovie.director = Console.ReadLine();

Console.WriteLine("Enter running time (h:m:s)");

addMovie.time = Console.ReadLine();



string fullMovie =$"ID: Title:{addMovie.title} {addMovie.year}   Director:{addMovie.director} Run time:{addMovie.time} Genres:{addMovie.genre}";

Console.WriteLine(fullMovie);




}
if(resp == "2"){

    string FilePath = @"C:\Users\Quinn\Downloads\Media Libary Lab\movies.csv";
 
   
        using (StreamReader moives = new StreamReader(FilePath))
        {


           
            while ((moiveTxt = moives.ReadLine()) != null)
            {
                
               
                Console.WriteLine(moiveTxt);
                
                
             
            }
        }
       
          
 
}        

logger.Info("Program ended");


public class movie
{
 public string genres {get; set;}

}
  

 
public class AddMovie{
    public string title {get; set;}

    public string genre {get; set;}

    public string year {get; set;}

    public string director {get; set;}

    public string time {get; set;}

    public string fullMovie {get; set;}


}

