import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AccountService {
    
    private currentUser: BehaviorSubject<User>;

    constructor(private httpClient: HttpClient) {

    }

    public get currentUserValue(): User{
        return this.currentUser.value;
    }

    register(user: User) {       
        
        console.log(user.Username);
        console.log(user.Password); 

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
    }
}