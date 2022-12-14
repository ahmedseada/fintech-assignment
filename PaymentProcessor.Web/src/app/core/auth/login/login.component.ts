import {Component} from '@angular/core';
import {Form, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {UtilsService} from "../../services/utils.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  userName: FormControl;
  Password: FormControl;
  errors: string = '';

  constructor(private authService: AuthService, private utils: UtilsService, private router: Router, private current: ActivatedRoute) {
    this.userName = new FormControl('', [Validators.required]);
    this.Password = new FormControl('', [Validators.required]);
    this.loginForm = new FormGroup({
      username: this.userName,
      password: this.Password
    });
  }

  LoguserIn() {
    let controls = this.loginForm.controls;
    let username = this.userName.value;
    let password = this.Password.value;
    let signature = this.utils.calcLoginSignature(username, password);
    this.authService.login(username, password, signature).subscribe((res) => {
      this.errors = res.errors;
      if (res.done) {
        localStorage.setItem("logged", "1");
        this.router.navigate(["add"], {relativeTo: this.current});
      }
    });
  }
}
