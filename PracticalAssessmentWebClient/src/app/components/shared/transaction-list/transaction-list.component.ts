import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Moment } from 'moment';
import IGroupedTransaction from 'src/app/models/IGroupedTransaction';
import { TransactionService } from 'src/app/services/transaction.service';
import convertDatesToMoment from '../../Helpers';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

  constructor(private readonly transactionService: TransactionService) { }

  public transactions: Array<IGroupedTransaction>;

  @Output()
  public onNewTransactionRequested = new EventEmitter<Moment>();

  public async ngOnInit() {
    const response = await this.transactionService.getGroupedTransactions();
    this.transactions = convertDatesToMoment(response);
  }
}
