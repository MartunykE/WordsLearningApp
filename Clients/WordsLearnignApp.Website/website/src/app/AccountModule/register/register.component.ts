import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MaterialModule } from 'src/app/Modules/Material.module';
import { Route } from '@angular/compiler/src/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    selector: "register",
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent {

    registerForm: FormGroup;

    constructor(
        private accountService: AccountService,
        private formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            Username: ['', Validators.required],
            Password: ['', [Validators.required, Validators.minLength(6)]],
            ChatId: [''],
            StartSendWordTime: [''],
            FinishSendWordTime: ['']
        });

    }
    register() {
        let user = new User();
        user.Username = "Admin2";
        user.Password = "AdminPass";

        if (this.registerForm.valid) {
            this.accountService.register(user)
                .subscribe(
                    userData => {
                        this.router.navigate(['../Login'], { relativeTo: this.route })
                    },
                    error =>{
                        //TODO: error handler
                    }
                );
        }
    }
}