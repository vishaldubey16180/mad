import { Component, OnInit } from '@angular/core';
import { userservice } from '../services/userservice.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { IBranchOfficer } from '../packXprez-interfaces/branchofficer';
@Component({
  selector: 'app-branch-login',
  templateUrl: './branch-login.component.html',
  styleUrls: ['./branch-login.component.css']
})
export class BranchLoginComponent implements OnInit {

  msg: string;
  status: boolean = false;
  showMsgDiv1: boolean = false;
  showMsgDiv2: boolean = false;
  showDiv: boolean = false;
  officer: IBranchOfficer;
  errMsg: string;
  constructor(private _ps: userservice,private router: Router) { }

  ngOnInit() {
   
  }



  BranchOfficerLogin(loginForm: NgForm) {
    console.log(loginForm.value.emailId);
    console.log(loginForm.value.userPassword);
    this._ps.validateBranchOfficerLogin(loginForm.value.emailId, loginForm.value.userPassword).subscribe(
      x => {
        this.officer = x;
        console.log(this.officer);
        //console.log(this.officer.password);
        this.showDiv = true;
        if (this.officer!=null) {
          sessionStorage.setItem("userEmailId", loginForm.value.emailId);
          sessionStorage.setItem("Location", this.officer.location);
          sessionStorage.setItem("Name", this.officer.boname);
          this.router.navigate(['/branch-home']);
          alert('Login successful!')
        }
        else {
          this.msg = "invalid credentials";
          alert('Login not successful.Try Again!');
        }
      },
      error => {
        this.errMsg = error;
      },
      () => console.log("Branch Officer Login method executed successfully")
    );
  }


}
