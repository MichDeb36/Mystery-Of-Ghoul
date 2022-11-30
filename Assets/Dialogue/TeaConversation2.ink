INCLUDE globals.ink

->questionWithTea

=== questionWithTea ===
Skoro już pijemy herbatę pewnie masz do mnie jeszcze jakieś pytania.
Więc słucham...
    +[Od urodzenia... tak wyglądasz?]
        -> beHuman("no")
    +[Co tu robisz?]
        -> storyGhoul
    +[Często masz gości? Masz przygotowany kubek.]
        -> guest
        
=== beHuman(info) ===
Nie zawsze tak wyglądałem, kiedyś byłem człowiekem.
Jednak pewne wydarzenia zrobiły ze mnie to coś...
    +[Jakie wydarzenia?]
        ->poisonedTea
    +[Co tu robisz?]
        -> storyGhoul
    +[Często masz gości? Masz przygotowany kubek.]
        -> guest
~ feedback = info

=== storyGhoul ===
Przyjechałem kiedyś do tego lasu z rodziną.
Moja rodzina musiałą tu zostać, więc i ja tu zostałem...
->poisonedTea

=== guest ===
Czesto przychodzą do mnie żołnierze, których ciała za pewne widziałeś.
Lecz ten drugi kubek... 
Często pijałem herbatę z moją żoną.
->poisonedTea

=== poisonedTea ===
Jakoś dziwnie wyglądasz? Coś się stało?
    +[E..g..hhh]
        ->poisonedTea2
    +[Pom...]
        -> poisonedTea2
    +[Ag..h]
        -> poisonedTea2

=== poisonedTea2 ===
Ehh..
Przypomniałem sobie, że zioła które dodaje do herbaty
są trujące dla ludzi...
ale mam nadzieję że jeszcze do mnie wrócisz.
~ feedback = "poisoned"
->END