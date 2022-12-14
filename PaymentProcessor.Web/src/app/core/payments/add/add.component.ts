import {Component} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {PaymentService} from "../../services/payment.service";

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {

  trxRequest: FormGroup;
  processingCode: FormControl;
  systemTraceNr: FormControl;
  functionCode: FormControl;
  cardNo: FormControl;
  cardHolder: FormControl;
  amountTrxn: FormControl;
  currencyCode: FormControl;

  showSuccess: boolean = false;
  approvalCode: number = 0;

  constructor(private router: Router, private current: ActivatedRoute, private paymentService: PaymentService) {
    let logged = localStorage.getItem('logged');
    if (logged === "1") {
    } else {
      this.router.navigate([''], {relativeTo: this.current});
    }
    this.processingCode = new FormControl('999000', [Validators.required]);
    this.systemTraceNr = new FormControl('36', [Validators.required]);
    this.functionCode = new FormControl('1324', [Validators.required]);
    this.cardNo = new FormControl('4712345601012222', [Validators.required]);
    this.cardHolder = new FormControl('Ahmed Mohamed', [Validators.required]);
    this.amountTrxn = new FormControl('1000', [Validators.required]);
    this.currencyCode = new FormControl('840', [Validators.required]);
    this.trxRequest = new FormGroup({
      processingCode: this.processingCode,
      systemTraceNr: this.systemTraceNr,
      functionCode: this.functionCode,
      cardNo: this.cardNo,
      cardHolder: this.cardHolder,
      amountTrxn: this.amountTrxn,
      currencyCode: this.currencyCode,

    });
  }


  AddPayment() {
    let code = this.processingCode.value;
    let trace = this.systemTraceNr.value;
    let funcCode = this.functionCode.value;
    let cardNo = this.cardNo.value;
    let cardHolder = this.cardHolder.value;
    let amount = this.amountTrxn.value;
    let currency = this.currencyCode.value;
    this.paymentService.addPayment(code, trace, funcCode, cardNo, cardHolder, amount, currency).subscribe((res) => {
      if (res.done) {
        this.showSuccess = true;
        this.trxRequest.reset();
        this.approvalCode = res.approvalCode;
        setTimeout(() => {
          this.showSuccess = false;
          this.approvalCode = 0;

        }, 5000);
      }
    });
  }

}
