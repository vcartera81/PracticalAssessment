import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import ICategory from '../models/ICategory';
import ServiceBase from './ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends ServiceBase {

  constructor(private readonly client: HttpClient) {
    super();
  }

  public async getAll(): Promise<Array<ICategory>> {
    return await this.client.get<Array<ICategory>>(`${this.baseUrl}category`).toPromise();
  }
}
