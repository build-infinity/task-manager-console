# Task Manager Console Application
This project is a C# Console Application that allows users to manage tasks efficiently. The application supports
creating,viewing, completing, and deleting tasks, with persistent storage using a JSON file.
Tasks are automatically saved and reloaded when the application restarts.

## Features 
Create new tasks with:
Title
Description
Deadline
Automatically store task creation date (CreatedAt)
Task status management:
UnCompleted
Completed
View tasks by status
Mark tasks as completed
Delete tasks with automatic ID reindexing
Persistent storage using JSON
Deadline input validation with a fixed date format.

## All tasks are stored automatically in the following location:
%AppData%\TaskManager\tasks.json
This path is resolved using Environment.SpecialFolder.ApplicationData, ensuring:
User-specific storage
Automatic folder creation
No manual configuration required

The deadline must be entered in the following format : dd.MM.yyyy

## Technologies Used:
- C#
- .NET Console Application
- System.Text.Json
- File I/O

## Possible Improvements:
- Edit existing tasks
- Highlight overdue tasks
- Task search functionality
- Task priority levels
- Improved console UI

## Author
**Developed by a student as a learning and practice project using C# and .NET**