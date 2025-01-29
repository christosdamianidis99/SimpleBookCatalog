# **Book Catalog App**

**A simple book catalog application built using Blazor, Razor Components, and Entity Framework Core.**  
This app allows users to view, add, edit, and manage book entries. It demonstrates CRUD operations (Create, Read, Update, Delete) with a clean, modern UI.

## **Features**

- **Blazor and Razor Components**: Fast, responsive UI built using the Blazor framework.
- **Entity Framework Core**: Seamless integration with a relational database for managing book data.
- **CRUD Operations**: Users can create, update, and delete book records.
- **Search Functionality**: Allows users to search and filter through the book catalog.
- **Responsive Design**: Optimized for desktop and mobile devices.

## **Technologies Used**

- **Blazor**: .NET web framework for building interactive web UIs.
- **Razor Components**: For creating reusable components.
- **Entity Framework Core**: Object-relational mapper (ORM) for database access.
- **SQLite / SQL Server (or other DB)**: Database to store book information (you can specify which DB you're using).


## **Unique Features**

- **Custom Generic Sorting Object**: A flexible, reusable sorting mechanism for every entity-related form. This eliminates the need to manually write sorting logic for each form, reducing code duplication and simplifying maintenance.

- **Dynamic Form Generation**: A powerful custom generic object dynamically generates forms based on entity attributes. Instead of manually defining each form field, this object reads the entity's properties and creates the necessary form components. This approach significantly reduces the amount of code required to manage forms, making it easier to scale and maintain.

- **Register**: Register with username, email and password and login with either username or email. Always User role by registration.

- **Login Logout**: Login logout feature as Admin or as User using Identity. With Authorize view is determined the feed that will be provided to the visitor. For acces as admin or user login with the following credentials.
- Username: admin Pass: admin123.
- User Username: user Pass: user123.

- **Google Sign-In/Registration**: Users can now register or sign in using their Google account for seamless access to the application.

Setup Requirement:
To enable Google Sign-In functionality, you must generate a Client ID and Client Secret from the Google Cloud Console. Add these credentials to the **Program.cs** file for the feature to work. For security, ensure that these values are stored securely and not exposed in the source code.
