import {Injectable} from '@angular/core';
import {env} from "../../../envs/env";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ILoginResult} from "../interfaces/ilogin-result";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {
  }


  login(username: string, password: string, signature: string): Observable<ILoginResult> {
    let result = this.http.post<ILoginResult>(env.apiRoot + "/Auth/Login", {
      "username": username,
      "password": password,
      "signature": signature
    });
    return result;
  }
}
