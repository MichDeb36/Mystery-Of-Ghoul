
INCLUDE TeaConverstation.ink



=== firstConversation(info) ===
~ feedback = info
Hmm tylko porozmawiać... 
Więc słucham... Co chcesz mi powiedzieć?
    +[Kim jesteś?]
        -> chose1
    +[Wspomniałeś o swojej rodzinie...]
        -> chose2("death2")
    +[Dlaczego inni chcą cię zabić?]
        -> chose3
    
=== chose1 ===
Kim jestem? Jestem prześladowany przez ludzi takich jak Ty!
Czemu miałbym się otwierać przed tobą?
    +[Prześladują cię bo jesteś potworem]
        -> choseMonster("death2")
    +[Wspomniałeś wcześniej o swojej rodzinie...]
        -> chose2("death2")
    +[Dlaczego inni chcą cię zabić?]
        -> chose3

=== chose2(info) ===
Nikt nie może zakłócać ich spokoju!
Zginiesz za to, marny człowieku.
~ feedback = info
->END

=== chose3 ===
Inni? Ty niechcesz? Przychodzich tak samo ubrany, z ich urządzeniem,
które pozwala nam rozmawiać. Kim w takim razie ty jesteś?
    +[Sam nie wiem kim jestem, nic nie pamiętam]
        -> oblivion
    +[Znalazłem ich sprzęt ale nie jestem jednym z nich]
        -> oblivion
    +[Ja już nie chce Cię zabić]
        -> notKill

===choseMonster(info)===
Jestem potworem to prawda. Więc muszę zachowywać się jak potwór.
Przygotuj się na kolejną śmierć.
~ feedback = info
->END

=== notKill ===
I co? mam Ci dziękować, że nie chcesz mnie zabić? 
Ja tylko bronie swoją rodzinę przed złymi ludzmi
ale tylko jeśli im przeszkadzają!
    +[Nie chce im przeszkadzać, nic nie pamiętam]
        -> oblivion
    +[Mam ich sprzęt ale nie jestem jednym z nich]
        -> oblivion
    +[Ja nie jestem zły... a przynajmniej tak mi się wydaje]
        -> oblivion
        
=== oblivion ===
Powiedzmy, że narazie Ci wierze.
Coś z tobą musi być. Jeszcze żadna osoba którą zabiłem nie wróciła...
->ghoulDialogue1


