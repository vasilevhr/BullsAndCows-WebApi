# BullsAndCows-WebApi
Implementation the server logic of popular game Bulls and Cows. The game logic is performed as follows:
A user registers an account providing credentials(username and password).
An authenticated user could create a game. Another user can join when the game is marked as available for joining.
The player in turn can make a guess against the number of their opponent. When the player guess the opponent's number, he win.

Use MSSQL Server and Entity Framework with their code-first approach to create a simple database. The data layer is used abstract with creation of Repository pattern. Game services are implemented with full functionality for listing, creating, joining games. Only authenticated users can see all games, creats a new game, join a created game, view details for game. 
A game has notification services which implement functionality for notifications - a player recieve notification when another is joined;
a player plays their turn, the other recieves a notification etc.
System implements web services for the high score board of application. All of this functionalities are implemented with ASP.NET Web API.
Application have some user info services realized using WCF.

(WebApi exam preparation 2015.)
