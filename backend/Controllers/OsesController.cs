using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// API Controller for OSES (Open Source Engineering Stack) educational endpoints.
/// Provides information about OSES migration, Continuous Clearing, and GitHub Actions workflows.
/// </summary>
[ApiController]
[Route("api")]
public class OsesController : ControllerBase
{
    /// <summary>
    /// GET /api/oses/overview
    /// Returns an overview of OSES migration concepts and benefits
    /// </summary>
    [HttpGet("oses/overview")]
    public IActionResult GetOsesOverview()
    {
        var overview = new
        {
            title = "OSES Migration Overview",
            description = "Open Source Engineering Stack (OSES) migration is the process of transitioning development workflows to leverage open-source tools and best practices.",
            keyBenefits = new[]
            {
                "Standardization on industry-proven open-source tools",
                "Improved transparency through open licensing and code review",
                "Enhanced automation via CI/CD pipelines",
                "Better compliance with automated license and security scanning",
                "Cost reduction by eliminating proprietary tool dependencies"
            },
            migrationPhases = new[]
            {
                new { phase = 1, name = "Assessment", description = "Evaluate current toolchain and identify gaps" },
                new { phase = 2, name = "Planning", description = "Design target architecture with open-source alternatives" },
                new { phase = 3, name = "Implementation", description = "Gradually migrate workflows and automate processes" },
                new { phase = 4, name = "Optimization", description = "Refine CI/CD pipelines and establish best practices" }
            },
            coreComponents = new[]
            {
                "Version Control: Git/GitHub",
                "CI/CD: GitHub Actions, Jenkins, GitLab CI",
                "Build Tools: Maven, Gradle, npm",
                "Quality Gates: SonarQube, ESLint",
                "Security Scanning: Continuous Clearing, Dependabot",
                "Artifact Management: Nexus, Artifactory"
            }
        };

        return Ok(overview);
    }

    /// <summary>
    /// GET /api/continuous-clearing
    /// Returns detailed information about Siemens Continuous Clearing workflow
    /// </summary>
    [HttpGet("continuous-clearing")]
    public IActionResult GetContinuousClearing()
    {
        var clearingInfo = new
        {
            title = "Continuous Clearing Workflow",
            tagline = "Automate open-source compliance in your CI/CD pipeline",
            description = "Continuous Clearing is Siemens' approach to automating license compliance and vulnerability scanning for open-source dependencies.",
            
            workflow = new object[]
            {
                new { 
                    step = 1, 
                    name = "Dependency Detection", 
                    description = "Scans project files (package.json, pom.xml, requirements.txt) to identify all dependencies",
                    tools = new[] { "npm audit", "Maven Dependency Plugin", "pip-audit" },
                    output = (string?)null,
                    criteria = (string[]?)null
                },
                new { 
                    step = 2, 
                    name = "License Identification", 
                    description = "Extracts license information from each dependency",
                    tools = new[] { "license-checker", "SPDX tools", "FOSSology" },
                    output = (string?)null,
                    criteria = (string[]?)null
                },
                new { 
                    step = 3, 
                    name = "Vulnerability Scanning", 
                    description = "Checks dependencies against CVE databases for known vulnerabilities",
                    tools = new[] { "OWASP Dependency-Check", "Snyk", "npm audit" },
                    output = (string?)null,
                    criteria = (string[]?)null
                },
                new { 
                    step = 4, 
                    name = "SBOM Generation", 
                    description = "Creates a Software Bill of Materials (SBOM) in SPDX or CycloneDX format",
                    tools = (string[]?)null,
                    output = "Machine-readable inventory of all components",
                    criteria = (string[]?)null
                },
                new { 
                    step = 5, 
                    name = "Policy Enforcement", 
                    description = "Applies organizational policies to block non-compliant builds",
                    tools = (string[]?)null,
                    output = (string?)null,
                    criteria = new[] { "No GPL licenses", "No Critical vulnerabilities", "All dependencies documented" }
                }
            },

            sbomFormats = new[]
            {
                new { format = "SPDX", description = "ISO/IEC 5962 standard for software bill of materials", fileType = "JSON/XML" },
                new { format = "CycloneDX", description = "OWASP standard for Software Bill of Materials", fileType = "JSON/XML" }
            },

            benefits = new[]
            {
                "Early detection of license compliance issues",
                "Automated vulnerability alerting",
                "Reduced manual effort in compliance reviews",
                "Audit-ready documentation (SBOM)",
                "Prevention of non-compliant code reaching production"
            },

            integrationPoints = new[]
            {
                "GitHub Actions: Runs on every PR and merge to main",
                "Artifact Storage: SBOM uploaded as build artifact",
                "Notifications: Slack/Email alerts on policy violations",
                "Gates: Blocks deployment if critical issues found"
            }
        };

        return Ok(clearingInfo);
    }

