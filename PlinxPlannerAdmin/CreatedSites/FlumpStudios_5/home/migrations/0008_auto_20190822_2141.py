# Generated by Django 2.2.3 on 2019-08-22 20:41

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('home', '0007_auto_20190717_0809'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='homepage',
            name='client_isOrganisation',
        ),
        migrations.AlterField(
            model_name='homepage',
            name='client_organisationName',
            field=models.CharField(default='Flump Studios', max_length=50, null=True),
        ),
        migrations.AlterField(
            model_name='homepage',
            name='intro_header',
            field=models.CharField(default='Flump Studios', max_length=50),
        ),
    ]
