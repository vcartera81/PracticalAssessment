import { EventEmitter } from '@angular/core';
import ICategory from '../models/ICategory';
import ITransaction from '../models/ITransaction';

export default class  GlobalEvents {
    public static onNewTransactionAdded = new EventEmitter<ITransaction>();
    public static onTransactionUpdated = new EventEmitter<ITransaction>();
    public static onTransactionDeleted = new EventEmitter<number>();
    public static onCategoryAdded = new EventEmitter<ICategory>();
}