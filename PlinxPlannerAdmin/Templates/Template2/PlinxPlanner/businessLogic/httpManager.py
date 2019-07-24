import requests

API_ENDPOINT = "http://localhost:5200/api/v1/"

class Customer():
    def __init__(self):
        json_text = requests.get('http://localhost:5200/api/v1/Customer/1').json()
        self.firstname = json_text["firstName"]
        self.surname = json_text["surname"]
        self.organsiationName = json_text["organsiationName"] or ""
        self.isOrganisation = json_text["isOrgansiation"] or ""        
    
    def getFirstName(self):
        return self.firstname

    def getSurname(self):
        return self.surname
    
    def getOrgansiationName(self):
        return self.organsiationName

    def getIsOrganisation(self):
        return self.isOrganisation == "true"
    
