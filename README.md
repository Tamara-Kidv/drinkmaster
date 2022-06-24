# Drinkmaster



## Vereisten

Om dit te runnen, zijn de volgende dingen nodig:

Visual studio 2022 preview

Dotnet 6 / Maui



## Instructies maui

Om maui te installeren, volg de instructies op

https://dotnet.microsoft.com/en-us/learn/maui/first-app-tutorial/install



## Run

Om de debug - versie te runnen, druk na het openen van dit project boven op Run > En kies hier voor een platform naar keuze.

De app is gemaakt voor telefoons, maar in de ontwikkel omgeving is het aanbevolen om de app te draaien als Windows app, omdat dit hetzelfde moet werken, en lichter is op de computer hardware.

## Command line

Om de app te draaien zonder Visual Studio (Vereist is dat nu de MAUI workload los geïnstalleerd is), gebruik

`cd DrinkMaster`

Mac: `dotnet build -t:Run -f net6.0-maccatalyst`

Android: `dotnet build -t: Run -f net6.0-android`

iOS: `dotnet build -t: Run -f net6.0-ios`

Windows: `dotnet build -t: Run -f net6.0-windows`

Dit kan gebruikt worden om de applicatie te gebruiken en testen op bijvoorbeeld een Mac, waarop Visual Studio op dit moment nog geen ondersteuning bied.
