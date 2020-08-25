import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MaterialModule } from 'src/app/Modules/Material.module';


@Component({
    selector: "register",
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent {

    registerForm: FormGroup;


    constructor(
        private accountService: AccountService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            Username: ['', Validators.required],
            Password: ['', [Validators.required, Validators.minLength(6)] ],
            ChatId: [''],
            StartSendWordTime: [''],
            FinishSendWordTime: ['']
        });
    }
    register() {
        console.log(this.registerForm.valid);
        let user = this.registerForm.value;
        console.log(user instanceof User);
        console.log(user.Username);
        console.log(user.Password);
        if (this.registerForm.valid) {
            this.accountService.register(user);
        }
    }
}