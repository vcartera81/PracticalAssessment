import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Moment } from 'moment';
import ICategory from 'src/app/models/ICategory';
import ICurrency from 'src/app/models/ICurrency';
import IRecipient from 'src/app/models/IRecipient';
import ITransaction from 'src/app/models/ITransaction';
import { CategoryService } from 'src/app/services/category.service';
import { CurrencyService } from 'src/app/services/currency.service';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { RecipientService } from 'src/app/services/recipient.service';
import { TransactionService } from 'src/app/services/transaction.service';

@Component({
  selector: 'app-transaction-editor',
  templateUrl: './transaction-editor.component.html',
  styleUrls: ['./transaction-editor.component.css']
})
export class TransactionEditorComponent implements OnInit {

  constructor(
    private readonly categoryService: CategoryService,
    private readonly recipientService: RecipientService,
    private readonly currencyService: CurrencyService,
    private readonly transactionService: TransactionService,
    private readonly dialogRef: MatDialogRef<TransactionEditorComponent>,
    @Inject(MAT_DIALOG_DATA) public inputTransaction: ITransaction) {
    dialogRef.disableClose = true;
  }

  public allRecipients: Array<IRecipient>;
  public allCurrencies: Array<ICurrency>;
  public allCategories: Array<ICategory>;

  public selectedCategoryId: number;
  public selectedCurrencyId: number;
  public selectedRecipientId: number;

  public async ngOnInit() {
    this.allRecipients = await this.recipientService.getAll();
    this.allCurrencies = await this.currencyService.getAll();
    this.allCategories = await this.categoryService.getAll();

    if(this.inputTransaction.id && this.inputTransaction.id > 0)
      this.setModel();
  }

  public transactionEditorForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    occuredOn: new FormControl(this.inputTransaction.occuredOn, [Validators.required]),
    category: new FormControl(null, [Validators.required]),
    currency: new FormControl(null, [Validators.required]),
    recipient: new FormControl(null, [Validators.required]),
    amount: new FormControl(null, [Validators.required]),
  });

  public cancel() {
    this.dialogRef.close();
  }

  public async onSubmit() {
    const matchingCategory = this.allCategories.find(_ => _.id === this.selectedCategoryId);
    const matchingRecipient = this.allRecipients.find(_ => _.id === this.selectedRecipientId);
    const matchingCurrency = this.allCurrencies.find(_ => _.id === this.selectedCurrencyId);
    const occuredOn = this.transactionEditorForm.controls['occuredOn'].value as Moment;

    const model: ITransaction = {
      id: this.inputTransaction.id,
      amount: Number.parseFloat(this.transactionEditorForm.controls['amount'].value),
      category: matchingCategory,
      currency: matchingCurrency,
      recipient: matchingRecipient,
      occuredOn: occuredOn.format(), // hack for UTC dates
      title: this.transactionEditorForm.controls['title'].value,
    }

    if(this.inputTransaction.id && this.inputTransaction.id > 0) {
      await this.transactionService.update(model);
      GlobalEvents.onTransactionUpdated.emit(model);
    }
    else {
      model.id = await this.transactionService.add(model);
      GlobalEvents.onNewTransactionAdded.emit(model);
    }

    model.occuredOn = occuredOn;
    this.dialogRef.close();
  }

  public getCurrencyCodeById(): string {
    if(!this.selectedCurrencyId)
      return null;

      return this.allCurrencies.find(_ => _.id === this.selectedCurrencyId).code;
  }

  private setModel() {
    this.transactionEditorForm.controls['title'].setValue(this.inputTransaction.title);
    this.transactionEditorForm.controls['occuredOn'].setValue(this.inputTransaction.occuredOn);
    this.transactionEditorForm.controls['category'].setValue(this.inputTransaction.category.id);
    this.transactionEditorForm.controls['currency'].setValue(this.inputTransaction.currency.id);
    this.transactionEditorForm.controls['recipient'].setValue(this.inputTransaction.recipient.id);
    this.transactionEditorForm.controls['amount'].setValue(this.inputTransaction.amount);

    this.selectedCurrencyId = this.inputTransaction.currency.id;
    this.selectedCategoryId = this.inputTransaction.category.id;
    this.selectedRecipientId = this.inputTransaction.recipient.id;
  }
}