First Assigment for the DSP class

Original description : 
"In this assignment series you will build out a small forum app. For each assignment you will add something new to the project, and at the end of the semester you will have a fully working forum app. Hopefully. It is very much inspired by Reddit.

In the end it will consist of a simple CRUD focused Web API, with Entity Framework Core and a SQLite database to store data. For the front-end you will have a Blazor web app.

In this first assignment you will create the entities for your domain model, and you will define repository interfaces (repository is explained later).

Because your app will evolve over time - different parts will be added and swapped out - we need to design the system with modularity in mind. We do this by creating multiple projects, each responsible for something specific. It will be a simplified layered application.

The Web API (i.e. server) will contain two layers: a network and a persistence. Often you will have a business logic layer in between, but we are skipping that, and simplifying the server to focus on the .NET tools rather than good SOLID architecture design. You should probably have this extra layer in your semester project.

There is some initial setup, which is best done on one computer, then shared to others through GitHub. I recommend reading through the entire document before actually starting on anything."
