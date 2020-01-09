export interface IScheduledPickup {

  id: number;
  emailId: string
 pickupPinCode: number;
 deliveryPinCode:number
 shipmentType:string
 packageLen:number
 packageBreadth:number
 packageHeight:number
 packageWeight:number
packingReq:number
 deliveryOpt: string
 timeSlot:string
 pickupAddress: string
 deliveryAddress: string
insurance: number
 amount: number
 payment: string
  awbNumber: number
  name: string
}
