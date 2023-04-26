import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs"
import { DataService } from "src/app/services/Data.service";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private msg: DataService, private router: Router) { }
    isLogin() {
        if (this.msg.User != null) return true;
        return false;
    }
}