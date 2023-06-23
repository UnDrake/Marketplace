This project is a marketplace database and REST API built using the Code-First approach. It allows you to query marketplace items without the need for a user interface. The API provides various features such as pagination, filtering, sorting, and optimized searching by name. It is developed using the following technologies: .NET 5-7, EF Core, Asp.Net Core, MS-SQL

Features:
Pagination. The API supports pagination to retrieve a specific subset of items at a time. You can specify the page number and the page limit to control the number of items returned in each request.
Filtering. The API provides optional filtering options to narrow down the results based on different criteria. You can filter items by their status, seller, or name. The name filtering is case-insensitive and matches any position in the name.
Sorting. Items can be sorted based on specific keys such as CreatedDt (creation date) and Price. You can specify the sort order as ascending (ASC) or descending (DESC) to arrange the items accordingly.
Optimized Searching. The API is optimized for searching items by name. This allows for efficient retrieval of items based on partial or complete name matches.
API Versioning. The API supports versioning to ensure backward compatibility and smooth evolution. Different versions of the API can be maintained concurrently to support clients using different API versions.

Getting Started:
Install .NET 5-7 and MS-SQL if you haven't already.
Clone the project repository to your local machine.
Configure the MS-SQL connection string in the project's configuration file.
Run the database migrations to create the necessary tables.
Build and run the API project.

Conclusion
The Item Marketplace project provides a robust and efficient way to manage a marketplace database through a RESTful API. It leverages the power of .NET 5-7, EF Core, Asp.Net Core, and MS-SQL to deliver a reliable solution for marketplace item management.
