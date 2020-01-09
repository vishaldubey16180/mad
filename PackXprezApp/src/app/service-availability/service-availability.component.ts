import { Component, OnInit } from '@angular/core';
import { IAvailability } from '../packXprez-interfaces/availability';
import { userservice } from '../services/userservice.service';
import { NgForm } from '@angular/forms';
//import { userservice } from '../services/userservice';

@Component({
  selector: 'app-service-availability',
  templateUrl: './service-availability.component.html',
  styleUrls: ['./service-availability.component.css']
})
export class ServiceAvailabilityComponent implements OnInit {

  availabilities: IAvailability[];
  status: boolean;
  //pincodePickup: number = 411002;
 // pincodeDelivery: number = 411002;
  errMsg: string;
  showMsgDiv1: boolean = false;
  showMsgDiv2: boolean = false;
  constructor(private _ps: userservice) { }

  ngOnInit() {
   // this.getAvailability();
  }

  getAvailability(form: NgForm) {
    
    console.log(form.value.pincode);
    //console.log(form.value.dpincode);
    this._ps.getAvailability(form.value.pincode).subscribe(
      x => {
        this.status = x;
        if (this.status == true) {
          this.showMsgDiv1 = true;
          //this.ngOnInit();
        }
        else {
          this.showMsgDiv2 = true;
        }
        console.log(this.status);
      },
      y => {
        this.errMsg = y;
        this.status = false;
      },
      () => console.log("Method implemented successfully!")
   
    )

  }

}
