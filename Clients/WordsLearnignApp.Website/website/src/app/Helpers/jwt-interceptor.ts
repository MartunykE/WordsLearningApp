import { Injectable } from '@angular/core';
import { AccountService } from '../Services/account.service';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import { environment } from 'src/environments/environment';
import { NgIfContext } from '@angular/common';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private accountService: AccountService) { }


    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        let user: User;
        this.accountService.currentUser.subscribe(u => user = u);
        const isLogged = user && user.token;
        if (isLogged) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${user.token}`
                }
            });
        }
        return next.handle(request);
    }



}