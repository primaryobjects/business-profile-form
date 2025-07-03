import { Injectable } from '@angular/core';
import { Contact } from './contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  readonly url: string = `http://localhost:5051/api/contact`;

  constructor() { }

  async saveContact(contact: Contact): Promise<Contact> {
    const response = await fetch(this.url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(contact)
    });

    if (!response.ok) {
      const error = await response.json();
      throw new Error(error.message || `Server returned status ${response.status}`);
    }

    const data = await response.json();
    return data as Contact;
  }
}