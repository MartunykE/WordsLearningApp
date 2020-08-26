import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AccountService } from '../Services/account.service';

export class AuthGuard implements CanActivate {

    constructor(private router: Router, private accountService: AccountService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        const user = this.accountService.currentUserValue;
        if (user){
            return true;            
        }
        this.router.navigate(['/Account/Login']);
        return false;
    }



}