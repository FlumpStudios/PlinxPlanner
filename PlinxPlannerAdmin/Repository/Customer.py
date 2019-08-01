
import requests
import settings
import json

class Customer():
    def getList(self):
        return requests.get(settings.api_endpoint + "customer/").json()
    
    def get(self,id):
        return requests.get(settings.api_endpoint + "customer/" + str(id)).json()
    
    def post(self,customer):
        return

    def update(self,id,cust):
        print ("Updating customer status...")
        
        print(json.dumps(cust))
        result = requests.put(settings.api_endpoint + "customer/" + str(id),headers={'Content-type':'application/json', 'Accept':'application/json'},  data=json.dumps(cust))
        print(result)

        

