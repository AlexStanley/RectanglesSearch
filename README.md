# RectanglesSearch

How to raize the project:

1. Change Server name into appsettings.json on your Server name.

2. Apply mirations to MS QSL database (projects)
{
	RectanglesSearch.Api
	RectanglesSearch.Api.Identity
} for these projects.

Apply RectanglesSearchIndex from INDEX.sql for Rectangles table (RectangleDatabase)

3. Start three projects simultaniously 
(
	RectanglesSearch.Web
	RectanglesSearch.Api
	RectanglesSearch.Api.Identity
)

4. Go to https://localhost:7104/

5. Login to the application.

6. Credentials:
	UserName: admin@gmail.com
	Password: Admin123*
	
7. Take the token.

8. Go to https://localhost:7184/swagger/index.html

9. Make authorization: Bearer + token

10. RectanglesSearch.Service.API is ready for testing on Swagger.

# Any further design considerations assuming scaling this system and integrations with external consumers.

Scalability: Planning for scalability by designing a system that can handle a growing number of rectangles and increasing search/match requests. 
We can use horizontal scaling techniques like load balancing and partitioning data across multiple servers to distribute the workload effectively.

Caching: Implementing caching mechanisms, such as in-memory caches or distributed caching systems, to store frequently accessed rectangles or search results. 
Caching can significantly improve the performance of the API, especially if certain rectangles or searches are repeated frequently.

Rate Limiting and Throttling: Protecting the API from abuse and ensure fair resource allocation by implementing rate limiting and throttling mechanisms. 
These mechanisms can restrict the number of requests a consumer can make within a certain time period, preventing overload and maintaining system stability.

Documentation: It can be provided comprehensive and up-to-date documentation for the API, including clear examples and usage guidelines. 
This will help external consumers integrate with the API more easily and reduce the support burden.

Monitoring and Logging: Setting up monitoring and logging systems to track the API's performance, identify potential bottlenecks, and troubleshoot issues. 
Collecting metrics and logs will help to understand system behavior, optimize performance, and ensure the API meets the expected service level agreements.

Error Handling: Implementing proper error handling and provide meaningful error messages in the API responses. 
This will help consumers understand and troubleshoot any issues that may occur during the search/match process.

Pagination: If the number of rectangles or search results can be large, consider implementing pagination in the API responses. 
This allows consumers to retrieve results in smaller, manageable chunks, reducing the response size and improving performance.

Versioning: Planning for future changes and updates to the API by incorporating versioning from the beginning. 
This ensures that it can introduce new features or modify existing functionality without breaking compatibility for existing consumers. 
Versioning can be achieved through URL versioning or using request headers.