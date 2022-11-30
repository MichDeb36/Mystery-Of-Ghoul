INCLUDE globals.ink

-> firstMeeting

=== firstMeeting ===
Co robisz w moim domu?
    +[Nie wiem]
        -> hello1("death")
    +[Chyba zabłądziłem]
        -> hello2("death")
    +[Przyszedłem Cię zabić]
        -> hello3("death")
    
=== hello1(info) ===
Nie wiesz?! Ha ale ja dobrze wiem.
Przygotuj się na śmierć!
~ feedback = info
->END

=== hello2(info) ===
Zabłądziłeś?! pewnie tak samo jak reszta żołnierzy!
Szykuj się na śmierć!
~ feedback = info
->END

=== hello3(info) ===
TY chcesz zabić MNIE? możesz spróbować!!
Przygotuj się do walki!
~ feedback = info
->END
