INCLUDE FirstConversation.ink

-> thirdMeeting

=== thirdMeeting ===
Znowu Ty? Przecież już cię zabiłem...
Mów czemu mnie nachodzisz.. 
albo zabiję Cię po raz kolejny!
    +[Przyszedłem Cię zabić]
        -> hello1("death2")
    +[Przyszedłem Ci pomóc]
        -> hello2("death2")
    +[Chce tylko porozmawiać]
        -> hello3

=== hello1(info) ===
Poprzednia śmierć niczego Cię nie nauczyła?
Tym razem postaram się bardziej!
~ feedback = info
->END

=== hello2(info) ===
Ty chcesz pomóc mi? 
Jak? Wbijając mi nóż w serce?
Nie dam się nabrać i tym razem postaram się bardziej!
~ feedback = info
->END


=== hello3 ===
->firstConversation("yes")




