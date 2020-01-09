import { Component, OnInit } from '@angular/core';
import { userservice } from '../services/userservice.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  custname: string;
  custEmailId: string;
  password: string;
  confirmPassword: string;
  buildingNo: string;
  contactNo: number;
  streetNo: string;
  pincode: number
  msgDiv: boolean
  msg: string
  status:boolean
  errorAddMsg: string;

  constructor(private _userservice: userservice) { }

  ngOnInit() {
  }
  addregister(form: NgForm) {

    console.log(form.value.userPassword);
    console.log(form.value.userNumber);
    if (form.value.userPassword != form.value.confirmuserPassword) {
      this.msg = "please entr the same password"
    }
    else {
      this._userservice.registerUser(form.value.name, form.value.emailId, form.value.userPassword,  form.value.userNumber, form.value.buildingNo, form.value.streetNo, form.value.pincode,form.value.locality)
        .subscribe(
          responseProductData => {
            console.log("Added registration111")
            console.log(responseProductData)
            if (responseProductData) {
              this.status = responseProductData;
              this.msg = "Registration done sucessfully."
              this.msgDiv = true;
              alert("register added sucessfully.")
            }
            console.log("Added registration1331")
          },
          responseProductError => {
            this.errorAddMsg = responseProductError,
              this.msg = "some error occured";
            console.log(this.errorAddMsg),
              alert("Sorry, something went wrong. Please try again after sometime.")
          },
          () => console.log("Added registration")
        );
    }
  }

}
