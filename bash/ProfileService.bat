cd ..
cd Project.ProfileService
dotnet ef database update --connection "Data Source=muddyworld.xyz,1444;Initial Catalog=ProfileService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S muddyworld.xyz,1444 -U sa -P Eclinic123 -d ProfileService -i "..\Database\ProfileService.sql"
cd ..
cd bash

