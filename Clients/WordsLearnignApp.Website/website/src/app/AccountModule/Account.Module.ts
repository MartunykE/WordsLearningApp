import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LayoutComponent } from './layout/layout.component';
import { AccountRoutingModule } from './Account-routing.module';
import { AccountService } from '../Services/account.service';
import { MaterialModule } from '../Modules/Material.module';



@NgModule({
    imports:[
        AccountRoutingModule,
        MaterialModule
    ],
    providers:[
        AccountService
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        LayoutComponent
    ]
})
export class AccountModule { }