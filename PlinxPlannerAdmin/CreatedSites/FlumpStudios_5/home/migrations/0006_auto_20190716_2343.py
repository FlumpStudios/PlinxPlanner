# Generated by Django 2.2.3 on 2019-07-16 22:43

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('home', '0005_homepage_client_firstname'),
    ]

    operations = [
        migrations.AddField(
            model_name='homepage',
            name='client_isOrganisation',
            field=models.BooleanField(default=False),
        ),
        migrations.AddField(
            model_name='homepage',
            name='client_organisationName',
            field=models.CharField(default='', max_length=50),
        ),
        migrations.AddField(
            model_name='homepage',
            name='client_surname',
            field=models.CharField(default='Test Fname', max_length=50),
        ),
    ]
