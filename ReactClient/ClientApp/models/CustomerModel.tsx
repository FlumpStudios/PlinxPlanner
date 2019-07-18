

class customerModel{
    get customerId():string {return ""; } 
    get deferedSalesStatusId():string {return ""; } 
    get distanceSellingId():string {return ""; } 
    get firstContactDate():string {return ""; } 
    get firstName():string {return ""; } 
    get franchiseId():string {return ""; } 
    get firhasCustomerInitiatedstName():string {return ""; } 
    get isOrgansiation():boolean {return false; } 
    get organsiationName():string {return ""; } 
    get policyStatus():any {return { policyStatus :"" }; } 
    get policyStatusId():string {return ; }
    get retailManagerId():string {return ""; } 
    get salesPersonId():string {return ""; } 
    get salesPerson():any { return { salesPersonName : "" } }
    get sdnId():string {return ""; } 
    get surname():string {return ""; } 
    get title():string {return ""; } 
    get hasCustomerInitiated():boolean {return false; }
    get contactConsent():boolean {return false; }    
    get lastUpdateDate():string { return ""}
    get vehicle():any { return [{   vehicleRegistration : "", 
                                        deliveryDate:"", 
                                        vin:"", vehicleType:""}]}    
    get customerAddress():any { return [{}]}
    
}


export default customerModel;
