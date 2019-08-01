import tkinter as tk
import FileManger
from tkinter.ttk import *
from Repository import Customer

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
        file.add_command(label="Exit", command=self.client_exit)
        file.add_command(label="Refresh", command=self.cb)
        menu.add_cascade(label="File", menu=file)        
     
    def populateTable(self):        
        for x in Customer.Customer().getList():
             self.tree.insert('', 'end', text=(x["customerId"]), values=(x["companyName"],x["firstName"] + " " + x["surname"], x["sitedetails"]["templateId"], x["firstContactDate"],x["sitedetails"]["superUserCreated"], x["sitedetails"]["siteStatus"]["name"]))

    def cb(self):
        print("Refreshing Results")
        self.tree.delete(*self.tree.get_children())
        self.populateTable()

    def draw_table(self, master):
        self.tree=Treeview(master)

        self.tree["columns"]=("Company","Name","Template","Submitted Data","Super User Created", "Status")
        print(self.tree["columns"])
        self.tree.column("#0", width=200, minwidth=150, stretch=tk.NO)
        self.tree.heading("#0",text="Customer ID",anchor=tk.W)
        
        for col in self.tree["columns"]:
            self.tree.column(col, width=200, minwidth=150, stretch=tk.NO)        
            self.tree.heading(col, text=col,anchor=tk.W)        
       
        self.populateTable()

        self.tree.bind("<Double-1>", self.OnDoubleClick)
        self.tree.pack()
    
    def OnDoubleClick(self, event):
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
        self.text = clientId
        print(self.values)
        self.master = master
        self.frame = tk.Frame(self.master)          
            

        #Get current client from API        
        
        self.currentCust = Customer.Customer().get(id=clientId)            
        Label(self.master, text="Personal Details",font='Helvetica 10 bold').grid(row=0,sticky=tk.W)               
        Label(self.master, text="First Name").grid(row=1,sticky=tk.W)
        Label(self.master, text="Second Name").grid(row=2,sticky=tk.W)
        Label(self.master, text="Company").grid(row=3,sticky=tk.W)
        
        Label(self.master, text="Address",font='Helvetica 10 bold').grid(row=4,sticky=tk.W)               
        Label(self.master, text="Phone").grid(row=5,sticky=tk.W)
        Label(self.master, text="Email").grid(row=6,sticky=tk.W)
        Label(self.master, text="POstcode").grid(row=7,sticky=tk.W)



        
        

        e1 = Entry(master)
        e1.insert(0, self.currentCust["firstName"])
        e2 = Entry(master)
        e2.insert(0, self.currentCust["surname"])
        e3= Entry(master)
        e3.insert(0, self.currentCust["companyName"])

        e4= Entry(master)
        e4.insert(0, self.currentCust["customerAddress"]["phoneNumber"])

        e5= Entry(master)
        e5.insert(0, self.currentCust["customerAddress"]["emailAddress"])
        
        e6= Entry(master)
        e6.insert(0, self.currentCust["customerAddress"]["postcode"])        

        e1.grid(row=1, column=1)
        e2.grid(row=2, column=1)
        e3.grid(row=3, column=1)       
        e4.grid(row=5, column=1)  
        e5.grid(row=6, column=1)   
        e6.grid(row=7, column=1)   
        
        id = self.text
        company = self.values[0]
        selectedTemplate = self.values[2]        
        

        #######################
        ## CLIENT CALL BACKS ## 
        #######################
        def create_site_callback():
            try:
                FileManger.copyTemplateToOutPut(selectedTemplate, company, id) 
            except:
                print("Error creating site!!!")
                return
            self.currentCust["sitedetails"]["sitesStatusId"] = "2"
            customer.update(id,self.currentCust)
            parent.cb()
            self.close_windows()

        def run_server():
            try:
                FileManger.runServer(company, id)
            except:
                print("Something went wrong. Could not lanch server :(")

        def create_super_user():
            self.close_windows()
            try:
                FileManger.createSuperUSer(company, id) 
            except Exception as e:
                print ("Could not run super user command" + str(e))
                return
            self.currentCust["sitedetails"]["superUserCreated"] = "true"
            Customer.Customer().update(id,self.currentCust)
            parent.cb()
            self.close_windows()


        def ftp():
            self.close_windows()
            try:
                FileManger.ftp(company, id) 
            except Exception as e:
                print ("Could not FTP to server" + str(e))
                return

            #Get customer to update, temp fix. Replace with original data from list get            
            self.currentCust["sitedetails"]["sitesStatusId"] = "3"
            Customer.Customer().update(id,self.currentCust)
            parent.cb()
        
        def set_live():
            #Get customer to update, temp fix. Replace with original data from list get           
            self.currentCust["sitedetails"]["sitesStatusId"] = "4"
            Customer.Customer().update(id,self.currentCust)
            parent.cb()
            self.close_windows()

            
        status = self.values[5]
        super_user_exists = self.values[4]
        if (status == "Pending"):
            create_site_button = tk.Button(master, text="Create Site",  command = create_site_callback).grid(row=10,columnspan=2,sticky='nesw')
     
        
        #if site available launch site
        if (status != "Pending" and status != "Cancelled" and  status != "Deleted"):
            print(self.values)
            run_server_button = tk.Button(master, text="Run Server",  command = run_server).grid(row=11,columnspan=2,sticky='nesw')
          

        if (status == "Created"):             
            if (super_user_exists.upper() == "TRUE"):
                create_another_super_user_button = tk.Button(master, text="Create another Super user",  command = create_super_user).grid(row=12,columnspan=2,sticky='nesw')
                
                #Only allow FTP to site if site created and super user created
                if (status == "Created"):
                    create_site_button = tk.Button(master, text="Upload to server",  command = ftp)
                else:
                    create_site_button = tk.Button(master, text="Re-upload to server",  command = ftp).grid(row=13,columnspan=2,sticky='nesw')
              

            else:
                create_super_user_button = tk.Button(master, text="Create Super user",  command = create_super_user).grid(row=14, columnspan=2,sticky='nesw')
                
        if(status == "Staging"):
            set_live_button = tk.Button(master, text="Set site to live",  command = set_live).grid(row=15,columnspan=2,sticky='nesw')
            

        
    def close_windows(self):
        self.master.destroy()


def main(): 
    root = tk.Tk()
    #root.geometry("1280x720")
    
    app = MainScreen(root) 
    root.mainloop()


if __name__ == '__main__':
    main()