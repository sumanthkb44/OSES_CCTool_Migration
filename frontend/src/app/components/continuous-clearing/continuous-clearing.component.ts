import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatChipsModule } from '@angular/material/chips';
import { OsesApiService } from '../../services/oses-api.service';

/**
 * Continuous Clearing Component
 * Displays detailed information about Siemens Continuous Clearing workflow
 * Explains license compliance, vulnerability scanning, and SBOM generation
 */
@Component({
  selector: 'app-continuous-clearing',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatExpansionModule,
    MatChipsModule
  ],
  templateUrl: './continuous-clearing.component.html',
  styleUrls: ['./continuous-clearing.component.css']
})
export class ContinuousClearingComponent implements OnInit {
  clearingData: any = null;
  loading = true;
  error: string | null = null;

  constructor(private osesApiService: OsesApiService) { }

  ngOnInit(): void {
    this.loadContinuousClearing();
  }

  /**
   * Load Continuous Clearing data from the backend API
   */
  loadContinuousClearing(): void {
    this.osesApiService.getContinuousClearing().subscribe({
      next: (data) => {
        this.clearingData = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading Continuous Clearing info:', err);
        this.error = 'Failed to load Continuous Clearing information. Make sure the backend API is running.';
        this.loading = false;
      }
    });
  }
}
