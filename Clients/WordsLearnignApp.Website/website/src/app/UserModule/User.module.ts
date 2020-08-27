import { NgModule } from '@angular/core';
import { AccountService } from '../Services/account.service';
import { UserComponent } from './User/user.component';
import { MaterialModule } from '../Modules/Material.module';
import { UserRoutingModule } from './User-routing.module';
import { AuthGuard } from '../Helpers/AuthGuard';


@NgModule({
    imports:[
        MaterialModule,
        UserRoutingModule
    ],
    providers:[
        AccountService,
        AuthGuard
    ],
    declarations:[
        UserComponent
    ]

})
export class UserModule { }