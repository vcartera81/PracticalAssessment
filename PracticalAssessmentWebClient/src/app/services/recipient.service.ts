import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IRecipient from '../models/IRecipient';
import ServiceBase from './ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class RecipientService extends ServiceBase {

  constructor(private readonly client: HttpClient) {
    super();
  }

  public async getAll(): Promise<Array<IRecipient>> {
    return await this.client.get<Array<IRecipient>>(`${this.baseUrl}recipient`).toPromise();
  }

  public async add(model: IRecipient): Promise<number> {
    return await this.client.post<number>(`${this.baseUrl}recipient`, model).toPromise();
  }

  public async delete(id: number): Promise<void> {
    return await this.client.delete<void>(`${this.baseUrl}recipient/${id}`).toPromise();
  }
}
