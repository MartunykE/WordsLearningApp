import { Component, EventEmitter, Output, Input, OnInit } from "@angular/core";


@Component({
    selector: "user-words",
    templateUrl: "./UserWords.component.html",
    styleUrls: ["./UserWords.component.css"],
})
export class UserWordsComponent {

    intervalObject: any;
    currentVal: number = 0;

    @Input()
    interval : number = 1000;
    
    @Output()
    tick:EventEmitter<number> = new EventEmitter<number>();


    start(){
        this.intervalObject = setInterval(()=>{this.callback()},this.interval);
    }

    private callback(){
        this.currentVal++;
        this.tick.emit(this.currentVal);
    }
}