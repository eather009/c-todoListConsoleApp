# To-Do List Console Application

A simple, object-oriented to-do list application built in C# that supports multiple storage options (SQLite, or file-based) for saving tasks. This console app allows users to add, view, and remove tasks, with basic error handling for invalid inputs. But the User can add another database like MySQL using the interface following the strategy pattern.

# Features
<b>Task Management</b>: Add, view, and remove tasks from the list.

<b>Storage Options</b>: Store tasks using SQLite, or a file-based system.

<b>Task Details</b>: Each task includes a description and a creation date (CreatedAt).

<b>OOP Design</b>: Clean, modular object-oriented design that supports scalability and maintainability.

<b>Error Handling</b>: Includes error handling for invalid IDs when removing tasks.

# How It Works

<b>Add Tasks</b>: Add a task with a description and creation date. Tasks are stored in the chosen storage system (SQLite, or file-based).

<b>View Tasks</b>: View all tasks currently stored in the system.

<b>Remove Tasks</b>: Remove a task by specifying its ID. Error handling is in place if the task ID is invalid or not found.

<b>Multiple Storage Support</b>: The app is flexible in terms of storage. You can switch between SQLite, or file-based storage by modifying the connection options in the code.

# Setup

## Prerequisites
.NET SDK 8.0 (or higher)

SQLite database setup

Visual Studio Code, Visual Studio, or any C# compatible IDE

# Steps to Run
Clone the repository:

```
git clone https://github.com/your-username/todolist-app.git
```
Navigate to the project directory:

```bash
cd todolist-app
```
Install required dependencies:

```bash
dotnet restore
```
Build the application:

```bash
dotnet build
```
Run the application:

```bash
dotnet run
```
Use the available commands to add, view, or remove tasks.



# Database Configuration
By default, the application supports SQLite, but you can switch to file-based storage by updating the configuration section in the Program.cs file:

SQLite Configuration: Ensure the SQLite connection string is set in the Program.cs file:

```csharp
string connectionString = "Data Source=tasks.db";
```

File-based Storage: If you prefer to use file-based storage, tasks will be saved in a text file (tasks.txt). Update the code accordingly.

# Contributing
Feel free to fork this repository and submit pull requests for any improvements or bug fixes.

# License
This project is licensed under the MIT License - see the LICENSE file for details.

# Acknowledgements
.NET SDK 8.0

SQLite database management

Object-oriented design principles for modularity and scalability.