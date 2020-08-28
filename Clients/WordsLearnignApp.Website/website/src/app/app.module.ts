import '../polyfills';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import '@angular/compiler';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule} from './Modules/Material.module';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { AccountModule } from './AccountModule/Account.Module';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { AuthGuard } from './Helpers/AuthGuard';
import { LayoutComponent } from './layout/layout.component';
import { UserModule } from './UserModule/User.module';



@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    AccountModule,
    UserModule
    
  ],
  exports:[    
  ],
  providers: [
    AuthGuard
    // { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'standart' } },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }

