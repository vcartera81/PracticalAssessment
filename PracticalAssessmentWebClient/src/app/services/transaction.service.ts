import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IGroupedTransaction from '../models/IGroupedTransaction';
import ServiceBase from './ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class TransactionService extends ServiceBase {

  constructor(private readonly client: HttpClient) { super(); }

  public async getGroupedTransactions(): Promise<Array<IGroupedTransaction>> {
    return await this.client.get<Array<IGroupedTransaction>>(`${this.baseUrl}transaction/grouped`).toPromise();
  }
}
