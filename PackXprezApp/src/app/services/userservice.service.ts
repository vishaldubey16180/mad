import { Injectable } from '@angular/core';
import { IAvailability } from '../packXprez-interfaces/availability';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IFeedback } from '../packXprez-interfaces/feedback';
import { ICustomer } from '../packXprez-interfaces/customer';
import { IBranchOfficer } from '../packXprez-interfaces/branchofficer';
import { IScheduledPickup } from '../packXprez-interfaces/ScheduledPickup';
import { IReceivePackage } from '../packXprez-interfaces/ReceivePackage';
@Injectable({
  providedIn: 'root'
})
export class userservice {

  availabilities: IAvailability[];
  constructor(private http: HttpClient) { }


  getAvailability(pincode: number): Observable<boolean> {
    let parameter1 = "?pincode=" + pincode;
    // let parameter2 = "&pincodeDelivery=" + pincodeDelivery;
    let tempVar = this.http.get<boolean>('https://localhost:44352/api/PackXprez/ServiceAvailability' + parameter1);
    console.log(tempVar);
    return tempVar;
  }

  validateCustomerLogin(emailId: string, password: string): Observable<boolean> {
    let parameter1 = "?emailId=" + emailId;
    let parameter2 = "&password=" + password;
    let tempvar2 = this.http.get<boolean>('https://localhost:44352/api/PackXprez/CustomerLogin' + parameter1 + parameter2);
    return tempvar2;
  }

  addFeedback(emailId: string, feedbackType: string, comments: string): Observable<boolean> {
    var obj1: IFeedback;
    obj1 = { EmailId: emailId, FeedbackType: feedbackType, comments: comments };
    return this.http.post<boolean>('https://localhost:44352/api/PackXprez/AddFeedback', obj1);

  }
  registerUser(name: string, emailId: string, userPassword: string, userNumber: number, buildingNo: string, streetNo: string, pincode: number, locality: string): Observable<boolean> {
    var custObj: ICustomer;
    custObj = { CustName: name, CustEmailId: emailId, Password: userPassword, ContactNo: userNumber, BuildingNo: buildingNo, StreetNo: streetNo, PinCode: pincode, Locality: locality }
    return this.http.post<boolean>('https://localhost:44352/api/PackXprez/AddCustomer', custObj);

  }

  validateBranchOfficerLogin(emailId: string, password: string): Observable<IBranchOfficer> {
    let parameter1 = "?emailId=" + emailId;
    let parameter2 = "&password=" + password;
    let tempvar2 = this.http.get<IBranchOfficer>('https://localhost:44352/api/PackXprez/BranchOfficerLogin' + parameter1 + parameter2);
    return tempvar2;
  }

  getSchedulingDetails(city: string): Observable<IScheduledPickup[]> {
    let param1 = "?city=" + city;
    let tempvar2 = this.http.get<IScheduledPickup[]>('https://localhost:44352/api/PackXprez/GetPackageDetailsByLocation' + param1);
    return tempvar2;
  }

  validateReceivePackage(name: string, city: string, deliveryAddress: string): Observable<boolean> {
    //let parameter1 = "?name=" + name;
    //let parameter2 = "&emailId=" + emailId;
    //let parameter3 = "&city=" + city;
    //let parameter4 = "&deliveryAddress=" + deliveryAddress;
    let stat1 ="PickUp"
    var obj1: IReceivePackage;
    

    obj1 = { awbNumber: 0, customerName: name, fromLocation: city, toAddress: deliveryAddress, updatedStatus: stat1 };
    //console.log(obj1);
    return this.http.post<boolean>('https://localhost:44352/api/PackXprez/AddReceivePackage',obj1 );
    
  }

  updateScheduledPickup(emailId: string): Observable<boolean> {
    let parameter1 = "?EmailId=" + emailId;
    return this.http.put<boolean>('https://localhost:44352/api/PackXprez/UpdateScheduledPickup' + parameter1,null);
  }

  updateOrders(emailId: string): Observable<boolean> {
    let parameter1 = "?EmailId=" + emailId;
    return this.http.put<boolean>('https://localhost:44352/api/PackXprez/UpdateOrders' + parameter1, null); 
  }

  updateOrders2(emailId: string): Observable<boolean> {
    let parameter1 = "?EmailId=" + emailId;
    return this.http.put<boolean>('https://localhost:44352/api/PackXprez/UpdateOrders2' + parameter1, null);
  }
}
