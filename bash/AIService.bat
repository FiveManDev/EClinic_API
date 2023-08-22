cd ..
cd Project.AIService
sqlcmd -S muddyworld.xyz,1444 -U sa -P Eclinic123 -i "..\Database\AIService.sql"
cd ..
docker start ai
cd bash

