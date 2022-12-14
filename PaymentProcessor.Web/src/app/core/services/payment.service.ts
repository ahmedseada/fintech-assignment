import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {env} from "../../../envs/env";
import {UtilsService} from "./utils.service";
import {IPaymentResult} from "../interfaces/ipayment-result";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient, private utils: UtilsService) {
  }

  addPayment(code: number, trace: number, funcCode: number, cardNo: string, cardHolder: string, amount: number, currency: number) : Observable<IPaymentResult> {

    return this.http.post<IPaymentResult>(env.apiRoot + "/Payment/GetPayment", {
      "processingCode": code,
      "systemTraceNr": trace,
      "functionCode": funcCode,
      "cardNo": cardNo,
      "cardHolder": cardHolder,
      "amountTrxn": amount,
      "currencyCode": currency,
      "signature": this.utils.calcPaymentSignature(cardHolder, cardNo, amount)
    });
  }
}
