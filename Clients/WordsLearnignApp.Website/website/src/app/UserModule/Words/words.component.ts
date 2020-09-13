import { Component } from '@angular/core';
import { WordsService } from 'src/app/Services/words.service';
import { Word } from 'src/app/Models/Word';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/User';
import { PageEvent } from '@angular/material/paginator';


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
    displayColumns = ['name', 'learningLevel', 'actions'];
    displayedWords: Array<Word>;
    pageSize = 5;
    currentPageIndex = 0;

    constructor(private wordsService: WordsService, private accountService: AccountService) { }

    ngOnInit() {
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

    getAllWords() {
        this.wordsService.getAllWords().subscribe(words => {
            this.words = words;
            this.getWordsForPage(this.currentPageIndex);
        });
    }

    getWordsForPage(pageIndex) {
        this.currentPageIndex = pageIndex;
        let start = pageIndex * this.pageSize;
        let end = start + this.pageSize;
        this.displayedWords = this.words.slice(start, end);
    }

    editWord(word: Word) {
        this.wordInEditing = word;
        this.editEnabled = true;
    }

    onChangedWord(word: Word) {
        this.editEnabled = false;
        this.wordInEditing = null;
        this.wordsService.updateWord(word);
    }

    sortWords(compareCondition, equalCondition) {
        this.words.sort((firstWord, secondWord) => {

            if (compareCondition(firstWord, secondWord)) {
                return 1;
            }
            else if (equalCondition(firstWord, secondWord)) {
                return 0;
            }
            else {
                return -1;
            }

        });
        this.getWordsForPage(this.currentPageIndex);
    }

    sortByAsc() {
        this.sortWords(
            ((a: Word, b: Word) => { return a.name > b.name }),
            ((a: Word, b: Word) => { return a.name == b.name })
        );

    }
    sortByDesc() {
        this.sortWords(
            ((a: Word, b: Word) => { return a.name < b.name }),
            ((a: Word, b: Word) => { return a.name == b.name })
        );
    }

}