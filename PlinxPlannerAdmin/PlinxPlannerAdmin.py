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
        menu.add_cascade(label="File", menu=file)
        edit = tk.Menu(menu)       
        menu.add_cascade(label="Edit", menu=edit)        
     
    def draw_table(self, master):
        self.tree=Treeview(master)
        self.tree["columns"]=("one","two","three","four","five")
        self.tree.column("#0", width=200, minwidth=150, stretch=tk.NO)
        self.tree.column("one", width=200, minwidth=150, stretch=tk.NO)
        self.tree.column("two", width=200, minwidth=150, stretch=tk.NO)
        self.tree.column("three", width=200, minwidth=150, stretch=tk.NO)
        self.tree.column("four", width=200, minwidth=150, stretch=tk.NO)
        self.tree.column("five", width=200, minwidth=150, stretch=tk.NO)
        
        self.tree.heading("#0",text="Customer ID",anchor=tk.W)
        self.tree.heading("one", text="Company",anchor=tk.W)
        self.tree.heading("two", text="Name",anchor=tk.W)
        self.tree.heading("three", text="Template",anchor=tk.W)                
        self.tree.heading("four", text="Order Date",anchor=tk.W)
        self.tree.heading("five", text="Site Status",anchor=tk.W)
       
        cust = Customer.Customer_list()
        for x in cust.getCustomerList():
             self.tree.insert('', 'end', text=(x["customerId"]), values=(x["companyName"],x["firstName"] + " " + x["surname"], x["sitedetails"]["templateId"], x["firstContactDate"],x["sitedetails"]["siteStatus"]["name"]))                     

        self.tree.bind("<Double-1>", self.OnDoubleClick)
        self.tree.pack()
    
    def OnDoubleClick(self, event):
        item = self.tree.selection()[0]
        vals = self.tree.item(item,"values")
        text = self.tree.item(item,"text")
        
        self.newWindow = tk.Toplevel(self.master)
        self.app = Popup(self.newWindow, values=vals, text=text)
         
    def client_exit(self):
        exit()


class Popup:
    def __init__(self, master, values, text):
        self.values = values
        self.text = text
        print(self.values)
        self.master = master
        self.frame = tk.Frame(self.master)                
        
        listbox = tk.Listbox(master)
        listbox.pack()

        listbox.insert(tk.END, self.text)
        for item in self.values:
            listbox.insert(tk.END, item)
        
        self.frame.pack()   
        
        id = self.text
        company = self.values[0]
        selectedTemplate = self.values[2]
        
        
        def create_site_callback():
            FileManger.copyTemplateToOutPut(selectedTemplate, company, id)       
            
        but = tk.Button(master, text="Create Site",  command = create_site_callback)
        but.pack()

    def close_windows(self):
        self.master.destroy()


def main(): 
    root = tk.Tk()
    #root.geometry("1280x720")
    
    app = MainScreen(root)
    root.mainloop()

if __name__ == '__main__':
    main()