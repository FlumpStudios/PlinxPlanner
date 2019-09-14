import tkinter as tk
import FileManger
from tkinter.ttk import *
from Repository import Customer
import webbrowser
import settings

class MainScreen:
    def __init__(self, master):        
        self.master = master
        self.frame = tk.Frame(self.master)        
        self.master.title("Admin")        
        self.frame.pack() 
        self.draw_table(master)
        self.draw_menu()   

    def draw_menu(self):
        menu = tk.Menu(self.master)        
        menu = tk.Menu(self.master) 
        self.master.config(menu=menu)
        file = tk.Menu(menu)
        file.add_command(label="Create new order", command=self.load_orderform)     
        file.add_command(label="Refresh", command=self.clear_table)
        file.add_command(label="Exit", command=self.client_exit)        
        menu.add_cascade(label="File", menu=file)        
     
    def load_orderform(self):
        webbrowser.open(settings.orderform_url)


    def populate_table(self):        
        for x in Customer.Customer().getList():
             self.tree.insert('', 'end', text=(x["customerId"]), values=(x["companyName"],x["firstName"] + " " + x["surname"], x["sitedetails"]["templateId"], x["firstContactDate"],x["sitedetails"]["superUserCreated"], x["sitedetails"]["siteStatus"]["name"]))


                
    def clear_table(self):
        print("Refreshing Results")
        self.tree.delete(*self.tree.get_children())
        self.populate_table()

    def draw_table(self, master):
        self.tree=Treeview(master)

        self.tree["columns"]=("Company","Name","Template","Submitted Data","Super User Created", "Status")
        print(self.tree["columns"])
        self.tree.column("#0", width=200, minwidth=150, stretch=tk.NO)
        self.tree.heading("#0",text="Customer ID",anchor=tk.W)
        
        for col in self.tree["columns"]:
            self.tree.column(col, width=200, minwidth=150, stretch=tk.NO)        
            self.tree.heading(col, text=col,anchor=tk.W)        
       
        self.populate_table()

        self.tree.bind("<Double-1>", self.on_double_click)
        self.tree.pack()
    
    def on_double_click(self, event):
        MainScreen.draw_menu(self)        
        item = self.tree.selection()[0]
        vals = self.tree.item(item,"values")
        text = self.tree.item(item,"text")        
        self.newWindow = tk.Toplevel(self.master)
        self.app = Popup(self.newWindow, values=vals, clientId=text, parent=self)
         
    def client_exit(self):
        exit()


