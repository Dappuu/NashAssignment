export interface CommentDto {
    id: number;
    content: string;
    rating: number;
    createdDate: Date;
    productId: number;
    userName: string | null;
}