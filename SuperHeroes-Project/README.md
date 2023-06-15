CRUD - Repository pattern - Dependency Injection - SQL Server

Nuget packages
---------
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore

Required Command Line Tool
-------------
dotnet ef

Commands
----------
1. dotnet ef migrations add [...filename]
2. dotnet ef database update


Initial setup
---------------------
1. Create the DataContext file in Data\DataContext
2. Follow the example in this project and define the connection string
3. Double check to make sure the database you're going to create doesn't exist
4. Run -> [dotnet ef migrations add (fileName...[usually for the first migration, name it InitialCreate ])]
5. You'll notice a new folder called migration being created
6. Local DB connection string: "Server=(localdb)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;"
7. Run -> [dotnet ef database update] to trigger a migration process. This will update the database based on your sql scripts

New migrations
------------------
To create a new table
	1. Create a new model
	2. Create a new DbSet<newModel> in the DbContext file
	3. Run -> dotnet ef migrations add [...filename]
	4. Run -> dotnet ef database update