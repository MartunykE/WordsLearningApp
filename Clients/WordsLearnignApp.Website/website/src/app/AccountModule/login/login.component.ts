import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';



@Component({
    selector: "login",
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    loginForm: FormGroup;

    constructor(private accountService: AccountService, private formBuilder: FormBuilder, private router:Router) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            Login: ['', Validators.required],
            Password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    login() {
        if (this.loginForm.valid) {
            console.log('valid');
            this.accountService.login(this.loginForm.value.Login, this.loginForm.value.Password)
            .pipe(first())
            .subscribe(
                p=> 
                this.router.navigate(['User'])
            );

        }
    }
    
    goUser(){
        this.router.navigate(['Register']);
    }

    token() {
        console.log(localStorage.getItem('user'));
    }
}