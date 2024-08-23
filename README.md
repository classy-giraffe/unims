// explain structure

## Structure
The application is structured as follows:
1. AttendanceMS: Microservice for managing attendances
2. EmployeeMS: Microservice for managing employees
3. PayrollMS: Microservice for managing payrolls

## Architecture

It is not meant to be a standalone application, but rather a collection of microservices that can be used together to manage a company's HR operations.

The microservices architecture is designed to ensure modularity and scalability.

Each microservice is a separate module that can be run independently. They communicate with each other using REST APIs and Kafka messaging.

EmployeeMS is the central microservice that manages employees. It is responsible for creating, updating, and deleting employee records. Each time an employee record is created or updated, it publishes a message to the Kafka topic "employee-events".

PayrollMS listens to the "employee-events" topic and calculates the payroll for each employee. If an employee record is deleted, this microservice will remove the corresponding Employee entry (as it stores the employee data in its own database, for redundancy and performance reasons). It can fallback to regular HTTP calls to EmployeeMS to retrieve the employee data in case of a cache miss or Kafka is down.

AttendanceMS communicates with EmployeeMS using standard REST APIs. It is responsible for managing attendance records for each employee. It can create, update, and delete attendance records. Each time an attendance record is created, updated or deleted, a call to the EmployeeMS is made to ensure the employee exists.

The application is partly fault-tolerant. If the Kafka messaging system is down, the PayrollMS will fallback to regular HTTP calls to EmployeeMS to retrieve the employee data.

## Technologies

The application is built using the following technologies:
- PostgreSQL: Database for storing employee and attendance records (one database per microservice)
- Kafka: Messaging system for communication between microservices (between EmployeeMS and PayrollMS)
- ASP.NET Core: Web framework for building REST APIs
- Entity Framework Core: ORM for database access
- Docker: Containerization for easy deployment
- Github Actions: CI/CD pipeline for automating image builds and deployments

## Development

Simply download the code, run the composer.dev.yml (it will pull the Kafka and 3 instances of postgres) and open in Visual Studio/Rider and run each .API project.

## Deployment

Create a folder called microservice and a file called .env with the following content:
```
POSTGRES_USER=<user>
POSTGRES_PASSWORD=<password>
```
Copy the docker-compose.yml file to the microservice folder and run `docker-compose up -d` to start the services.