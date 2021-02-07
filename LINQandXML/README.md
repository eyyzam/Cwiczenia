## LINQ and XML

Napisz program, **wykorzystując operatory LINQ** pobierający ze standardowego wejścia bazę klientów wraz z przypisanymi im zamówieniami i wypisujący na standardowe wyjście listę wszystkich klientów którzy w podanym roku złożyli przynajmniej jedno zamówienie o wartości nie mniejszej niż podana kwota.

Baza klientów jest niepusta i zapisana w formacie XML (patrz przykład). Może się zdarzyć, że klienci nie mają żadnych zamówień.

Standardowe wejście:
* W pierwszym wierszu rok dla którego należy wykonać wyszukiwanie
* W drugim wierszu kwota graniczna zamówienia
* W kolejnych wierszach kod XML bazy

**Przykład**
```xml
2014
50.50
<Customers>
  <Customer>
    <CustomerID>KRAHA</CustomerID>
	<CompanyName>Krakowski Handelek</CompanyName>
	<City>Kraków</City>
    <Country>Poland</Country>
	<Orders></Orders>
  </Customer>
  <Customer>
	<CustomerID>ANATR</CustomerID>
	<CompanyName>Ana Trujillo Emparedados y helados</CompanyName>
	<City>Mexico</City>
	<Country>Mexico</Country>
	<Orders>
	  <Order>
	    <OrderID>10200</OrderID>
		<OrderDate>2014-09-18T00:00:00</OrderDate>
		<Total>88.00</Total>
	  </Order>
	</Orders>
  </Customer>
  <Customer>
	<CustomerID>ANTON</CustomerID>
	<CompanyName>Antonio Moreno Taqueria</CompanyName>
	<City>Rio de Janeiro</City>
	<Country>Brazil</Country>
	<Orders>
	  <Order>
		<OrderID>10365</OrderID>
		<OrderDate>2014-11-27T00:00:00</OrderDate>
		<Total>403.20</Total>
	  </Order>
	  <Order>
		<OrderID>10507</OrderID>
		<OrderDate>2015-04-15T00:00:00</OrderDate>
		<Total>749.06</Total>
	  </Order>
	</Orders>
  </Customer>
</Customers>
```

Na standardowe wyjście wypisz - w oddzielnych wierszach - oddzielone przecinkami
* Nazwę firmy **{CompanyName}**, która w podanym roku złożyła przynajmniej jedno zamówienie o wartości nie mniejszej niż podana kwota
* Kwotę zamówienia, poprzedzoną średnikiem i spacją

Wynik posortuj rosnąco najpierw według wartości zamówienia **{Total}**, a następnie według nazwy firmy **{CompanyName}**

Jeśli nie będzie firm spełniających podane kryteria, wypisz słowo **empty**

Dla powyższego przykładu program wypisze:
```
Ana Trujillo Emparedados y helados; 88.00
Antonio Moreno Taqueria; 403.20
```

Gdyby w powyższym przykładzie podano rok **2014** oraz wartość **500** program wypisałby słowo **empty**