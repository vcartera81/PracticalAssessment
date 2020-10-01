import * as moment from 'moment';
import IGroupedTransaction from '../models/IGroupedTransaction';

export default function convertDatesToMoment(input: Array<IGroupedTransaction>): Array<IGroupedTransaction> {
    input.forEach(_ => {
        _.date = moment(_.date);
        _.transactions.forEach(tr => tr.occuredOn = moment(tr.occuredOn));
    });

    return input;
}