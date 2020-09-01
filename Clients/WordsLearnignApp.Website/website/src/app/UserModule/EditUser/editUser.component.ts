import { Component } from '@angular/core';
import { MaterialModule } from 'src/app/Modules/Material.module';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'edit-user',
    templateUrl: './editUser.component.html',
    styleUrls: ['./editUser.component.css']
})
export class EditUserComponent {

    user: User;
    editForm: FormGroup;

    constructor(private accountService: AccountService, private formBuilder: FormBuilder) {
        this.accountService.currentUser
            .subscribe(currentUser => {
                this.user = currentUser;
            });
    }

    ngOnInit() {
        this.editForm = this.formBuilder.group({
            id: [this.user.id],
            username: [this.user.username, Validators.required],
            chatId: [this.user.chatId],
            password: [this.user.password, Validators.required],
            startSendWordTime: [this.user.startSendWordTime],
            finishSendWordTime: [this.user.finishSendWordTime],
            token: [this.user.token]
        });
    }

    saveChanges() {

        this.accountService.currentUser.next(this.editForm.value);
        // this.accountService.

    }

}