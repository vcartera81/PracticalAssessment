import { Moment } from 'moment';
import ITransaction from './ITransaction';

export default interface IGroupedTransaction {
    transactions: Array<ITransaction>;
    date: Moment;
    balance: number;
}