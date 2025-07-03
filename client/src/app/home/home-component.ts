import { Component } from '@angular/core';
import { BusinessProfileForm } from '../business-profile-form/business-profile-form';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    BusinessProfileForm
  ],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css'
})
export class HomeComponent {}
