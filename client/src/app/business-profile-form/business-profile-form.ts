import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CommonModule } from '@angular/common';
import { Contact } from '../contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-business-profile-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCheckboxModule
  ],
  templateUrl: './business-profile-form.html',
  styleUrl: './business-profile-form.css'
})

export class BusinessProfileForm {
  contact: Contact = {
    services: []
  };

  contactService: ContactService = inject(ContactService);

  constructor() {}

  async onSubmit() {
    const contact = await this.contactService.saveContact(this.contact);
    console.log('Contact saved:', contact);
  }

  onServiceChange(service: string, checked: boolean) {
    const services = this.contact.services as string[];
    if (checked) {
      if (!services.includes(service)) {
        services.push(service);
      }
    } else {
      const idx = services.indexOf(service);
      if (idx > -1) {
        services.splice(idx, 1);
      }
    }
  }
}
