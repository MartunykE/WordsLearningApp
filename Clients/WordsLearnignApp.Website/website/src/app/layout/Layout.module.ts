import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../app-routing.module';
import { MaterialModule } from '../Modules/Material.module';
import { AccountService } from '../Services/account.service';
import { LayoutComponent } from './layout.component';
import { LayoutMenuComponent } from './layoutMenu/layoutMenu.component';


@NgModule({
    imports:[
        MaterialModule,
        CommonModule,
        AppRoutingModule
    ],
    declarations:[
        LayoutComponent,
        LayoutMenuComponent
    ],
    providers:[
        AccountService
    ],
    exports:[
        LayoutComponent
    ]
})
export class LayoutModule{}