import { Moment } from 'moment';
import ICategory from './ICategory';
import ICurrency from './ICurrency';
import IRecipient from './IRecipient';

export default interface ITransaction {
    id: number;
    occuredOn: Moment;
    title: string;
    amount: number;
    currency: ICurrency;
    category: ICategory;
    recipient: IRecipient;
}