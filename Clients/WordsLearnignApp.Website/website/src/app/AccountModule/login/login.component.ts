import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';



@Component({
    selector: "login",
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent{
    constructor(private accountService: AccountService){}

    login(){
        this.accountService.login('myUserName','password').subscribe();
    }
    token(){
        console.log(localStorage.getItem('user'));
    }
}