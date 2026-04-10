# OSES Migration Demo with Continuous Clearing

This is an educational demo application that explains **OSES (Open Source Engineering Stack) migration** and demonstrates how to use a **reusable GitHub Action for Continuous Clearing** in your CI/CD pipeline.

## 📚 What is OSES Migration?

**OSES (Open Source Engineering Stack)** migration refers to the process of transitioning software development workflows to leverage open-source tools, frameworks, and best practices. Key aspects include:

- **Standardization**: Adopting industry-standard open-source tools
- **Transparency**: Open-source licensing and vulnerability management
- **Automation**: CI/CD pipelines for quality and security checks
- **Compliance**: Automated license scanning and SBOM generation

### Migration Benefits

```
┌─────────────────┐       ┌──────────────────┐       ┌─────────────────┐
│  Legacy Stack   │  -->  │  OSES Migration  │  -->  │  Modern Stack   │
│                 │       │                  │       │                 │
│ - Manual checks │       │ - Automate steps │       │ - CI/CD Native  │
│ - Local tools   │       │ - Standardize    │       │ - Cloud-ready   │
│ - Ad-hoc process│       │ - Document       │       │ - Compliant     │
└─────────────────┘       └──────────────────┘       └─────────────────┘
```

## 🔄 What is Continuous Clearing?

**Continuous Clearing** is Siemens' approach to automating **open-source license compliance** and **vulnerability scanning** as part of the CI/CD pipeline.

### Continuous Clearing Workflow

```
┌──────────────┐
│  Code Commit │
└──────┬───────┘
       │
       v
┌──────────────────────────┐
│  CI/CD Pipeline Trigger  │
└──────┬───────────────────┘
       │
       v
┌──────────────────────────────────┐
│  Continuous Clearing Action      │
│  ┌────────────────────────────┐  │
│  │ 1. Scan dependencies       │  │
│  │ 2. Check licenses          │  │
│  │ 3. Identify vulnerabilities│  │
│  │ 4. Generate SBOM           │  │
│  │ 5. Create compliance report│  │
│  └────────────────────────────┘  │
└──────┬───────────────────────────┘
       │
       v
┌──────────────────┐
│  Pass/Fail Gate  │
└──────┬───────────┘
       │
       v
┌──────────────────┐
│  Deploy to Prod  │
└──────────────────┘
```

### Key Features

- **Automated License Scanning**: Detect all open-source licenses in dependencies
- **Vulnerability Detection**: Identify known CVEs and security issues
- **SBOM Generation**: Create Software Bill of Materials (SBOM) in SPDX/CycloneDX format
- **Policy Enforcement**: Block builds that violate license or security policies

## 🔧 Why Reusable GitHub Actions?

This demo uses **reusable workflows** to demonstrate best practices:

### Benefits of Reusable Workflows

1. **DRY Principle**: Define once, use everywhere
2. **Centralized Updates**: Fix bugs in one place
3. **Consistency**: Same process across all repos
4. **Simplified Maintenance**: Update workflow logic centrally

### How It Works

```yaml
# Caller workflow (cc.yml)
jobs:
  run-clearing:
    uses: ./.github/workflows/continuous-clearing.yml
    with:
      sbom-format: spdx
      fail-on-critical: true
```

The **caller workflow** invokes the **reusable workflow** with specific inputs.

### Artifact-Based Input Passing

```
┌────────────────┐       ┌─────────────────────┐
│  Build Job     │       │  Clearing Job       │
│                │       │                     │
│ - Compile code │ ----> │ - Receives artifact │
│ - Upload deps  │       │ - Scans for issues  │
│                │       │ - Generates SBOM    │
└────────────────┘       └─────────────────────┘
        |                         |
        v                         v
   [Artifact]               [SBOM Report]
```

## 🏗️ Project Structure

```
UsageOfCCTool/
├── frontend/                 # Angular application
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/
│   │   │   │   ├── home/
│   │   │   │   ├── continuous-clearing/
│   │   │   │   └── cicd-demo/
│   │   │   ├── services/
│   │   │   └── app.routes.ts
│   │   └── main.ts
│   ├── angular.json
│   └── package.json
│
├── backend/                  # ASP.NET Core API
│   ├── Program.cs
│   ├── Controllers/
│   │   └── OsesController.cs
│   └── backend.csproj
│
├── .github/
│   └── workflows/
│       ├── cc.yml                      # Caller workflow
│       └── continuous-clearing.yml     # Reusable workflow
│
└── README.md                 # This file
```

## 🚀 Getting Started

### Prerequisites

- **Node.js** 18+ and npm
- **.NET 8 SDK** (latest LTS)
- **Angular CLI**: `npm install -g @angular/cli`

### Running the Backend

```bash
cd backend
dotnet restore
dotnet run
```

Backend will run on `http://localhost:5000` (or `http://localhost:5130` depending on configuration)

### Running the Frontend

```bash
cd frontend
npm install
ng serve
```

Frontend will run on `http://localhost:4200`

### API Endpoints

| Endpoint | Description |
|----------|-------------|
| `GET /api/oses/overview` | Returns OSES migration explanation |
| `GET /api/continuous-clearing` | Returns Continuous Clearing workflow details |
| `GET /api/github-actions` | Returns sample reusable workflow YAML |

## 📖 How to Use the Demo

1. **Start the backend** API server
2. **Start the frontend** Angular app
3. **Navigate** through the UI:
   - **Home**: Learn about OSES migration
   - **Continuous Clearing**: Understand the CC Tool workflow
   - **CI/CD Demo**: See how GitHub Actions integrate with CC Tool

## 🎯 Educational Goals

This demo teaches:

- ✅ **OSES migration concepts** and benefits
- ✅ **Continuous Clearing** for license compliance
- ✅ **Reusable GitHub Actions** workflows
- ✅ **Artifact-based communication** between jobs
- ✅ **SBOM generation** for supply chain security
- ✅ **Full-stack development** with Angular + ASP.NET Core

## 🔒 Security & Compliance

The Continuous Clearing workflow demonstrates:

- **SBOM Generation**: Creates machine-readable software bill of materials
- **License Compliance**: Scans for GPL, MIT, Apache, proprietary licenses
- **Vulnerability Scanning**: Checks dependencies against CVE databases
- **Policy Enforcement**: Configurable pass/fail criteria

## 📝 License

This is a demo/educational project. Use it to learn about OSES migration and Continuous Clearing concepts.

## 🤝 Contributing

This is an educational demo. Feel free to fork and extend for your learning purposes!

---

**Note**: This application is for demonstration and learning purposes only. It is intentionally kept simple to focus on educational value rather than production readiness.
