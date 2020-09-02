import { Component } from '@angular/core';
import { WordsService } from 'src/app/Services/words.service';
import { Word } from 'src/app/Models/Word';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';
import { CommonModule } from '@angular/common';


@Component({
    selector: 'words',
    templateUrl: './words.component.html',
    styleUrls: ['./words.component.css']
})
export class WordsComponent {

    createEnabled = false;
    editEnabled = false;
    wordInEditing = new Word();
    user: User;
    words: Array<Word>;
    displayColumns = ['name', 'learningLevel','actions'];
    constructor(private wordsService: WordsService, private accountService: AccountService) { }

    ngOnInit(){
        this.accountService.currentUser.subscribe(currentUser => this.user = currentUser);
        this.getAllWords();
    }


    getWord(id: number) {
        this.wordsService.getWord(1).subscribe(w => console.log(w.name));

    }

    createWord(wordName: string) {
        let word = new Word();
        word.name = wordName;
        word.userChatId = this.user.chatId;
        this.wordsService.createWord(word);
        this.createEnabled = false;
    }

    getAllWords(){
        this.wordsService.getAllWords().subscribe(words=> this.words = words);
        
    }
    
    editWord(word: Word){
        this.wordInEditing = word;
        this.editEnabled = true;
    }

    onChangedWord(word: Word){
        this.editEnabled = false;
        this.wordInEditing = null;
        this.words.forEach(element => {
            console.log(element.name);
        });

        this.wordsService.updateWord(word);
    }

   
}