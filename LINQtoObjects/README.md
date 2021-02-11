## LINQ and Objects - edycja video (C#)

Nagranie wideo trwa dokładnie 2 godziny. Pracujesz w edytorze wideo i oznaczyłeś przedziały cięcia materiału (w formacie przedziałów, punkty cięcia zakodowane w formacie h:mm:ss)

**0:00:00-0:00:05;0:55:12-1:05:02;1:37:47-1:37:51**

Zakładamy, że przedziały podane są w formie napisu, punkty krańcowe oddzielone myślnikiem, przedziały oddzielone średnikami, zachowany jest porządek rosnący i przedziały nie nachodzą na siebie.
Twoim zadaniem jest opracowanie zapytania przekształcającego powyższe dane w ciąg przedziałów czasowych, które zostaną zachowane po przycięciu materiału, tzn. dla powyższego przykładu otrzymamy:

**0:00:05-0:55:12;1:05:02-1:37:47;1:37:51-2:00:00**

### Specyfikacja wejścia / wyjścia

* Na standardowe wejście, w pierwszej i jedynej linii podana będzie niepusta sekwencja zarejestrowanych przedziałów, cięcia materiału video.
* Na standardowe wyjście sekwencja niepustych przedziałów czasowych, które zostaną zachowane po przycięciu materiału. Jeśli sekwencja ta będzie pusta, na wyjście wypisany zostanie napis empty

**Ograniczenia:**
* Zadanie rozwiąż wykorzystując operatory LINQ
* Jeśli nie użyjesz instrukcji pętli (słowa kluczowe **for, foreach, while, goto**) i Twoje rozwiązanie będzie poprawne, otrzymasz maksymalną liczbę punktów.

W funkcji **Main** napisz kod potwierdzający poprawność wykonania zadania na reprezentatywnych przykładach