import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import ICurrency from '../models/ICurrency';
import ServiceBase from './ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService extends ServiceBase {

  constructor(private readonly client: HttpClient) {
    super();
  }

  public async getAll(): Promise<Array<ICurrency>> {
    return await this.client.get<Array<ICurrency>>(`${this.baseUrl}currency`).toPromise();
  }
}
