cd ..
cd Project.IdentityService
dotnet ef database update --connection "Data Source=localhost,1444;Initial Catalog=IdentityService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S localhost,1444 -U sa -d IdentityService -i "../Database/IdentityService.sql"
cd ..
cd bash
