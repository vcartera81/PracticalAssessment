import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { TransactionsPageComponent } from './components/sections/transactions-page/transactions-page.component';
import { TransactionListComponent } from './components/shared/transaction-list/transaction-list.component';
import { RouterModule, Routes } from '@angular/router';
import { TransactionService } from './services/transaction.service';
import { TransactionEditorComponent } from './components/shared/transaction-editor/transaction-editor.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

const appRoutes: Routes = [
  { path: 'transactions', component: TransactionsPageComponent },
  { path: '**', redirectTo: '/transactions', pathMatch: 'full' },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TransactionsPageComponent,
    TransactionListComponent,
    TransactionEditorComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    MatButtonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
  ],
  providers: [ 
    TransactionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
