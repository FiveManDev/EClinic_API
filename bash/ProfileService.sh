cd ..
cd Project.ProfileService
dotnet ef database update --connection "Data Source=localhost,1444;Initial Catalog=ProfileService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S localhost,1444 -U sa -P Eclinic123 -d ProfileService -i "../Database/ProfileService.sql"
cd ..
cd bash

