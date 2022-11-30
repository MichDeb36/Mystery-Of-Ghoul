INCLUDE globals.ink

->familyConversation

=== familyConversation ===
Pewnie zastanawiasz się co to za miejsce...
    +[Czy to jest Twoja rodzina?]
        -> family
    +[Tutaj wydarzyło się coś strasznego]
        -> chose2
    +[Co tu się stało?]
        -> chose3
        
        
===family===
Tak to mój syn Mateusz i żona Marta...
    +[Co się wtedy wydarzyło?]
        -> storySword
    +[Czy Ty ich zabiłeś?]
        -> fault
    +[Co tu robiliście?]
        -> chose3

===chose2===
Dokładnie 7 lat temu, doszło do tragedii...
->storySword

===chose3===
Przyjechałem tutaj 7 lat temu z rodziną na wakacje.
->storySword

===fault===
Tak ale nie chciałem tego...
->storySword

===storySword===
Pewnej nocy, spacerując po lesie znalazłem dziwny przedmiot. 
Był to miecz, 
wyglądał na bardzo stary ale emanował jakąś tajemniczą energią.
Zabrałem go do tego małego domku, gdzie nocowałem z rodziną.
Kiedy odkładałem go na stolik skaleczyłem się ostrzem
a kropla krwi spadła na czerwony kryształ znajdujący się w rękojeści.
    +[Miecz był magiczny?]
        -> next
    +[Co było potem?]
        -> next
    +[Twoja rodzina to widziała?]
        -> family2

===family2===
Zarówno moja żona jak i synek spali a ja...
->next

===next===
Poczułem nagły przypływ energii i straciłem przytomność...
Ocknąłem się następnego dnia, 
ja wyglądałem tak jak teraz a moja rodzina...
spłoneła w tym budynku. 
    +[Czyli to wszsytko przez miecz?]
        -> sword1
    +[Co wtedy zrobiłeś?]
        -> sword2
    +[Co się stało z mieczem?]
        -> sword3

===sword1===        
Nie ma innej możliwości.
->sword3

===sword2===        
Zacząłem szukać tego przeklętego miecza...
->sword3

===sword3===
Szukałem go wszędzie ale miecz zniknął.
Zapewne tylko on może znowu uczynić mnie...
~ feedback = "soldiers"
Znowu ci żołnierze...
Schowaj się!
~ feedback = "death4"
->END
        
        
        
        