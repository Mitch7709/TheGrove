import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})
export class Nav implements OnInit {
  ngOnInit(): void {
    document.documentElement.setAttribute('data-theme', 'light');
  }
}

// export const routes: Routes = [
//   { path: '', loadComponent: () => import('../layout/home/home').then(m => m.Home) },
//   { path: 'students', loadComponent: () => import('../layout/students/students').then(m => m.Students) },
//   { path: 'instructors', loadComponent: () => import('../layout/instructors/instructors').then(m => m.Instructors) },
//   { path: 'classes', loadComponent: () => import('../layout/classes/classes').then(m => m.Classes) },
// ];
