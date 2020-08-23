import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';



@Component({
    selector: "register",
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent{

    constructor(private accountService: AccountService){}

    register(){
        this.accountService.register(new User());
    }
}