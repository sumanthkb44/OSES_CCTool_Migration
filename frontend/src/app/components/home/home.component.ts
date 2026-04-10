import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatChipsModule } from '@angular/material/chips';
import { OsesApiService } from '../../services/oses-api.service';

/**
 * Home Component - Displays OSES Migration overview
 * Fetches data from backend API and presents educational content
 * about Open Source Engineering Stack migration
 */
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatChipsModule
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  osesData: any = null;
  loading = true;
  error: string | null = null;

  constructor(private osesApiService: OsesApiService) { }

  ngOnInit(): void {
    this.loadOsesOverview();
  }

  /**
   * Load OSES overview data from the backend API
   */
  loadOsesOverview(): void {
    this.osesApiService.getOsesOverview().subscribe({
      next: (data) => {
        this.osesData = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading OSES overview:', err);
        this.error = 'Failed to load OSES overview. Make sure the backend API is running on http://localhost:5000';
        this.loading = false;
      }
    });
  }
}
