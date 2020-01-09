import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-branch-home',
  templateUrl: './branch-home.component.html',
  styleUrls: ['./branch-home.component.css']
})
export class BranchHomeComponent implements OnInit {
  customerLayout: boolean = false;
  commonLayout: boolean = false;
  emailId: string;
  constructor() {

    this.emailId = sessionStorage.getItem('userEmailId');
    if (this.emailId != undefined) {
      this.customerLayout = true;
    }
    else {
      this.commonLayout = true;
    }

  }

  ngOnInit() {
  }

}
