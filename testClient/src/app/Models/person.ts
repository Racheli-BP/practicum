import { Child } from "./child";

export class Person {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public tz: string,
        public birthDate: Date,
        public genderId: number,
        public healthFundId: number,
    ) { }
}
