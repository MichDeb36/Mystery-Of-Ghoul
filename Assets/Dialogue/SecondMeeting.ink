INCLUDE globals.ink

-> secondMeeting

=== secondMeeting ===
Hmmm chyba Cię już widziałem.
Co robisz w moim domu?
    +[Chyba zabłądziłem]
        -> hello2("death2")
    +[Nie wiem]
        -> hello1("death2")
    +[Przyszedłem Cię zabić]
        -> hello3("death2")
    
=== hello1(info) ===
Sporo osób nie wiem czemu tu się znajduje.
Nie pozwole by zakłócano spokój mojej rodzinie!
~ feedback = info
->END

=== hello2(info) ===
Ah znowu żołnierz, który zabłądził i trafił do mojego domu.
Nie pozwole by zakłócano spokój mojej rodzinie!
~ feedback = info
->END

=== hello3(info) ===
Kolejny, który chce mnie zabić.
Nie pozwole by zakłócano spokój mojej rodzinie!
~ feedback = info
->END