export interface Contact {
    businessName?: string,
    contactName?: string,
    email?: string,
    phone?: string,
    industry?: string,
    businessSize?: string,
    contactMethod?: string,
    services: Array<'consulting' | 'support' | 'training'>
};