cd ..
cd Project.AIService
sqlcmd -S localhost,1444 -U sa -d AIService -i "../Database/AIService.sql"
cd ..
cd bash

