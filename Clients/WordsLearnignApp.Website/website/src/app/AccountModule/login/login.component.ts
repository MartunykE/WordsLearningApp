import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';



@Component({
    selector: "login",
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    loginForm: FormGroup;

    constructor(private accountService: AccountService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            Login: ['', Validators.required],
            Password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    login() {
        console.log(this.loginForm.value.Login);
        console.log(this.loginForm.value.Password);

        if (this.loginForm.valid) {
            console.log('valid');
            this.accountService.login(this.loginForm.value.Login, this.loginForm.value.Password)
            .pipe(first())
            .subscribe();
        }
    }
    token() {
        console.log(localStorage.getItem('user'));
    }
}