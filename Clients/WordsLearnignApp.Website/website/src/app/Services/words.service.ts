import { Injectable } from '@angular/core';
 import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { Word } from '../Models/Word';
import { env } from 'process';


 @Injectable()
 export class WordsService{
    
     constructor(private httpClient:HttpClient ){}
    
     getAllWords(){
        return this.httpClient.get<Array<Word>>(environment.wordsUrl);
     }

     getWord(id:number){
         return this.httpClient.get<Word>(`${environment.wordsUrl}/${id}`);
     }

     createWord(word: Word){
         return this.httpClient.post(`${environment.wordsUrl}`, word).subscribe();
     }

     updateWord(word:Word){
         return this.httpClient.put(`${environment.wordsUrl}/${word.id}`, word).subscribe();
     }

 }