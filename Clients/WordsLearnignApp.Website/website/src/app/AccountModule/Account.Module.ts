import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LayoutComponent } from './layout/layout.component';
import { AccountRoutingModule } from './Account-routing.module';



@NgModule({
    imports:[
        AccountRoutingModule
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        LayoutComponent
    ]
})
export class AccountModule { }