﻿using NLog;

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
Console.WriteLine("3) Find Movie");
Console.WriteLine("Enter to quit");
string resp = Console.ReadLine();

if(resp == "1"){
string File = @"C:\Users\Quinn\Downloads\Media Libary Lab\movies.csv";
using(StreamWriter movieLibary = new StreamWriter(@File, true)){

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



string fullMovie = string.Format($"ID: 164980\nTitle: {addMovie.title} ({addMovie.year})\nDirector: {addMovie.director}\nRun time: {addMovie.time}\nGenres: {movie.genres}");

Console.WriteLine(fullMovie);

 movieLibary.WriteLine(fullMovie);

}


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
if(resp == "3"){
 Console.ForegroundColor = ConsoleColor.White;
  MovieFile moviesFile = new MovieFile(scrubbedFile);
  var moiveSearch = "";
  Console.WriteLine("Enter title of movie");
  moiveSearch = Console.ReadLine();

var Moives = moviesFile.Movies.Where(m => m.title.Contains(moiveSearch));

  Console.WriteLine($"There are {Moives.Count()} movies With the title {moiveSearch}");

var titles = movieFile.Movies.Where(m => m.title.Contains(moiveSearch)).Select(m => m.title);
foreach(string t in titles)
{
    Console.WriteLine($"  {t}");
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

