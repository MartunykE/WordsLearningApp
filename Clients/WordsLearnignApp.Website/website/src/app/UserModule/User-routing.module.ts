import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditUserComponent } from './EditUser/editUser.component';
import { UserLayoutComponent } from './UserLayout/userLayout.component';
import { WordsComponent } from './Words/words.component';

const routes: Routes = [{
    path: 'User', component: UserLayoutComponent,
    children:[
         {path: ':id/Edit', component: EditUserComponent},
         {path: ':id/Words', component: WordsComponent}
    ]
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }