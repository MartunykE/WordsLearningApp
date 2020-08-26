import { NgModule } from '@angular/core';
import { AccountService } from '../Services/account.service';
import { UserComponent } from './User/user.component';
import { MaterialModule } from '../Modules/Material.module';
import { UserRoutingModule } from './User-routing.module';


@NgModule({
    imports:[
        MaterialModule,
        UserRoutingModule
    ],
    providers:[
        AccountService
    ],
    declarations:[
        UserComponent
    ]

})
export class UserModule { }