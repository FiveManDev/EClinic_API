cd ..
cd Project.CommunicateService
dotnet ef database update --connection "Data Source=muddyworld.xyz,1444;Initial Catalog=CommunicateService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S muddyworld.xyz,1444 -U sa -P Eclinic123 -d CommunicateService -i "..\Database\CommunicateService.sql"
cd ..
cd bash
