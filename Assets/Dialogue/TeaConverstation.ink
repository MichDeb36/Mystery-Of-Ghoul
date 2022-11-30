INCLUDE globals.ink


=== ghoulDialogue1 ===
Skoro już tu jesteś i nie chcesz mnie zabić, 
to może napijesz się hebaty? 
    +[Herbaty?]
        -> teaQuestion("yes")
    +[Chętnie]
        -> servingTea("servingTea")
    +[Nie chce twojej herbaty, chce odpowiedzi]
        -> withoutTea
    
=== teaQuestion(info) ===
~ feedback = info
Tak herbaty, wy ludzie już jej nie pijecie?
    +[hmmm... pijemy]
        -> servingTea("servingTea")
    +[Skąd wiesz, że ludzie piją herbatę?]
        -> servingTea("servingTea")
    +[Nie pamiętam...]
        -> servingTea("servingTea")

=== withoutTea ===
Dobrze odpowiem na Twoje pytania ale tylko jeśli napijesz się herbaty.
Obraź mnie jeszcze raz a domyślasz się jak to się skończy...
->servingTea("servingTea")

=== servingTea(info) ===
Pozwól, że nam naleję.
~ feedback = info
->drinkingTea

=== drinkingTea ===
Napij się herbaty i zaraz wrócimy do rozmowy
->END