import { Component, Output } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { User } from 'src/app/Models/User';
import { AccountService } from 'src/app/Services/account.service';
import { MaterialModule } from 'src/app/Modules/Material.module';
import {  LayoutMenuComponent} from "../layout/layoutMenu/layoutMenu.component";

@Component({
    selector: "layout",
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
    @Output() user: User;
    
    constructor(private accountService: AccountService, private router:Router){ 
        this.accountService.currentUser.subscribe(currentUser=>{            
            this.user = currentUser
        }); 
    }
   
    // logout(){
    //     this.accountService.logout();
    //     this.router.navigate(['Account/Login']);
       
    // }

    
}