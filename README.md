# GameLand - Enterprise Application Integration

## Overview
This solution demonstrates Enterprise Application Integration (EAI) between a Windows Forms client and ASP.NET web service using C# and SQL Server.

## Prerequisites
- Visual Studio 2022
- .NET 6.0 or later
- SQL Server 2019+

Make sure the following workloads are selected when installing Visual Studio:
- ASP.NET and web development
- Azure development
- Desktop & Mobile
- .NET desktop development
## Solution Components

### 1. GameLandWebService (Backend)
- ASP.NET Web API
- Handles business logic and data access
- Provides RESTful endpoints

### 2. GameLand (Frontend)
- Windows Forms application
- Consumes web service APIs
- Provides user interface

## Setup Instructions
### 1. Clone the Repository

```bash
git clone https://github.com/aiyayayah/GameLand.git
```

### 2. Run the Web Service First
1. Open the folder GameLandWebService.

2. Open the solution file GameLandWebService.sln using Visual Studio 2022.

3. Click Start or press F5 to run the web service.

4. Ensure the service is running at a local URL, such as:
```bash
http://localhost:[port]/GameLandWebService.asmx
```
⚠️ Keep this running while using the client.

### 3. Run the GameLand Windows Forms Application
1. Open the folder GameLand.

2. Open GameLand.sln with Visual Studio 2022.

3. Click Start or press F5 to run the application.

4. The app will connect to the running Web Service to interact with the backend.
