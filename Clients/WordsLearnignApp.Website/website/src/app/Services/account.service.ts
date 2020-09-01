import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AccountService {
    
    public currentUser: BehaviorSubject<User>;

    constructor(private httpClient: HttpClient) {
        this.currentUser = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
    }

    // public get currentUserValue(): User{
    //     return this.currentUser.value;
    // }

    register(user: User) {       
        
        return this.httpClient.post(`${environment.usersUrl}/Register`, user);
    }

    login(username:string , password:string) {
        console.log(username);
        return this.httpClient.post<User>(`${environment.usersUrl}/Authenticate`, { username, password })
            .pipe(map(user => {

                localStorage.setItem('user', JSON.stringify(user));
                this.currentUser.next(user);
                return user;
            }));
    }

    logout() {
        localStorage.removeItem('user');
        this.currentUser.next(null);
    }

    editAccount(user:User){
        //TODO:EditUser
    }
}