import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IGroupedTransaction from '../models/IGroupedTransaction';
import ITransaction from '../models/ITransaction';
import ServiceBase from './ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class TransactionService extends ServiceBase {

  constructor(private readonly client: HttpClient) { super(); }

  public async getGroupedTransactions(): Promise<Array<IGroupedTransaction>> {
    return await this.client.get<Array<IGroupedTransaction>>(`${this.baseUrl}transaction/grouped`).toPromise();
  }

  public async add(transaction: ITransaction): Promise<number> {
    return await this.client.post<number>(`${this.baseUrl}transaction`, transaction).toPromise();
  }

  public async update(transaction: ITransaction): Promise<void> {
    return await this.client.put<void>(`${this.baseUrl}transaction`, transaction).toPromise();
  }

  public async delete(transactionId: number): Promise<void> {
    return await this.client.delete<void>(`${this.baseUrl}transaction/${transactionId}`).toPromise();
  }
}
