from distutils.dir_util import copy_tree
import os


def copyTemplateToOutPut(template, companyName, id ):

    fromDirectory = "Templates/Template" + template
    toDirectory = "CreatedSites/" + companyName + "_" + str(id)
    try:
        os.mkdir(toDirectory)
    except OSError:
        print ("Creation of the directory %s failed" % toDirectory)
    else:
        print ("Successfully created the directory %s " % toDirectory)

    try:
        copy_tree(fromDirectory, toDirectory)
    except:
        print("Site creation faild")
    else:
        print("Site created at " + toDirectory)



