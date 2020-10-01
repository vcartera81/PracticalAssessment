import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Moment } from 'moment';
import ITransaction from 'src/app/models/ITransaction';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { TransactionService } from 'src/app/services/transaction.service';
import { TransactionEditorComponent } from '../../shared/transaction-editor/transaction-editor.component';

@Component({
  selector: 'app-transactions-page',
  templateUrl: './transactions-page.component.html',
  styleUrls: ['./transactions-page.component.css']
})
export class TransactionsPageComponent implements OnInit {

  constructor(
    private readonly dialog: MatDialog,
    private readonly transactionService: TransactionService) { }

  ngOnInit(): void {
  }

  public onNewTransactionRequested(forDate: Moment) {
    this.dialog.open(TransactionEditorComponent, {
      width: '600px',
      data: {
        occuredOn: forDate
      } as ITransaction
    });
  }

  public onTransactionEditRequested(transaction: ITransaction) {
    this.dialog.open(TransactionEditorComponent, {
      width: '600px',
      data: transaction
    });
  }

  public async onTransactionDeleteRequested(transactionId: number) {
    await this.transactionService.delete(transactionId);
    GlobalEvents.onTransactionDeleted.emit(transactionId);
  }
}
