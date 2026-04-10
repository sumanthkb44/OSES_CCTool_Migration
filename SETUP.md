# Quick Start Guide

This guide will help you set up and run the OSES Migration Demo application.

## Prerequisites

Before you begin, ensure you have the following installed:

1. **Node.js 18+** and npm
   - Download from: https://nodejs.org/
   - Verify: `node --version` and `npm --version`

2. **.NET 8 SDK** (latest LTS)
   - Download from: https://dotnet.microsoft.com/download
   - Verify: `dotnet --version`

3. **Angular CLI** (optional, for development)
   - Install: `npm install -g @angular/cli`
   - Verify: `ng version`

## Setup Instructions

### 1. Backend Setup (ASP.NET Core)

Open a terminal and navigate to the backend directory:

```bash
cd backend
```

Restore dependencies:

```bash
dotnet restore
```

Run the backend API:

```bash
dotnet run
```

The API will start on **http://localhost:5000** (or check console output for the actual port).

Keep this terminal open and running.

### 2. Frontend Setup (Angular)

Open a **new terminal** and navigate to the frontend directory:

```bash
cd frontend
```

Install dependencies:

```bash
npm install
```

Start the Angular development server:

```bash
npm start
# Or: ng serve
```

The frontend will start on **http://localhost:4200**.

Keep this terminal open and running.

### 3. Access the Application

Open your browser and navigate to:

```
http://localhost:4200
```

You should see the OSES Migration Demo application with three pages:
- **Home**: OSES migration overview
- **Continuous Clearing**: Explains the CC Tool workflow
- **CI/CD Demo**: Shows GitHub Actions integration

## Troubleshooting

### Backend Issues

**Problem**: Port 5000 already in use

**Solution**: Modify `backend/appsettings.json` to use a different port:

```json
{
  "Urls": "http://localhost:5001"
}
```

Then update the frontend API URL in `frontend/src/app/services/oses-api.service.ts`:

```typescript
private apiUrl = 'http://localhost:5001/api';
```

### Frontend Issues

**Problem**: CORS errors in browser console

**Solution**: Ensure the backend CORS policy matches your frontend URL in `backend/Program.cs`:

```csharp
policy.WithOrigins("http://localhost:4200")
```

**Problem**: Module not found errors

**Solution**: Delete `node_modules` and reinstall:

```bash
cd frontend
rm -rf node_modules
npm install
```

### GitHub Actions

To test the GitHub Actions workflows:

1. Push this repository to GitHub
2. The workflows are located in `.github/workflows/`
3. They will run automatically on push to main or pull requests
4. View workflow runs in the "Actions" tab on GitHub

## Development Tips

### Backend Development

- API endpoints are in `backend/Controllers/OsesController.cs`
- Swagger UI available at: http://localhost:5000/swagger
- Modify `backend/Program.cs` to add new services or middleware

### Frontend Development

- Components are in `frontend/src/app/components/`
- API service is in `frontend/src/app/services/oses-api.service.ts`
- Update routes in `frontend/src/app/app.routes.ts`
- Angular Material components: https://material.angular.io/

### Building for Production

#### Backend
```bash
cd backend
dotnet publish -c Release -o ./publish
```

#### Frontend
```bash
cd frontend
npm run build
# Output will be in frontend/dist/
```

## Next Steps

1. Explore the codebase to understand the architecture
2. Read the inline comments explaining OSES concepts
3. Review the GitHub Actions workflows in `.github/workflows/`
4. Customize the content to match your organization's needs
5. Add authentication if deploying to production
6. Configure real license scanning tools based on your stack

## Support

This is an educational demo application. For questions about:
- **OSES migration**: See the README.md and Home page
- **Continuous Clearing**: See the Continuous Clearing page
- **GitHub Actions**: See the CI/CD Demo page

Happy learning! 🚀
