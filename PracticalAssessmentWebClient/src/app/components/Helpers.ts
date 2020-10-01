import * as moment from 'moment';
import IGroupedTransaction from '../models/IGroupedTransaction';

export function convertDatesToMoment(input: Array<IGroupedTransaction>): Array<IGroupedTransaction> {
    input.forEach(_ => {
        _.date = moment(_.date);
        _.transactions.forEach(tr => tr.occuredOn = moment(tr.occuredOn));
    });

    return input;
}

export function selectMany<TAggregatedItem, TSource>(source: Array<TSource>, selector: (item: TSource) => Array<TAggregatedItem>): Array<TAggregatedItem> {
    const output = new Array<TAggregatedItem>();
    source.forEach(_ => output.push(...selector(_)));

    return output;
}