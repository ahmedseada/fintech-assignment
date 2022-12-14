import {Injectable} from '@angular/core';
import {env} from "../../../envs/env";
import * as shajs from "sha.js";

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  constructor() {
  }

  calcLoginSignature(username: string, password: string): string {
    let stringToBeHashed = username + env.hashKey + password;
    return shajs('sha256').update(stringToBeHashed).digest('hex');
  }

  calcPaymentSignature(holderName: string, cardNumber: string, amount: number): string {

    let stringToBeHashed = holderName + cardNumber + amount + env.hashKey;
    return shajs('sha256').update(stringToBeHashed).digest('hex');
  }
}
