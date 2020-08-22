import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { UserWordsComponent } from './Words/UserWords.component';
import { AccountRoutingModule } from './AccountModule/Account-routing.module';
import { AccountModule } from './AccountModule/Account.Module';


const routes: Routes = [
  { path: '', redirectTo: 'Account', pathMatch:'full'},
  { path: 'words', component: UserWordsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
