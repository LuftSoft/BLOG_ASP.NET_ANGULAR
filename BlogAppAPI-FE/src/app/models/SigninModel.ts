export class SigninModel {
    Email?: string;
    Password?: string

    constructor(_e: string, _p: string) {
        this.Email = _e; this.Password = _p;
    }
}