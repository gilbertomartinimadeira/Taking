import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    RouterModule
  ],
  template: `
    <mat-toolbar color="primary">
      <span>Sales Management</span>
      <span class="spacer"></span>
      <a mat-button routerLink="/create-sale">Create Sale</a>
      <a mat-button routerLink="/list-sales">List Sales</a>
    </mat-toolbar>
  `,
  styles: [`
    mat-toolbar {
      display: flex;
      justify-content: space-between;
    }
    .spacer {
      flex: 1;
    }
    a {
      text-decoration: none;
      color: white;
      margin-left: 10px;
    }
  `]
})
export class NavbarComponent { }
