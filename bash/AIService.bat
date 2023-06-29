cd ..
cd Project.AIService
sqlcmd -S localhost,1444 -U sa -P Eclinic123 -d AIService -i "..\Database\AIService.sql"
cd ..
cd bash

