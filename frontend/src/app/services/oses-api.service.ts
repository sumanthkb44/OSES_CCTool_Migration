import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

/**
 * Service for communicating with the OSES backend API
 * Provides methods to fetch educational content about OSES migration,
 * Continuous Clearing, and GitHub Actions workflows
 */
@Injectable({
  providedIn: 'root'
})
export class OsesApiService {
  private apiUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  /**
   * Fetch OSES migration overview from the backend
   * @returns Observable with OSES overview data
   */
  getOsesOverview(): Observable<any> {
    return this.http.get(`${this.apiUrl}/oses/overview`);
  }

  /**
   * Fetch Continuous Clearing workflow information
   * @returns Observable with Continuous Clearing details
   */
  getContinuousClearing(): Observable<any> {
    return this.http.get(`${this.apiUrl}/continuous-clearing`);
  }

  /**
   * Fetch sample GitHub Actions YAML workflow
   * @returns Observable with GitHub Actions YAML content
   */
  getGitHubActionsYaml(): Observable<any> {
    return this.http.get(`${this.apiUrl}/github-actions`);
  }
}
