import { NgModule } from '@angular/core';
import { AccountService } from '../Services/account.service';
import { UserComponent } from './User/user.component';
import { MaterialModule } from '../Modules/Material.module';
import { UserRoutingModule } from './User-routing.module';
import { AuthGuard } from '../Helpers/AuthGuard';
import { UserLayoutComponent } from './UserLayout/userLayout.component';
import { EditUserComponent } from './EditUser/editUser.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
    imports:[
        MaterialModule,
        UserRoutingModule,
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpClientModule,
        MatNativeDateModule,
        ReactiveFormsModule,
    ],
    providers:[
        AccountService,
        AuthGuard
    ],
    declarations:[
        UserComponent,
        UserLayoutComponent,
        EditUserComponent
    ]

})
export class UserModule { }