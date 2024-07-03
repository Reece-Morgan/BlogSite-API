## Running the Project

First, you need to download this project form the repo. 

Once downloaded, open the solution with Visual Studio.

Once in Visual Studio, click the ```Run``` button, or press ```Ctrl + F5```

The project will open a new browser window/tab to [http://localhost:5189](http://localhost:5189) where the Swagger UI will be displayed

This project has been built to support the frontend of a blogging site. To run the frontend, you can find the repo [here](https://github.com/Reece-Morgan/BlogSite-FrontEnd) to download the project. 

Follow the instructions in the README.md file to get the frontend up and running

## Using the Project

By using the Swagger UI, all endpoints within the project can be accessed and exceuted to ensure they all work as expected. The list of endpoints are as follows:
- Auth
  - [POST] /api/register
  - [POST] /api/login
  - [GET] /api/user
  - [POST] /api/logout

- BlogItems
  - [GET] /api/blog/get-all
  - [GET] /api/blog/get-by-id/{id}
  - [GET] /api/blog/get-by-user/{username}
  - [PUT] /api/blog/update/{id}
  - [POST] /api/blog/create
  - [DELETE] /api/blog/delete/{id}

The Auth endpoints are called from the frontend when a user logs in, logs out or registers. the ```/api/user``` endpoint is used to tell the frontend if a user is logged in.

The BlogItem endpoints are called on the frontend for the management of blog posts. the ```/api/blog/get-all``` endpoint is used to displal all blog items on the home page.
The remaining two GET requests get either a single item by id, or a list of items by matching the author of any items with the username of the logged in user.
The POST, PUT and DELETE endpoints are used to create a new item, edit an existing item or delete an item. Only authenticated users can create, edit or delete items. 
   
The blog items and user details are stored in an ```InMemoryDatabase```, meaning that when running this project locally, if it is stopped and started again, any data entered 
into the frontend and stored in the database will be lost. 
