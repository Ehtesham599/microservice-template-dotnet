# Microservice template  
> A template repository for a .NET microservice using the clean architecture pattern, MediatR for handling request/response messages and a MySQL database.

## Template Structure
The template consists of five projects loaded into the microservice solution, namely `API`, `AppCore`, `Domain`, `External` and `Infrastructure`.\

### API
This project is the primary startup project that launches the service. It includes the necessary launch configuration files and acts as a presentation layer in the service where the HTTP endpoints are exposed with the help of controllers inside the `/controllers` directory.

### AppCore
This project includes the implementation of business logic, acting as an application layer in the service. A directory can be created inside the `/Application` folder for every controller related handlers.

### Domain
This project acts as a domain layer consiting of enterprise logic, such as definition of entities and there specifications. Entities can be defined using model classes, essentially describing the schema for a table where each entity is a table. With the code first approach, tables are created in the database using these model classes.

### External
This project includes implementation of any logic requiring external resources outside the service. For example, the service may require communication with another service via HTTP/gRPC, or it may act as a cosumer to a message broker. Such kind of logic can be handled in this project.

### Infrastructure
This project acts as an infrastructure layer in the service. It consists of configuration for the entities, database context object, database migrations and loads them into the database. The service can then use the context object to access entities created in the database.

## Usage
To use the service, simply run the API project. The application will be launched with configuration specified in `/properties/launchSettings.json` file. The application has swagger configuration loaded in the `Program.cs` file. Running the project should direct you to a SwaggerUI web view where you can view and consume your endpoints exposed in the service.

Since this repository is just a template, make sure to rename the solution file to your desired microservice name.
