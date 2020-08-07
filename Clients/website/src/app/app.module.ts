import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule} from './Modules/Material.module';
import { WordsModule} from './Words/words.module';

// import {UserWordsComponent} from './Words/UserWords.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    // UserWordsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,

  ],
  exports:[    
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
