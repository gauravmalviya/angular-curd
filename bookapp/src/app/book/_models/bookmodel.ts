export interface BookModel {
    bookId: number;
    name: string;
    authers: string[];
    numberOfPages: number;
    description: string;
    isActive: boolean;
    dateOfPublication: number;
}
