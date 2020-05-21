
# Context 
HRpest is a project that I wrote from start to finish as an assignment for my .NET Programming course. The assignment's aim was to simulate the real work environment as closely as possible, while also letting us get to know every step on the way to developing a successful application. That's why for this assignment we were working alone, without a team. 

# Tech stack
During the development of this project, I had an opportunity to learn and use the following technologies:

 - .NET CORE
 - ASP.NET MVC
 - AJAX & REST API
 - CI/CD using Azure Pipelines
 - Authentication using Azure Active Directory B2C
 - Azure Blob Storage
 - Azure SendGrid
 - Azure SQL Server
 - Entity Framework
 - Azure Web Application
 - bootstrap
 - jQuery
 - Razor
 - Knockout.js
 - swagger
 - xUnit
 - Selenium

# Goal
As mentioned before, the goal of the project was to give us a taste of the professional programmer's life. That's why we had to develop the project in SCRUM which meant I had to:

1. **Plan** - write out features, user stories and epics, assign story points to each of them, link commits to backlog items, distribute the features into 8 1-week intervals that I was given to finish the app. The full breakdown of the work and burn down rate can be found [here](https://dev.azure.com/barankiewicz/HRpest), on the project's home site.
2. **Develop** - Code the app using a proper DoD branching system, linking each commit to a feature in the backlog, using pull requests to merge into the dev branch
3. **Test** - Test the new features. The project had to have at least 6 unit tests, and at least 3 integration tests and UI tests each.
4. **Deploy** - Set up a database in Azure SQL Server, a web app in Azure Web Apps, set up CI and CD using Azure Pipelines, use Azure Shell to access the resources, Azure Blob to store the CV files, SendGrid for sending confirmation e-mails and updates

# Business requirements

## Requirements
- HTML Interface generated using Razor
- Ability to submit CV file with a data form for user
- Ability to manage all data for administrator
- Ability to attach file (stored in Azure Blob)
- Candidate data needs to be stored in database (using Azure SQL Server)
- Candidates data need to be presented for HR team
- HR team need to receive email notification about new candidate (using Azure SendGrid)

## Architecture:
- User opens a website which is stored on Azure Web App
- List of the job offers is loaded asynchronously via API using AJAX
- Data isstored in Azure SQL Server database
- Communication between Web App and SQL done using Entity Framework
- Files are stored in Azure Blob storage
- User Authentication is done with Azure AD B2C
- HR email notification is done via Azure SendGrid
![](https://i.imgur.com/2pyqnAM.png)

## Roles:

1. User role
 - Can apply to job offer and see to which job offer already applied
 - Can edit already submitted application
 - Can delete application

2.  Admin role
- Can see list of all applications
- Can search application
- Can add or remove someone to HR role
- Cannot see application details or download file

3. HR role
- Receive notification when someone applied on his or her job position
- See all applications for his or her job position
- Can open particular application to see details
- Can approve or reject application
- Can search applications

# Conclusion
Thank you for reading! Unfortunately, the app is now offline due to our student Azure accounts being turned off. All the Azure services used in this project added up to quite a sum monthly just to keep this assignment online. Sorry!


