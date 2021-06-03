using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using d02_ex00.Model;

var books = (List<Book>)null;
var movies = (List<Movie>)null;
if (System.IO.File.Exists("book_reviews.json"))
{
	var booksStr = System.IO.File.ReadAllText("book_reviews.json");
	books = JsonSerializer.Deserialize(booksStr, typeof(List<Book>)) as List<Book>;
}
if (System.IO.File.Exists("movies.json"))
{
	var movieStr = System.IO.File.ReadAllText("movies.json");
	movies = JsonSerializer.Deserialize(movieStr, typeof(List<Movie>)) as List<Movie>;
}
books ??= new List<Book>();
movies ??= new List<Movie>();
var compilation = (books as IEnumerable<ISearchable>).Concat(movies);

Console.WriteLine("Input search text");
var answer = Console.ReadLine();

var result = compilation.Where(x => x.Title.ToLower().Contains(answer.ToLower())).ToArray();

if (result.Count() == 0)
{
	Console.WriteLine($"There are no \"{answer}\" in media today.");
	return;
}
Console.WriteLine();
Console.WriteLine($"Items found: {result.Length}");
Console.WriteLine($"Book search result [{result.Where(x => x.GetType() == typeof(Book)).Count()}]:");
result.Where(x => x.GetType() == typeof(Book)).ToList().ForEach(b => Console.WriteLine(b.ToString()));
Console.WriteLine();
Console.WriteLine($"Movie search result [{result.Where(x => x.GetType() == typeof(Movie)).Count()}]:");
result.Where(x => x.GetType() == typeof(Movie)).ToList().ForEach(b => Console.WriteLine(b.ToString()));
