import { EventEmitter } from '@angular/core';
import ITransaction from '../models/ITransaction';

export default class  GlobalEvents {
    public static onNewTransactionAdded = new EventEmitter<ITransaction>();
    public static onTransactionUpdated = new EventEmitter<ITransaction>();
    public static onTransactionDeleted = new EventEmitter<number>();
}