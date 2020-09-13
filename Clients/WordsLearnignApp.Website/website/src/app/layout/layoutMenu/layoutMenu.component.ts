import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/User';
import { AccountService } from 'src/app/Services/account.service';


@Component({
    selector: 'layout-menu',
    templateUrl: './layoutMenu.component.html',
    styleUrls: ['./layoutMenu.component.css']
})
export class LayoutMenuComponent{

    user: User;
    
    constructor(private accountService: AccountService, private router:Router){ 
        this.accountService.currentUser.subscribe(currentUser=>{            
            this.user = currentUser
        }); 
    }
   
    ngOnInit(){

    }

    logout(){
        this.accountService.logout();
        this.router.navigate(['Account/Login']);
       
    }
}