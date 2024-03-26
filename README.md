### MANGA DICTION BACKEND

Requirements/ Pages:
- Login and Sign Up Page
- Home Page
- Browse Clubs Page
- Specified Club Page
    - Post/ Comments Page
- Search Page/Modal 
- Profile Page


Controllers Folder: 
- User Controller
- Club Controller
- Posts Controller
- Favorites Controller


Services Folder:
- Context Folder
    - DataContext file (???)
- User Service
- Password Service
    -Hash and Salt
- Club Service
- Posts Service
- Favorites Service


Models: 
- User Model
- Club Model
- Posts Model
- Favorites Model
- DTOs
    - Login DTO
    - CreateAccount DTO
    - Password DTO


What are DTOs?
    Data Transfer Objects(DTOs) are tools for managing and transferring data between different parts of an application.
    They help in reducing the amount of data transferred and provide a clear contract between different layers.
    Allows you to grab/ aggregate specific properties of an entity or data from multiple sources into one single object.

Models:
    Refers to the representation of data that is used within the application. 


Azure:
- Database name: MangaDictionDb
- Server name: mangadiction
- Server Admin Login: MangaLogin
- Password: Diction123!

