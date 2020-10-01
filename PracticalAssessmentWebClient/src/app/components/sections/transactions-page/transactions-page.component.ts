import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Moment } from 'moment';
import ITransaction from 'src/app/models/ITransaction';
import { TransactionEditorComponent } from '../../shared/transaction-editor/transaction-editor.component';

@Component({
  selector: 'app-transactions-page',
  templateUrl: './transactions-page.component.html',
  styleUrls: ['./transactions-page.component.css']
})
export class TransactionsPageComponent implements OnInit {

  constructor(private readonly dialog: MatDialog) { }

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
}