    /// <summary>
    /// GET /api/github-actions
    /// Returns sample GitHub Actions YAML demonstrating reusable workflow for Continuous Clearing
    /// </summary>
    [HttpGet("github-actions")]
    public IActionResult GetGitHubActionsYaml()
    {
        // Sample YAML for a reusable Continuous Clearing workflow
        var yaml = @"# ============================================================
# Reusable Workflow: Continuous Clearing
# ============================================================
# This workflow demonstrates how to create a reusable GitHub Action
# for Continuous Clearing (license compliance + vulnerability scanning)
#
# Key Concepts:
# 1. Reusable workflows (workflow_call trigger)
# 2. Input parameters for flexibility
# 3. Artifact-based data passing
# 4. SBOM generation
# ============================================================

name: Continuous Clearing (Reusable)

on:
  workflow_call:
    inputs:
      # Input: SBOM format (spdx or cyclonedx)
      sbom-format:
        description: 'SBOM format to generate (spdx or cyclonedx)'
        required: false
        type: string
        default: 'spdx'
      
      # Input: Fail build on critical vulnerabilities
      fail-on-critical:
        description: 'Fail the build if critical vulnerabilities are found'
        required: false
        type: boolean
        default: true
      
      # Input: Working directory (for monorepos)
      working-directory:
        description: 'Working directory to scan'
        required: false
        type: string
        default: '.'
    
    outputs:
      # Output: SBOM artifact name
      sbom-artifact:
        description: 'Name of the SBOM artifact'
        value: ${{ jobs.clearing.outputs.sbom-name }}

jobs:
  clearing:
    name: License & Vulnerability Scan
    runs-on: ubuntu-latest
    
    outputs:
      sbom-name: ${{ steps.sbom.outputs.artifact-name }}
    
    steps:
      # Step 1: Checkout code
      - name: Checkout repository
        uses: actions/checkout@v4
      
      # Step 2: Set up Node.js (if scanning Node.js project)
      - name: Set up Node.js
        uses: actions/setup-node@v4
        with:
          node-version: '20'
      
      # Step 3: Install dependencies
      - name: Install dependencies
        working-directory: ${{ inputs.working-directory }}
        run: npm ci
      
      # Step 4: Run license check
      - name: Check licenses
        working-directory: ${{ inputs.working-directory }}
        run: |
          echo ""Scanning licenses...""
          npx license-checker --json --out licenses.json
          
          # Example: Check for GPL licenses (customize per policy)
          if npx license-checker --failOn 'GPL' ; then
            echo ""✅ License check passed""
          else
            echo ""❌ GPL license detected - policy violation""
            exit 1
          fi
      
      # Step 5: Run vulnerability scan
      - name: Scan for vulnerabilities
        working-directory: ${{ inputs.working-directory }}
        run: |
          echo ""Scanning for vulnerabilities...""
          npm audit --json > audit-report.json || true
          
          # Check for critical vulnerabilities
          CRITICAL=$(npm audit --json | jq '.metadata.vulnerabilities.critical // 0')
          echo ""Critical vulnerabilities: $CRITICAL""
          
          if [ ""${{ inputs.fail-on-critical }}"" == ""true"" ] && [ $CRITICAL -gt 0 ]; then
            echo ""❌ Critical vulnerabilities found - failing build""
            exit 1
          fi
      
      # Step 6: Generate SBOM (Software Bill of Materials)
      - name: Generate SBOM
        id: sbom
        working-directory: ${{ inputs.working-directory }}
        run: |
          echo ""Generating SBOM in ${{ inputs.sbom-format }} format...""
          
          # Install SBOM tools (example using CycloneDX)
          npm install -g @cyclonedx/cyclonedx-npm
          
          # Generate SBOM
          if [ ""${{ inputs.sbom-format }}"" == ""cyclonedx"" ]; then
            cyclonedx-npm --output-file sbom.json
          else
            # For SPDX, use spdx-sbom-generator or similar tool
            echo ""Generating SPDX SBOM (placeholder)""
            echo '{""spdxVersion"": ""SPDX-2.3""}' > sbom.json
          fi
          
          echo ""artifact-name=sbom-${{ github.sha }}"" >> $GITHUB_OUTPUT
      
      # Step 7: Upload SBOM as artifact
      - name: Upload SBOM artifact
        uses: actions/upload-artifact@v4
        with:
          name: sbom-${{ github.sha }}
          path: ${{ inputs.working-directory }}/sbom.json
          retention-days: 30
      
      # Step 8: Upload scan reports
      - name: Upload scan reports
        uses: actions/upload-artifact@v4
        with:
          name: scan-reports-${{ github.sha }}
          path: |
            ${{ inputs.working-directory }}/licenses.json
            ${{ inputs.working-directory }}/audit-report.json
          retention-days: 30
      
      # Step 9: Summary
      - name: Create summary
        run: |
          echo ""## 🔍 Continuous Clearing Summary"" >> $GITHUB_STEP_SUMMARY
          echo """" >> $GITHUB_STEP_SUMMARY
          echo ""✅ License compliance check: Passed"" >> $GITHUB_STEP_SUMMARY
          echo ""✅ Vulnerability scan: Completed"" >> $GITHUB_STEP_SUMMARY
          echo ""✅ SBOM generated: ${{ steps.sbom.outputs.artifact-name }}"" >> $GITHUB_STEP_SUMMARY
          echo """" >> $GITHUB_STEP_SUMMARY
          echo ""### Artifacts Generated"" >> $GITHUB_STEP_SUMMARY
          echo ""- SBOM (Software Bill of Materials)"" >> $GITHUB_STEP_SUMMARY
          echo ""- License report"" >> $GITHUB_STEP_SUMMARY
          echo ""- Vulnerability audit report"" >> $GITHUB_STEP_SUMMARY

# ============================================================
# How to use this reusable workflow (caller example):
# ============================================================
#
# name: CI Pipeline with Continuous Clearing
#
# on:
#   push:
#     branches: [main]
#   pull_request:
#     branches: [main]
#
# jobs:
#   continuous-clearing:
#     uses: ./.github/workflows/continuous-clearing.yml
#     with:
#       sbom-format: spdx
#       fail-on-critical: true
#       working-directory: ./frontend
#
# ============================================================
";

        return Ok(new { yaml = yaml });
    }
}
