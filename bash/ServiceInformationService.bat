cd ..
cd Project.ServiceInformationService
dotnet ef database update --connection "Data Source=muddyworld.xyz,1444;Initial Catalog=ServiceInformationService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S muddyworld.xyz,1444 -U sa -P Eclinic123 -d ServiceInformationService -i "..\Database\ServiceInformationService.sql"
cd ..
cd bash
