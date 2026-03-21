import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  setTheme(theme: string): void {
    console.log(`Setting theme to ${theme}`);
    document.documentElement.setAttribute('data-theme', theme);
  }
}
