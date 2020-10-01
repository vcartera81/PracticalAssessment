import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Moment } from 'moment';
import { Subscription } from 'rxjs';
import IGroupedTransaction from 'src/app/models/IGroupedTransaction';
import ITransaction from 'src/app/models/ITransaction';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { TransactionService } from 'src/app/services/transaction.service';
import { convertDatesToMoment } from '../../Helpers';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit, OnDestroy {

  private eventSubscriptions = new Array<Subscription>();

  constructor(private readonly transactionService: TransactionService) {
    this.eventSubscriptions.push(GlobalEvents.onNewTransactionAdded.subscribe((tr: ITransaction) => this.onNewTransactionAdded(tr)));
    this.eventSubscriptions.push(GlobalEvents.onTransactionUpdated.subscribe((tr: ITransaction) => this.onTransactionUpdated(tr)));
    this.eventSubscriptions.push(GlobalEvents.onTransactionDeleted.subscribe((trId: number) => this.onTransactionDeleted(trId)));
  }

  public transactions: Array<IGroupedTransaction>;

  @Output()
  public onNewTransactionRequested = new EventEmitter<Moment>();

  @Output()
  public onTransactionEditRequested = new EventEmitter<ITransaction>();

  @Output()
  public onTransactionDeleteRequested = new EventEmitter<number>();

  public async ngOnInit() {
    const response = await this.transactionService.getGroupedTransactions();
    this.transactions = convertDatesToMoment(response);
  }

  public ngOnDestroy() {
    this.eventSubscriptions.forEach(_ => _.unsubscribe());
  }

  private onNewTransactionAdded(tr: ITransaction) {
    const matchingDay = this.transactions
      .find(_ => {
        const date = _.date as Moment;
        const trDate = tr.occuredOn as Moment;

        return date.day == trDate.day &&
          _.date.month === trDate.month &&
          _.date.year === trDate.year
      });

    if (!matchingDay)
      return;

    matchingDay.transactions.push(tr);
  }

  private onTransactionUpdated(tr: ITransaction) {
    this.transactions.forEach(groupedTransaction => {
      const matchingIndex = groupedTransaction.transactions.findIndex(_ => _.id === tr.id);
      if (matchingIndex !== -1)
        groupedTransaction.transactions[matchingIndex] = tr;
    });
  }

  private onTransactionDeleted(transactionId: number) {
    this.transactions.forEach(groupedTransaction => {
      const matchingIndex = groupedTransaction.transactions.findIndex(_ => _.id === transactionId);
      if (matchingIndex !== -1)
        groupedTransaction.transactions.splice(matchingIndex, 1);
    });
  }
}
