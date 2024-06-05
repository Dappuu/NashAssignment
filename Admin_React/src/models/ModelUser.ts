import { CommentDto } from "./ModelComment";

export interface UserDto{
    userId: string;
    userName: string;
    streetAddres: string;
    city: string;
    firstName: string;
    lastName: string;
    avatarUrl: string;
    dateOfBirth: Date;
    email: string;
    commentDto: CommentDto[];
}