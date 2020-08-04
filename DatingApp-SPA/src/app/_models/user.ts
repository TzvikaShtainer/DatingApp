import { photo } from "./Photo";

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    intrests?: string;
    introduction?: string;
    lookingFor?: string;
    photos?: photo[];
}
