import requests

API_ENDPOINT = "http://localhost:5200/api/v1/"

class Customer:
    def __init__(self, customerId):
        json_text = requests.get('http://localhost:5200/api/v1/Customer/' + customerId).json()
        self.firstname = json_text["firstName"]
        self.surname = json_text["surname"]
        self.organsiationName = json_text["companyName"] or ""
        
    def getFirstName(self):
        return self.firstname

    def getSurname(self):
        return self.surname
    
    def getOrgansiationName(self):
        return self.organsiationName


class Content:
    def __init__(self):
        json_text = requests.get('http://localhost:5200/api/v1/Content/1').json()
        self.intro_title = json_text["introTitle"] or ""
        self.intro_text = json_text["introText"] or ""
        self.about_section = json_text["aboutSection"] or ""
        self.default_skills = json_text["defaultSkills"] or []
        self.default_comments = json_text["defaultComments"] or []
        self.default_portfolio = json_text["defaultPortfolio"] or []
        self.default_experiance = json_text["defaultExperiance"] or []
        self.footer = json_text["footer"] or []
        
    def get_intro_title(self):
        return self.intro_title

    def get_intro_text(self):
        return self.intro_text
    
    def get_about_section(self):
        return self.about_section
        
    def get_default_skills(self):
        return self.default_skills
    
    def get_default_comments(self):
        return self.default_comments

    def get_default_portfolio(self):
        return self.default_portfolio
    
    def get_default_experiance(self):
        return self.default_experiance
            
    def get_footer(self):
        return self.footer
