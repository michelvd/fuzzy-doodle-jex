# Vooraf
Twee nieuwe projecten.
Veel keuzes altijd bij een nieuw project, zeker als je helemaal vrij bent.

Als eerste maar dit document om mijn gedachten de vrije loop te laten, dan is het wellicht wat duidelijker voor de beoordelaar waarom keuzes zijn gemaakt.
Sowieso bij keuzes in code als ik een shortcut neem vanwege de tijd, dat ik dan de (betere, meer tijd kostende) alternatieven toon.
Tijd wordt wel een issue. Veel zaken om het goed in productierijp te maken kosten tijd, dus dat gaat niet helemaal lukken, maar we gaan er zo veel als mogelijk in proberen te krijgen.
Een werkende applicatie moet wel lukken, een frontend en een backend.
Als ik de opdracht zie dan lijkt het me backend heavy: EF modellen, database, CRUD voor 2 entiteiten (ik ken behalve OData geen framework dat CRUD voor REST oplost, maar alleen qua naam, dat is niet zinnig om voor dit assessment te leren), dus het wordt voor mij handwerk vwb queries.

De frontend krijgt een lijst met bedrijven en aanmaken van een vacature.
Even nadenken hoe dat in een enigzins representabele UI te stoppen.

Ik gok zo iets meer dan de helft van de tijd backend, en dus iets minder dan de tijd frontend.
Beginnen maar met een kleine planning (in planning.md).

# planning
Planning gemaakt, toch wel veel taken voor de CRUD. Was op mijn laatste projecten ook zo. Mss toch eens naar een CRUD framework kijken.
2 uurtjes voor story 1, en 1 uur per stuk voor story 2 en 3. Pfoe. Dat wordt aanpoten.

# backend projecten
backend projecten in .NET 6. Laatste lts tot voor kort, nog geen project van mezelf gepoort naar .NET 8, zitten voor deze opdracht geen onmisbare issues in, dus maar op safe met .net 6
note to PO: migratie story voor .net 8

## EF
Dan merk je dat je dat niet elke dag opzet, dat je meestal in een bestaande context komt. Relatief veel uitzoekwerk

## controller methods
### algemeen
al die read/get methods heb ik laatst in een project ook geimplementeerd (opgezet door de architect) in een separaat alleen-lezen project met GraphQl.
dus vanaf de frontend kon je dan queries doen op de backend via de graphql met het hotChocolate framework. Dat was een soort CQRS. 
werkte wel goed, maar het nadeel was dat alles over 2 projecten verdeeld was.

### patch
ik heb geen json patch geimplementeerd, maar ik heb wel een patch method gemaakt die een company kan updaten

### error handling en validatie
tijd tikt.... er moet natuurlijk errorhandling in, die een ProblemDetails class teruggeeft.
En validatie bij CRUD. Zelf iets maken of FluentValidation implementeren.

### en bij de vacancy crud....
moet er natuurlijk gecontroleerd worden of de company wel bestaat (en als er gebruikers zijn, of deze wel door de gebruiker mag worden gemuteerd)

## dto class?
zit er soms nog in 'van vroeger', hadden net zo goed records kunnen zijn

### niet alle crud voor vacancy gemaakt (geen delete en patch) 
onder het mom van yagni? Nee, omdat de tijd voor de backend echt op was en deze methods nog niet nodig waren

# Frontend
Project opzetten, vastgehouden aan de defaults.
Dus geen JEX policies enforced met linting

Wel material toegevoegd, ik dacht hoe moeilijk kan het zijn, maar kost toch voor elk UI ding meer tijd dan ik verwacht had.

Geen checks ingebouwd bij het toevoegen van vacancy bij een bedrijf. Bij de API zelfde issue: bij een app in 4 uur is robuustheid niet altijd aanwezig.
Mss had ik met de PO moeten overleggen bij story 1: ik kan story 1-3 doen zonder robuustheid of alleen 1 met robuustheid. Mss had de PO wel voor alleen story 1 gekozen....

Het was ff rammen de laatste loodjes om het nog enigzins binnen de tijd te houden
Invoer-scherm voor vacatures is echt een hello world geworden.

# Einde
Ik denk dat ik er iets minder dan 5 uur aan besteed heb.
Het was leuk om te doen, maar wel pittig. Weinig tijd om fouten te maken / ergens goed over na te denken (behalve als ik met de PO had overlegd om maar 1 story te doen, maar dat klonk lame om te doen)
Ik heb bewezen dat je er niet frisser van wordt als je 4 a 5 uur achter elkaar aan het rammen bent :-)
Nog even de boel in github zetten en dan ff relaxen.



