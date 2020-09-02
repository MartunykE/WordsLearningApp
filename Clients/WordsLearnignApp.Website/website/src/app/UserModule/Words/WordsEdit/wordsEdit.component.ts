import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Word } from 'src/app/Models/Word';



@Component({
    selector: 'edit-word',
    templateUrl: './wordsEdit.component.html',
    styleUrls: ['./wordsEdit.component.css']
})
export class WordsEditComponent {
    @Input() selectedWord: Word = new Word();
    @Output() wordChange = new EventEmitter<Word>();
    constructor() {
    }

    ngOnInit() {

    }

    saveChanges(wordName: string) {
        console.log(wordName);
        this.selectedWord.name = wordName;
        this.wordChange.emit(this.selectedWord);
    }
}