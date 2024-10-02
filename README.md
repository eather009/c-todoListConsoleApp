# c# todoListConsoleApp
This console-based to-do list application is developed in C# with an object-oriented design. The app supports multiple storage options, including SQLite, or a file-based system, allowing users to choose their preferred method for saving tasks. Users can add more storage options by following the interface and using the strategy pattern. 

Key Features:
Add, View, and Remove Tasks: Users can manage their tasks using simple command-line commands.
Multiple Storage Options: Choose between SQLite, MySQL, or file-based storage to persist tasks.
Task Details: Each task includes a description and a creation date (CreatedAt) for better task management.
Error Handling: The app includes basic error handling, such as warnings for invalid task IDs.
OOP Design: Clean and modular object-oriented design ensures scalability and maintainability.
How to Use:
Add tasks with a description and creation date.
View the current list of tasks.
Remove tasks by ID with proper error handling if the ID doesn't exist.
