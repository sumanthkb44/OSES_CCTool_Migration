import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ContinuousClearingComponent } from './components/continuous-clearing/continuous-clearing.component';
import { CicdDemoComponent } from './components/cicd-demo/cicd-demo.component';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'continuous-clearing', component: ContinuousClearingComponent },
  { path: 'cicd-demo', component: CicdDemoComponent },
  { path: '**', redirectTo: '/home' }
];
