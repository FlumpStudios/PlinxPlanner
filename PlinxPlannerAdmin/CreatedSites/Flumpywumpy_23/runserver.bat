@echo "starting server"
cd %~dp0
start cmd /k python manage.py runserver 8001
PING localhost -n 6 >NUL
start "" http://localhost:8001/admin