### MANGA DICTION BACKEND

https://mangadictionapi.azurewebsites.net/ 


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
    - LOGIN (POST), GET USER, CREATE USER, UPDATE USER,
- Club Controller
    - GET ALL, GET ALL PUBLIC CLUBS, GET CLUB BY ID, GET CLUB BY NAME, GET CLUB BY DATES, CREATE CLUB, UPDATE CLUB, DELETE CLUB
- Posts Controller
    - GET POSTS BY CLUBS, GET POSTS BY CATEGORY, GET POSTS BY TAGS, GET POSTS BY DATES, GET POSTS BY UPDATES, CREATE POST, UPDATE POST, DELETE POST
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
- Member Model
- Favorites Model
- Comment Model
- Friend Model
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

