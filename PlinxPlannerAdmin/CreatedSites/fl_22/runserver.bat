@echo "starting server"
cd %~dp0
start cmd /k python manage.py runserver 8004
PING localhost -n 6 >NUL
start "" http://localhost:8004/admin