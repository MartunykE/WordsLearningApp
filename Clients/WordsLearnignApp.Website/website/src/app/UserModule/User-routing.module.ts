import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from '../AccountModule/layout/layout.component';

const routes: Routes = [{


    path: 'User', component: LayoutComponent,
    children:[
        // {path: ':id/Edit', com}
    ]
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }