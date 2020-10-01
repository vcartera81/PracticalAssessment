import { CategoryType } from './CategoryType';

export default interface ICategory {
    id: number;
    name: string;
    type: CategoryType;
}