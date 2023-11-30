# setup
je hebt alle sources al binnengehaald

# setup backend
## benodigd
.net core 6.0

## database
maak een database aan met als naam 'jexassessment'
voer het script 'setup database' uit dat in het api project in de solution folder staat
voer het script 'setup data' uit dat in het api project in de solution folder staat
pas de connectiestring uit de appsettings.Development.json (jaja, hoort in een secret) aan voor jouw lokale omgeving

## Run
Start de backend vanuit Visual Studio
de api start op http://localhost:5062/swagger/index.html

## postman
Je kunt de postman collectie importeren die in het api project in de solution folder staat 

# setup frontend
## benodigd
Node 18.13 of hoger
Angular 16

## install npm packages
voer npm install uit in de folder van het frontend project

## run
start het project met "ng serve"

## backend
Als je de backend op een andere poort oid draait dan moet je dat aanpassen in "Data-Service.ts" in "apiUrlRoot"

