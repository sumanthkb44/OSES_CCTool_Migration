import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { OsesApiService } from '../../services/oses-api.service';

/**
 * CI/CD Demo Component
 * Demonstrates how reusable GitHub Actions workflows work
 * Shows sample YAML configurations and explains artifact-based input passing
 */
@Component({
  selector: 'app-cicd-demo',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatTabsModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './cicd-demo.component.html',
  styleUrls: ['./cicd-demo.component.css']
})
export class CicdDemoComponent implements OnInit {
  yamlContent: string = '';
  loading = true;
  error: string | null = null;

  constructor(private osesApiService: OsesApiService) { }

  ngOnInit(): void {
    this.loadGitHubActionsYaml();
  }

  /**
   * Load GitHub Actions YAML from the backend API
   */
  loadGitHubActionsYaml(): void {
    this.osesApiService.getGitHubActionsYaml().subscribe({
      next: (data) => {
        this.yamlContent = data.yaml;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading GitHub Actions YAML:', err);
        this.error = 'Failed to load GitHub Actions workflow. Make sure the backend API is running.';
        this.loading = false;
      }
    });
  }

  /**
   * Copy YAML content to clipboard
   */
  copyToClipboard(): void {
    navigator.clipboard.writeText(this.yamlContent).then(() => {
      alert('YAML copied to clipboard!');
    }).catch(err => {
      console.error('Failed to copy:', err);
    });
  }
}
