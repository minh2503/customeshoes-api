# Introduction
This is a sample project using ASP.Net Core Web API

# Getting Started
Prerequisites
- Install .NET 6 SDK or higher.
- Use an IDE such as Visual Studio or VS Code.


# Project Structure

- `App.BLL`: This folder contains the classes and services responsible for handling the business logic of the application. It sits between the Data Access Layer (DAL) and Controllers, helping isolate the business logic from other components. .
- `App.DLL`: This folder contains components that interact with the database, such as repositories or SQL queries. It's responsible for all data-related operations like fetching, updating, and deleting records..
- `App.Entity`: This folder holds entity models which represent the structure of data objects that flow between different layers of the application. These models are mapped to the database tables and are often used in both BLL and DAL..
- `App.Utility`: This folder contains utility classes, helpers, or common functions that can be reused throughout the application to simplify repetitive tasks or provide shared functionality..
- `Controllers`: This folder contains controller classes responsible for handling HTTP requests and routing them to the appropriate business logic layer (BLL). It defines how the application responds to user actions.

# Clone and code 
1. Clone with custom name 

`git clone <URL_OF_REPOSITORY> <NAME_OF_PROJECT_YOU_WANT>`

2. Change remote url
   
`git remote set-url origin <URL_OF_NEW_REPOSITORY>`

"# base_aspnetcore" 

