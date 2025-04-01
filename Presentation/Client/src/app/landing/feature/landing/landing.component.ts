import { Component } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  standalone: false,
})
export class LandingComponent {
  features: Feature[] = [
    {
      title: 'Create Personal Wishlists',
      description:
        'Add gifts with descriptions, priority levels, and purchase links to help friends and family find the perfect gift.',
      icon: 'pi pi-gift text-3xl! text-marmelade-500',
    },
    {
      title: 'Guest Browsing',
      description:
        'Browse public wishlists without registration, easy for anyone to find gift ideas.',
      icon: 'pi pi-users text-3xl! text-sky-500',
    },
    {
      title: 'Share with Friends',
      description:
        'Share your wishlists privately with friends or make them public for everyone to see.',
      icon: 'pi pi-share-alt text-3xl! text-marmelade-500',
    },
    {
      title: 'Filter by Event',
      description:
        'Find the perfect gift by using different filters to suit your needs.',
      icon: 'pi pi-search text-3xl! text-sky-500',
    },
    {
      title: 'Save Favorites',
      description:
        'Add gifts from public wishlists to your own collection for future reference.',
      icon: 'pi pi-star text-3xl! text-marmelade-500',
    },
    {
      title: 'Event Organization',
      description:
        'Create wishlists for special events and keep track of important dates.',
      icon: 'pi pi-calendar text-3xl! text-sky-500',
    },
  ];
  steps: Feature[] = [
    {
      title: 'Create an Account',
      description: 'Sign up for free and set up your profile in seconds.',
    },
    {
      title: 'Add Your Wishes',
      description:
        'Create wishlists and add items with details and priority levels.',
    },
    {
      title: 'Share & Discover',
      description:
        'Share your lists with friends or browse public lists for inspiration.',
    },
  ];
  testimonials: Testimonial[] = [
    {
      name: 'Sarah J.',
      quote:
        'Höffly made organizing my wedding registry so much easier! Our guests loved how easy it was to find gifts we actually wanted.',
      title: 'Bride-to-be',
    },
    {
      name: 'Michael T.',
      quote:
        'I use Höffly for all my family birthdays. Being able to share wishlists privately has been a game-changer for us.',
      title: 'Family Organizer',
    },
    {
      name: 'Jessica K.',
      quote:
        'As someone who struggles to find gift ideas, browsing public wishlists has given me so much inspiration!',
      title: 'Gift Shopper',
    },
  ];
}

interface Feature {
  title: string;
  description: string;
  icon?: string;
}

interface Testimonial {
  name: string;
  quote: string;
  title: string;
}
