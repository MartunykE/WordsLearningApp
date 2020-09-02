import { NgModule } from '@angular/core';
import { MaterialModule } from 'src/app/Modules/Material.module';
import { CommonModule } from '@angular/common';
import { WordsComponent } from './words.component';
import { AccountService } from 'src/app/Services/account.service';
import { WordsService } from 'src/app/Services/words.service';
import { WordsEditComponent } from './WordsEdit/wordsEdit.component';



@NgModule({
    imports:[
        MaterialModule,
        CommonModule
    ],
    providers:[
        AccountService,
        WordsService
    ],
    declarations:[
        WordsComponent,
        WordsEditComponent
    ]
})
export class WordsModule{}