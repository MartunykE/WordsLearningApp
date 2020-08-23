import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AccountService {

    constructor(private httpClient: HttpClient) {

    }
    private userSubject: BehaviorSubject<User>;

    register(user: User) {
        //test user
        // let user = new User();
        user.Username = 'myUserName';
        user.Password = 'password';


        return this.httpClient.post(`${environment.usersUrl}/Register`, user).subscribe();
    }

    login(username:string , password:string) {
        console.log(username);
        //http post then localstorage set item user , then user next
        return this.httpClient.post<User>(`${environment.usersUrl}/Authenticate`, { username, password })
            .pipe(map(user => {
                localStorage.setItem('user', JSON.stringify(user));
                // this.userSubject.next(user);
                return user;
            }));
    }

    logout() {

    }
}