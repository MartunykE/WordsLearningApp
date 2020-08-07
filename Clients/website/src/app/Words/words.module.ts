import { NgModule } from '@angular/core';
import {UserWordsComponent} from './UserWords.component';
import { MaterialModule} from '../Modules/Material.module';

@NgModule({
    declarations: [      
      UserWordsComponent
    ],
    imports: [            
      MaterialModule
    ],
    exports:[
      MaterialModule
    ],
    providers: [],
  })
  export class WordsModule { }
  