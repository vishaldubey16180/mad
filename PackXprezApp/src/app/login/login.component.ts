import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { userservice } from '../services/userservice.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  msg: string;
  status: boolean = false;
  showMsgDiv1: boolean = false;
  showMsgDiv2: boolean = false;
  showDiv: boolean = false;
  errMsg: string;
  constructor(private _ps: userservice) { }

  ngOnInit() {
    console.log("jhgjhkj");
  }

 

  CustomerLogin(loginForm: NgForm) {
    console.log(loginForm.value.emailId);
    console.log(loginForm.value.userPassword);
    this._ps.validateCustomerLogin(loginForm.value.emailId, loginForm.value.userPassword).subscribe(
      x => {
        this.status = x;
        console.log(this.status);
        this.showDiv = true;
        if (this.status) {
          sessionStorage.setItem("userEmailId", loginForm.value.emailId);
          //this.router.navigate(['/home']);
        }
        else {
          this.msg = "invalid credentials";
        }
      },
      error => {
        this.errMsg = error;
      },
      () => console.log("CustomerLogin method executed successfully")
    );
  }

}
