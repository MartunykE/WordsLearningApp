import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AccountRoutingModule } from './AccountModule/Account-routing.module';
import { AccountModule } from './AccountModule/Account.Module';
import { UserComponent } from './UserModule/User/user.component';
import { AuthGuard } from './Helpers/AuthGuard';
import { UserLayoutComponent } from './UserModule/UserLayout/userLayout.component';


const routes: Routes = [
  { path: 'Account', redirectTo: 'Account', pathMatch: 'full' },
  { path: 'User', component: UserLayoutComponent, canActivate:[AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
