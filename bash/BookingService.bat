cd ..
cd Project.BookingService
dotnet ef database update --connection "Data Source=muddyworld.xyz,1444;Initial Catalog=BookingService;Persist Security Info=True;User ID=sa;Password=Eclinic123;"
sqlcmd -S muddyworld.xyz,1444 -U sa -P Eclinic123 -d BookingService -i "..\Database\BookingService.sql"
cd ..
cd bash
