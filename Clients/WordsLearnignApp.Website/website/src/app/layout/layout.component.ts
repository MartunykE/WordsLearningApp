import { Component } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { User } from 'src/app/Models/User';
import { AccountService } from 'src/app/Services/account.service';
import { MaterialModule } from 'src/app/Modules/Material.module';


@Component({
    selector: "layout",
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
    public user: User;
   public a: string  ;
    constructor(private accountService: AccountService, private router:Router){ 
        this.accountService.currentUser.subscribe(currentUser=>{
            try {
                
                console.log(currentUser.Id);
            } catch (error) {
                
            }
            this.user = currentUser
        }); 
    }
    f(){
        this.a = 'f';
        console.log( this.accountService.currentUser.value.Id);
        //TODO: look why user is null;
        console.log(localStorage.getItem('user'));
    }
    
    ff(){
      console.log(this.a);  
    }
    logout(){
        this.accountService.logout();
        this.router.navigate(['Account/Login']);
       
    }

    
}