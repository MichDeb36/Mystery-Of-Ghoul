INCLUDE globals.ink

->familyConversation

=== familyConversation ===
Widzę, że udało ci się znowu powrócić.
Wybacz, od dawna nie częstowałem innych osób herbatą.
Poczekaj chwilę muszę coś przygotować... 
Muszę przygotować drobny prezent dla mojej rodziny
ale później będziesz mógł wyjątko pójść zemną.
Tylko poczekaj chwilę...
~ feedback = "flowers"
.
.
.
.
->questionFamily

=== questionFamily ===
Dobra możesz pójść za mną.
Chcesz?
    +[Na pewno mogę?]
        -> chose1
    +[Nie chce ci przeszkadzać]
        -> chose2
    +[Chętnie pójdę]
        -> chose3

===chose1===
Tak, dziś wyjątowo możesz.
->endStory

===chose2===
Dziś wyjątowo możesz mi przeszkadzać.
->endStory

===chose3===
Dobrze...
->endStory

===endStory===
jest pewna...
~ feedback = "rain"
rocznica.
Nie chce żeby dziś byli sami...
Chodź za mną
~ feedback = "goToCemetery"
->END