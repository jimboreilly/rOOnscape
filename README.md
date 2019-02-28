# rOOnscape
object oriented runescape api wrapper in C# .net core

## Project Structure

### rOOnscape

The primary API requests will be made here and return a rOOnscape.Structures object depending on the request made

### rOOnscape.Strucutres

Objects to hold data returned from RuneScape API and provide meaningful encapsulations of that data

### rOOnscape.Core

Core program code unrelated to the project directly but used to abstract functions in the other projects, such as C# extensions of existing types

