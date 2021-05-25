# left-to-do
Objektorienterad programmering med C# - november 2020
## Inlämningsuppgift i Objektorienterade principer och testning
100/100 (VG)
### Uppgift:
Du ska i denna uppgift skapa en konsolapplikation för att hålla koll på, och ordna arbetsuppgifter, det vill säga en digital att-göra lista. Applikationen ska heta Left To Do. En användare ska vid användning av programmet kunna se vad som är kvar att göra i listan, Markera uppgifter som avklarade, lägga till nya uppgifter i listan samt arkivera avklarade uppgifter.

I denna uppgift ställs högre krav på att du har själv väljer en lämplig kodstruktur och tillämpar det du lärt dig om de objektorienterade principerna. Dessutom måste du utveckla din kod med stöd av enhetstester. Applikationen måste innehålla enhetstester för att lägga till en uppgift i listan, markera en uppgift som avklarad samt arkivera alla avklarade uppgifter i listan. För VG på uppgiften krävs det att det ska finnas två ytterligare typer av "att-göra"-uppgifter, två nya klasser i programmet, som förslagsvis ärver från en gemensam superklass.
### Kravlista:
* Lösningen ska bestå av en konsolapplikation skriven i C# som är körbar med .NET Core
* När man startar programmet ska man mötas av en startmeny som förklarar hur programmet används och låter användaren genomföra resterande krav.
* Man ska som användare kunna lista alla dagens uppgifter, alla uppgifter ska då listas om dom inte är "arkiverade".
* När dagens uppgifter är listade ska de kunna markeras som utförda, eller som kvar att göra beroende på sin nuvarande status. Detta kan förslagsvis köra med en symbol som X eller en emoji som ✔️ eller ✅
* Från programmets menyer ska man även kunna lägga till en ny uppgift.
* Från programmets menyer ska man även kunna arkivera alla uppgifter som för närvarande är utförda.
* Man ska kunna lista alla arkiverade uppgifter, det behöver inte gå att göra något med uppgifterna när de listas på detta vis.
* Den inlämnade lösningen ska bestå av en "Program.cs" fil, en ".csproj" fil samt en fil för varje extra klass du skapar.
* Ett enhetstest finns i lösningen för att testa att uppgifter går att lägga till i listan.
* Ett enhetstest finns i lösningen för att markera en uppgift som avklarad.
* Ett enhetstest finns i lösningen för att arkivera alla avklarade uppgifter i listan.
* Man ska kunna lägga till en särskild typ av uppgift med en "deadline", deadline ska sparas i systemet som antalet dagar kvar att slutföra uppgiften. Denna typ av uppgift ska vara en egen klass.
* Man ska kunna lägga till en typ av uppgift som har en inbyggd checklista med ytterligare detaljer - för att markeras som avklarad så måste alla punkterna i checklistan också markeras som avklarade. Denna typ av uppgift ska vara en egen klass. 
* Lösningen ska innehålla ytterligare 1 eller 2 enhetestester som är lämpliga för de nya typerna av uppgifterna.
* Lösningen ska förutom kod innehålla en fil med namnet "reflections" i formatet md, txt eller pdf
* reflections-filen ska en ska innehålla en kort beskrivning av kodens funktioner och struktur så som du förstår den. Ungefär 2-3 paragrafer.
* Filen reflections ska innehålla rubriken "använda principerer" där du förklarat hur lösningen använder de objektorienterade principerna arv, enkapsulation och polymorfism för de ytterligare uppgifterna i krav 12 och 13
* Filen reflections ska innehålla rubriken "tester för klasser" där du förklarat hur de nya testerna som du skapat för kravet 14 fungerar och varför de är väl valda enhetestester.
