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
import { RecipientService } from './services/recipient.service';
import { CurrencyService } from './services/currency.service';
import { CategoryService } from './services/category.service';
import { FormFieldComponent } from './components/shared/form-field/form-field.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from "@angular/material-moment-adapter";
import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AmountInputComponent } from './components/shared/amount-input/amount-input.component';
import { CategoriesPageComponent } from './components/sections/categories-page/categories-page.component';
import { CategoryEditorComponent } from './components/shared/category-editor/category-editor.component';
import { RecipientsPageComponent } from './components/sections/recipients-page/recipients-page.component';
import { RecipientEditorComponent } from './components/shared/recipient-editor/recipient-editor.component';

const appRoutes: Routes = [
  { path: 'transactions', component: TransactionsPageComponent },
  { path: 'categories', component: CategoriesPageComponent },
  { path: 'recipients', component: RecipientsPageComponent },
  { path: '**', redirectTo: '/transactions', pathMatch: 'full' },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TransactionsPageComponent,
    TransactionListComponent,
    TransactionEditorComponent,
    FormFieldComponent,
    AmountInputComponent,
    CategoriesPageComponent,
    CategoryEditorComponent,
    RecipientsPageComponent,
    RecipientEditorComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    MatButtonModule,
    MatDatepickerModule,
    MatInputModule,
    MatFormFieldModule,
    MatMomentDateModule,
    MatRadioModule,
    MatSelectModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
  ],
  providers: [ 
    TransactionService,
    RecipientService,
    CurrencyService,
    CategoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
