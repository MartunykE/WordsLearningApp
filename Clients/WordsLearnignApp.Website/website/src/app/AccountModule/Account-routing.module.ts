import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
    {
        path: 'Account', component: LayoutComponent,
        children: [
            { path: 'Register', component: RegisterComponent },
            { path: 'Login', component: LoginComponent },

        ]
    }
];

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AccountRoutingModule { }