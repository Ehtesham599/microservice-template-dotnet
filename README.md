# Microservice template  
> A template repository for a .NET microservice using the clean architecture pattern, MediatR for handling request/response messages, and a MySQL database.

## Template Structure
The template consists of five projects loaded into the microservice solution, namely `API`, `AppCore`, `Domain`, `External`, and `Infrastructure`.

```
.
|-- API
|   |-- Controllers
|-- AppCore
|   |-- Application
|-- Domain
|   |-- Entities
|-- External
|   |-- Protos
|   |-- Services
|-- Infrastructure
|   |-- Configuration
|   |-- EntityConfiguration
|   |-- Migrations
|-- MicroserviceTemplate.sln
```

### API
This is the primary startup project that launches the service. It includes the necessary launch configuration files and acts as a presentation layer in the service where the HTTP endpoints are exposed with the help of controllers inside the `/controllers` directory. All other projects are referenced inside this project and dependency injections are added inside the `Program.cs` file.

### AppCore
This project may include the implementation of the required business logic, acting as an application layer in the service. A directory can be created inside the `/Application` folder for each use case.

### Domain
This project acts as a domain layer consisting of enterprise logic, such as the definition of entities. Entities can be defined using model classes, essentially describing the schema for a table where each entity is a table. With the code-first approach, tables are created in the database upon running the project using these model classes.

### External
This project may include the implementation of modules requiring communication with external components outside the service. For example, a service may require communication with other components in the system via HTTP1.1/gRPC, message queues, etc. Modules to interact with external components can be included here.

### Infrastructure
This project acts as an infrastructure layer in the service. It consists of configuration for the entities, database context object, and database migrations and loads them into the database. The service can then use the context object to access entities created in the database across different modules in the service.

## Usage
To use the service, simply run the API project. The application will be launched with the configuration specified in `/properties/launchSettings.json` file. The application has a swagger configuration loaded in the `Program.cs` file. Running the project should direct you to a SwaggerUI web view where you can view and consume your endpoints exposed for the service.

Note: Since this repository is just a template, make sure to rename the solution file to your desired microservice name.
