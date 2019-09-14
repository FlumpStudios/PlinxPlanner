@echo "starting server"
cd %~dp0
start cmd /k python manage.py runserver
PING localhost -n 6 >NUL
start "" http://localhost:8000/admin