from distutils.dir_util import copy_tree
import os
import sys, os
import subprocess
import threading
from ftplib import FTP
import shutil

def copyTemplateToOutPut(template, companyName, id):

    fromDirectory = "Templates/Template" + template
    toDirectory = "CreatedSites\\" + companyName.replace(" ","") + "_" + str(id)
    try:
        os.mkdir(toDirectory)
    except OSError:
        print ("Creation of the directory %s failed" % toDirectory)
    else:
        print ("Successfully created the directory %s " % toDirectory)

    try:
        copy_tree(fromDirectory, toDirectory)
    except:
        print("Site creation failed")
    else:
        print("Site created at " + toDirectory)
        
        dir_path = os.path.dirname(os.path.realpath(__file__))         
        fullpath = dir_path + "\\" + toDirectory + "\\"
        print ("Running Migrations!!!")
        subprocess.call(fullpath + "runmigrate.bat")

def runServer(companyName, id):
    toDirectory = "CreatedSites\\" + companyName.replace(" ","") + "_" + str(id)
    dir_path = os.path.dirname(os.path.realpath(__file__))         
    fullpath = dir_path + "\\" + toDirectory + "\\" 
    print(fullpath + "runserver.bat")
    subprocess.call(fullpath + "runserver.bat")

def createSuperUSer(companyName, id):
    toDirectory = "CreatedSites\\" + companyName.replace(" ","") + "_" + str(id)
    dir_path = os.path.dirname(os.path.realpath(__file__))         
    fullpath = dir_path + "\\" + toDirectory + "\\" 
    subprocess.call(fullpath + "createuser.bat")

def ftp(companyName, id):
    #Zip files
    fn =  companyName.replace(" ","") + "_" + str(id)
    toDirectory = "CreatedSites\\" + fn
    dir_path = os.path.dirname(os.path.realpath(__file__))         
    fullpath = dir_path + "\\" + toDirectory 
    shutil.make_archive(fullpath, 'zip', fullpath)
    
    ftp = FTP('home674408092.1and1-data.host')
    ftp.login(user='ftp88703147-0', passwd = 'PlinxPlanner_2019')
    filename = dir_path + "\\" +  "CreatedSites\\" + fn + ".zip"
    file = open(filename,'rb')
    ftp.storbinary('STOR '+ fn + '.zip', file)     
    ftp.quit()
    

    







        