class Popup:
    def __init__(self, master, values, clientId, parent):
        self.values = values
        self.clientId = clientId
        print(self.values)
        self.master = master
        self.frame = tk.Frame(self.master)          
            

        #Get current client from API
        self.currentCust = Customer.Customer().get(id=clientId)            

        #Create labels
        Label(self.master, text="Personal Details",font='Helvetica 10 bold').grid(row=0,sticky=tk.W)               
        Label(self.master, text="First Name").grid(row=1,sticky=tk.W)
        Label(self.master, text="Second Name").grid(row=2,sticky=tk.W)
        Label(self.master, text="Company").grid(row=3,sticky=tk.W)        
        Label(self.master, text="Address",font='Helvetica 10 bold').grid(row=4,sticky=tk.W)                       
        Label(self.master, text="Property Number").grid(row=5,sticky=tk.W)
        Label(self.master, text="Property Name").grid(row=6,sticky=tk.W)
        Label(self.master, text="Line 1").grid(row=7,sticky=tk.W)
        Label(self.master, text="Line 2").grid(row=8,sticky=tk.W)
        Label(self.master, text="Town").grid(row=9,sticky=tk.W)
        Label(self.master, text="County").grid(row=10,sticky=tk.W)
        Label(self.master, text="Post code").grid(row=11,sticky=tk.W)

        Label(self.master, text="Contact Details",font='Helvetica 10 bold').grid(row=12,sticky=tk.W)               
        Label(self.master, text="Phone Number").grid(row=13,sticky=tk.W)
        Label(self.master, text="Mobile Number").grid(row=14,sticky=tk.W)
        Label(self.master, text="Email Address").grid(row=15,sticky=tk.W)
        Label(self.master, text="Site Details",font='Helvetica 10 bold').grid(row=16,sticky=tk.W)               
        Label(self.master, text="Template").grid(row=17,sticky=tk.W)
        Label(self.master, text="Site status").grid(row=18,sticky=tk.W)        
        Label(self.master, text=self.currentCust["sitedetails"]["siteStatus"]["name"] or "-").grid(row=18, column=1,sticky=tk.W)
        
        #Create the inputs
        fname = Entry(master)
        sname = Entry(master)
        companyDetails = Entry(master)        
        property_number = Entry(master)
        property_name= Entry(master)
        line1= Entry(master)
        line1= Entry(master)
        line2= Entry(master)
        town= Entry(master)
        county= Entry(master)
        postcode= Entry(master)
        phone= Entry(master)
        mobile= Entry(master)        
        email= Entry(master)
        template= Entry(master)        
             
        #Insert the data from the API
        fname.insert(0, self.currentCust["firstName"]or "-")
        sname.insert(0, self.currentCust["surname"]or "-")
        companyDetails.insert(0, self.currentCust["companyName"]or "-")
        property_number.insert(0, self.currentCust["customerAddress"]["propertyNumber"]or "-")
        property_name.insert(0, self.currentCust["customerAddress"]["propertyName"]  or "-")
        line1.insert(0, self.currentCust["customerAddress"]["addressLine1"]or "-")   
        line2.insert(0, self.currentCust["customerAddress"]["addressLine2"] or "-")        
        town.insert(0, self.currentCust["customerAddress"]["town"] or "-")                
        county.insert(0, self.currentCust["customerAddress"]["county"]or "-") 
        postcode.insert(0, self.currentCust["customerAddress"]["postcode"]or "-")         
        phone.insert(0, self.currentCust["customerAddress"]["phoneNumber"]or "-") 
        mobile.insert(0, self.currentCust["customerAddress"]["mobileNumber"]or "-") 
        email.insert(0, self.currentCust["customerAddress"]["emailAddress"]or "-")         
        template.insert(0,self.currentCust["sitedetails"]["templateId"]or "-") 

        #Draw the inputs on the grid
        fname.grid(row=1, column=1)
        sname.grid(row=2, column=1)
        companyDetails.grid(row=3, column=1)       
        property_number.grid(row=5, column=1)  
        property_name.grid(row=6, column=1)   
        line1.grid(row=7, column=1)   
        line2.grid(row=8, column=1)
        town.grid(row=9, column=1)
        county.grid(row=10, column=1)
        postcode.grid(row=11, column=1)        
        phone.grid(row=13, column=1)
        mobile.grid(row=14, column=1)
        email.grid(row=15, column=1)
        template.grid(row=17, column=1)        
        
        
        #######################
        ## CLIENT CALL BACKS ## 
        #######################
        company = self.values[0]
        selectedTemplate = self.values[2]                

        def create_site_callback():
            try:
                FileManger.copyTemplateToOutPut(selectedTemplate, company, self.clientId) 
            except:
                print("Error creating site!!!")
                return
            self.currentCust["sitedetails"]["sitesStatusId"] = "2"
            Customer.Customer().update(self.clientId,self.currentCust)
            parent.clear_table()
            self.close_windows()

        def run_server():
            try:
                FileManger.runServer(company, self.clientId)
            except:
                print("Something went wrong. Could not lanch server :(")

        def create_super_user():
            self.close_windows()
            try:
                FileManger.createSuperUSer(company, self.clientId) 
            except Exception as e:
                print ("Could not run super user command" + str(e))
                return
            self.currentCust["sitedetails"]["superUserCreated"] = "true"
            Customer.Customer().update(self.clientId,self.currentCust)

            parent.clear_table()
            self.close_windows()


        def ftp():
            self.close_windows()
            try:
                FileManger.ftp(company, self.clientId) 
            except Exception as e:
                print ("Could not FTP to server" + str(e))
                return

            self.currentCust["sitedetails"]["sitesStatusId"] = "3"
            Customer.Customer().update(self.clientId,self.currentCust)
            parent.clear_table()
        
        def set_live():
            self.currentCust["sitedetails"]["sitesStatusId"] = "4"
            Customer.Customer().update(self.clientId,self.currentCust)
            parent.clear_table()
            self.close_windows()

        def update_details():

            print(fname.get())
            #Set user dict to input boxes data
            self.currentCust["firstName"] = fname.get()
            self.currentCust["surname"] = sname.get()
            self.currentCust["companyName"] = companyDetails.get()
            self.currentCust["customerAddress"]["propertyNumber"] = property_number.get()
            self.currentCust["customerAddress"]["propertyName"] = property_name.get()
            self.currentCust["customerAddress"]["addressLine1"] = line1.get()
            self.currentCust["customerAddress"]["addressLine2"] = line2.get()
            self.currentCust["customerAddress"]["town"] = town.get()
            self.currentCust["customerAddress"]["county"] = county.get()  
            self.currentCust["customerAddress"]["postcode"] = postcode.get()
            self.currentCust["customerAddress"]["phoneNumber"] = phone.get()
            self.currentCust["customerAddress"]["mobileNumber"] = mobile.get()
            self.currentCust["customerAddress"]["emailAddress"] = email.get()
            self.currentCust["sitedetails"]["templateId"] = template.get()

            Customer.Customer().update(self.clientId,self.currentCust)
            parent.clear_table()
            self.close_windows()

            
        status = self.values[5]
        super_user_exists = self.values[4]        

        update_button = tk.Button(master, text="Update details",  command = update_details).grid(row=20,columnspan=2,sticky='nesw')     

        if (status == "Pending"):
            create_site_button = tk.Button(master, text="Create Site",  command = create_site_callback).grid(row=20,columnspan=2,sticky='nesw')
     
        
        #if site available launch site
        if (status != "Pending" and status != "Cancelled" and  status != "Deleted"):
            print(self.values)
            run_server_button = tk.Button(master, text="Run Server",  command = run_server).grid(row=21,columnspan=2,sticky='nesw')
          

        if (status == "Created"):             
            if (super_user_exists.upper() == "TRUE"):
                create_another_super_user_button = tk.Button(master, text="Create another Super user",  command = create_super_user).grid(row=22,columnspan=2,sticky='nesw')
                
                #Only allow FTP to site if site created and super user created
                create_site_button = tk.Button(master, text="Upload to server",  command = ftp).grid(row=25, columnspan=2,sticky='nesw')               

            else:
                create_super_user_button = tk.Button(master, text="Create Super user",  command = create_super_user).grid(row=26, columnspan=2,sticky='nesw')
                
       
        if(status == "Staging"):
            set_live_button = tk.Button(master, text="Set site to live",  command = set_live).grid(row=27,columnspan=2,sticky='nesw')
          

        
    def close_windows(self):
        self.master.destroy()


def main(): 
    root = tk.Tk()
    #root.geometry("1280x720")
    
    app = MainScreen(root) 
    root.mainloop()


if __name__ == '__main__':
    main()