import { Component } from '@angular/core';
import { MaterialModule } from 'src/app/Modules/Material.module';
import { AccountService } from 'src/app/Services/account.service';

@Component({
    selector: 'user-layout',
    templateUrl:'./userLayout.component.html',
    styleUrls: ['./userLayout.component.css']
})
export class UserLayoutComponent{
    
    
    constructor(private accountService: AccountService){}
    
    ngOnInit(){
        
    }
}