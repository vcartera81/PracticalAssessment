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

  public async add(model: ICategory): Promise<number> {
    return await this.client.post<number>(`${this.baseUrl}category`, model).toPromise();
  }

  public async delete(id: number): Promise<void> {
    return await this.client.delete<void>(`${this.baseUrl}category/${id}`).toPromise();
  }
}
