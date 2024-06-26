# Authentication-API
Task : You are working with an amazing team that develops a super popular mobile game, the team decided to  make the game only available to logged in users. Task: - Design an oAuth login API, the API shall tell the user his/her roles and what systems regions  he/she can access.

#Authentication API Assignment: Design Document
=================================================
Overview:
In this assignment, I have developed an authentication API using ASP.Net Core MVC. The API is designed in way to handle user authentication via OAuth, issue JWT tokens containing user roles and system regions, and return the appropriate access information. The implementation is using static data for user information and structured to demonstrate best practices in terms of security, scalability, and maintainability. 

Structure of the Authentication API:
I have used the following structure (MVC) to create the API for the Authentication of users: 
•	Controllers: Controllers are used to contains the API controllers.
•	Models: Models are used to contains the data models.
•	Services: Services are used to contains the logic and services.
•	Helpers: Helpers are used to contains helper classes for tasks. In this project I have used for generating JWT tokens.
•	Program.cs:  This is the source code file which is executing for entry point of the application.
•	Startup.cs: This source code file has been created to configure the application services and middleware.

Implementation Details:
1.	First of all we need to setup the ASP.Net Core MVC Project for Authentication API creation.
•	Create a new ASP.Net Core Web API project by using any tool like VS Code or you may use command prompt as well.
Commands:
c/abc/xxx: dotnet new webapi -n AuthenticationAPI 
c/abc/xxx: cd AuthenticationAPI
Add necessary NuGet packages:
c/abc/xxx: dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer c/abc/xxx: dotnet add package System.IdentityModel.Tokens.Jwt
2.	Now we need to configuring JWT Authentication by startup.cs  for services and middleware.
3.	After successful configuration we need create Model to Define user roles, regions, and user models.
4.	After the 4th step I have to move for implementation of Authentication service to handle user validation and JWT generation named ‘AuthService.cs’.
5.	After user validation we need to handle the login  request so I have created the controller named ‘AuthController.cs’.


