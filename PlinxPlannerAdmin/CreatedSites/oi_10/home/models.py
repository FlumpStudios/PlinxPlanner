from django.db import models
from django.db import models
import os
import sys
from modelcluster.fields import ParentalKey

from wagtail.core.models import Page, Orderable
from wagtail.core.fields import RichTextField
from wagtail.admin.edit_handlers import FieldPanel, MultiFieldPanel, InlinePanel
from wagtail.images.edit_handlers import ImageChooserPanel
from wagtail.search import index
from PlinxPlanner.businessLogic.httpManager import Customer

class HomePage(Page):
    #Get folder name
    app_name = os.path.dirname(os.path.abspath(__file__)).split("\\")[-2]

    #Get the id from the folder name
    app_id = app_name.split("_")[1]
    print("APP ID = " + app_id)

    customer = Customer(app_id)

    intro_header = models.CharField(max_length=50,default=customer.organsiationName or "Welcome to our website!")
    
    intro_text = RichTextField(blank=True)
    intro_continue_button_text = models.CharField(max_length=50, default='Continue')        
    
    client_firstname = models.CharField(max_length=50, default=customer.getFirstName())    
    client_surname = models.CharField(max_length=50, default=customer.getSurname())    

    print("USER DETAILS COMING........")
    print(customer.getFirstName())
    print(customer.getSurname())

    client_organisationName = models.CharField(max_length=50, default=customer.getOrgansiationName(), null=True)

    
    intro_background = models.ForeignKey(
        'wagtailimages.Image',
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='+'
    )


    content_panels = Page.content_panels + [
        MultiFieldPanel(
            [
                FieldPanel('client_firstname'),
                FieldPanel('client_surname'),
                FieldPanel('client_organisationName'),         
            ],
            heading="Client Information",  
        ),
    ]

    content_panels += [
        MultiFieldPanel(
            [
                FieldPanel('intro_header'),
                FieldPanel('intro_text'),
                FieldPanel('intro_continue_button_text'),
                ImageChooserPanel('intro_background')
            ],
            heading="Introduction",  
        ),
    ]

    

    # promote_panels = [
    #     MultiFieldPanel(Page.promote_panels, "Common page configuration"),
    #     ImageChooserPanel('intro_background'),
    #     ]  


