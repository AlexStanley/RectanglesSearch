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

