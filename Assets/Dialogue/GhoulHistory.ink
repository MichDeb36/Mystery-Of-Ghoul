INCLUDE globals.ink

->ghoulDialogue1

=== ghoulDialogue1 ===
Skoro już tu jesteś i nie chcesz mnie zabić, 
to może napijesz się hebaty? 
    +[Herbaty?]
        -> teaQuestion
    +[Chętnie]
        -> servingTea
    +[Nie chce twojej herbaty, chce odpowiedzi]
        -> withoutTea
    
=== teaQuestion ===
Tak herbaty, wy ludzie już jej nie pijecie?
    +[hmmm... pijemy]
        -> servingTea
    +[Skąd wiesz, że ludzie piją herbatę?]
        -> servingTea
    +[Nie pamiętam...]
        -> servingTea

=== withoutTea ===
Dobrze odpowiem na Twoje pytania ale tylko jeśli napijesz się herbaty.
Obraź mnie jeszcze raz a domyślasz się jak to się skończy...
->servingTea

=== servingTea ===
Pozwól, że nam naleję.
->drinkingTea

=== drinkingTea ===
Napijmy się herbaty i zaraz wrócimy do rozmowy
->END









