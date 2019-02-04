# aspnetcore
Lesmateriaal ASP.NET Core - Huidige versie ASP.NET Core 2.2

F5 = run & debug <br />
Ctrl  + F5 = run --> kan je aanpassingen doen in code en hoef je heel solution niet te builden, je kan webapplicatie gewoon refreshen (dankzij Roslyn) <br />

<br />
<br />

Webapplicatie start op https://localhost:44304/ --> omwille van app.UseHttpsRedirection(); in Startup.cs. <br />
--> Bij problemen moet je in cmd 'dotnet dev-certs https --trust' uitvoeren en dan 'yes' kiezen om het development certificaat toe te staan!
<br />
