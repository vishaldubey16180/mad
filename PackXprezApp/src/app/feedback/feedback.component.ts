import { Component, OnInit } from '@angular/core';
import { userservice } from '../services/userservice.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  status: boolean = false;
  emailId: string = "madhuras21@yahoo.com";
  errMsg: string;
  msgDiv1: boolean = false;
  msgDiv2: boolean = false;
  constructor(private _ps: userservice) { }

  ngOnInit() {
  }

  addFeedback(form: NgForm) {
    console.log(this.emailId);
    console.log(form.value.feedbacktype);
    console.log(form.value.comments);
    this._ps.addFeedback(this.emailId, form.value.feedbacktype, form.value.comments).subscribe(
      x => {
      this.status = x;
        if (this.status == true) {
          this.msgDiv1 = true;
        }
        else {
          this.msgDiv2 = true;
        }
      },
      y => {
        this.errMsg = y;
        console.log(this.errMsg);
      },
      () => console.log("Feedback added successfully")

    )
  }

}
