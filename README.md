# CourseManagementAPI-ASP.NET-8
The Course Management API is a backend service built with .NET 8 for managing course catalogs in an educational institute. It provides endpoints for creating, reading, updating, and deleting course information, with robust validation and error handling.

Features:
  1. CRUD Operations:
      Add new courses with validations for mandatory fields such as Course Name, Duration, and Fee.
      View details of specific courses or a list of all available courses.
      Update course information including Name, Description, Duration, and Fee.
      Delete courses safely using their unique Course ID.
  
  2. Validation and Error Handling
      Ensures valid inputs (e.g., positive Course Fee, valid Course Duration).
      Returns appropriate HTTP status codes for errors such as 400 Bad Request or 404 Not Found.
  
  3. CORS Support
      Configured to allow secure API access from authorized domains, such as the institute's admin dashboard or third-party analytics systems.
 
  4. Scalability and Flexibility
      API design allows integration with multiple applications (web and mobile).
      Supports future extensions for advanced features or new clients.
   
  5. API Documentation
      Fully documented endpoints using Swagger for developer onboarding and collaboration.

Data Model:
      The API manages the following course-related details:
          Course ID: Unique identifier for each course.
          Course Name: Name of the course.
          Course Description: Brief summary of the course content.
          Course Duration: Length of the course in weeks.
          Course Fee: Fee associated with the course.

Prerequisites:
    .NET 8 SDK
    SQL Server (SSMS for database setup)
    
Setup Instructions:
    Clone the repository:
        git clone https://github.com/mitesh002/CourseManagementAPI-ASP.NET-8.git
      
    Build the solution:
        dotnet build
        
    Update the connection string in appsettings.json to point to your SQL Server instance.

    Run database migrations:
        dotnet ef migrations add InitialCreate  
        dotnet ef database update
      
    Start the API:
        dotnet run
      
    Access the API via Swagger UI.

Technologies Used:
    .NET 8
    Entity Framework Core
    SQL Server
    Swagger
    CORS Middleware

Future Enhancements:
    -> Implement user authentication and role-based access.
    -> Add support for advanced filtering and sorting for courses.
    -> Integrate with external analytics platforms for performance monitoring.
