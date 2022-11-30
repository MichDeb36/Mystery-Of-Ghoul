INCLUDE globals.ink

->EndStory


===EndStory===
Witaj, co tu robisz?
    +[Mam miecz, którego szukałeś]
        -> friend2
    +[Przez moment, chciałem Cię zabić]
        -> chose2
    +[To chyba nasze ostatnie spotkanie]
        -> friend1
        
     
===chose2===    
Ciesze się, że tego nie zrobiłeś
->friend2

===friend1===
Żegnaj 
Przyjacielu...
~ feedback = "endStory"
->END
        
===friend2===
Dziękuję
Przyjacielu...
~ feedback = "endStory"
->END