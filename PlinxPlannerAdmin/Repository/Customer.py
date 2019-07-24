
import requests
import settings


class Customer():
    def __init__(self, id):
        json_text = requests.get(settings.api_endpoint + "customer/" + id).json()
        self.firstname = json_text["firstName"]
        self.surname = json_text["surname"]
        try:
            self.organsiationName = json_text["organsiationName"] or ""
            self.isOrganisation = json_text["isOrgansiation"] or ""        
        except Exception as e:
            print(str(e))
    
    def getFirstName(self):
        return self.firstname

    def getSurname(self):
        return self.surname
    
    def getOrgansiationName(self):
        return self.organsiationName

    def getIsOrganisation(self):
        return self.isOrganisation == "true"

class Customer_list():
    def __init__(self):
        self.json_text = requests.get(settings.api_endpoint + "customer").json()      
    
    def getCustomerList(self):
        return self.json_text
    
