import { Component, OnInit } from '@angular/core';
import { IScheduledPickup } from '../packXprez-interfaces/ScheduledPickup';
import { userservice } from '../services/userservice.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-branch-receive-package',
  templateUrl: './branch-receive-package.component.html',
  styleUrls: ['./branch-receive-package.component.css']
})
export class BranchReceivePackageComponent implements OnInit {

  errMsg: string;
  scheduledPickup: IScheduledPickup[];
  scheduledPickup1: IScheduledPickup[];
  city: string;
  name: string;
  status1: boolean = false;
  status2: boolean = false;
  status3: boolean = false;
  status4: boolean = false;
 errMsg1: string;
  constructor(private _ps: userservice) { }

  ngOnInit() {
    this.city = sessionStorage.getItem('Location');
    //this.name = this.aroute.snapshot.params('')
    
    console.log(this.city);
    this.getDetails();
  }
  
  getDetails() {
    this._ps.getSchedulingDetails(this.city).subscribe(
      x => {
        console.log("ajdaks");
        this.scheduledPickup = x;
        console.log(this.scheduledPickup);
      },
      y => {
        this.errMsg = y;
        console.log(this.errMsg);
      },
      ()=> console.log("Method executed successfully")
    )
  }

  pickup(name:string, emailId: string, city: string, deliveryAddress: string) {
    console.log("Into pickup");
   this.insertintoReceivePackage(name, city, deliveryAddress);
    this.updateScheduledPickup(emailId);
    this.updateOrders(emailId); 
  }


  insertintoReceivePackage(name:string,city:string,deliveryAddress:string) {
   // console.log(name);
    console.log("Into receive package");
    console.log(name);
    //console.log(emailId);
    console.log(city);
    console.log(deliveryAddress);
    this._ps.validateReceivePackage(name, city, deliveryAddress).subscribe(
      x => {
        this.status1 = x;
      },
      y => {
        this.errMsg = y;
        console.log(this.errMsg);
      },
      ()=> console.log("Insert into package method executed successfully")
    )

  }

  updateScheduledPickup(emailId: string) {
    this._ps.updateScheduledPickup(emailId).subscribe(
      x => {
      this.status2 = x
        console.log(this.status2);
      },
      y => {
        this.errMsg1 = y;
      },
      ()=> console.log("update scheduled pickup method executed successfully")
    )

  }

  updateOrders(emailId: string) {
    this._ps.updateOrders(emailId).subscribe(
      x => {
        this.status3 = false;
        console.log(this.status3);
      },
      y => {
        this.errMsg1 = y;
      },
      () => console.log("update orders method")
    )
  }

  delivered(name: string, emailId: string, city: string, deliveryAddress: string) {
    this.updateOrders2(emailId);
  }


  updateOrders2(emailId: string) {
    this._ps.updateOrders2(emailId).subscribe(
      x => {
        this.status4 = false;
        console.log(this.status4);
      },
      y => {
        this.errMsg1 = y;
      },
      () => console.log("update orders method")
    )
  }
}
