export interface BookModel {
    id: number;
    name: string;
    authers: string[];
    numberOfPages: number;
    description: string;
    isActive: boolean;
    dateOfPublication: number;
}
