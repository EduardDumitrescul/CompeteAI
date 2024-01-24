# CompeteAI
Backend: (4 pct)

Orice numar se specifica in cerinte se inmulteste cu numarul de coechipieri (pentru nota 10 fiecare trebuie sa faca toate cerintele in proiect)
 -3 Controllere (minim); Fiecare Metoda Crud, REST cu date din baza de date. (1p)
 -Cel puțin 1 relație între tabele din fiecare fel (One to One, Many to Many, One to Many); Folosirea metodelor din Linq: GroupBy, Where, etc; Folosirea Join si Include (1p)
 -Autentificare + Roluri; Autorizare pe endpointuri în funcție de Roluri; Cel putin 2 Roluri: Admin, User 
 -Sa se foloseasca repository pattern + Service 

Puncte extra (2-4 pct maxim pentru recuperare puncte prezenta; daca totusi aveti si full prezenta si nu faceti frontend sau aveti lipsa de punctaj in alta parte va adaug punctele extra):
- Autentificare cu Identity (1 pct) 
- Auth cu refresh token (1 pct)
- Paginare in returnarea listelor de date (0.5 pct)

Frontend: (2 pct)
 
Cel putin 3 componente. Existenta rutelor(simple + parametru).
Cel putin 3 servicii conectate la serverul din .Net . Afisarea de date din servicii in componente.
Cel putin 1 directiva. (pe langa cea facuta la laborator)
Cel putin 1 pipe
Register + Login (cu reactive forms) + Implementare Guard

Puncte extra: 
Folosire 3 metode care nu au fost folosite la laborator din rxjs (1 pct) (https://rxjs.dev/api)
-  debounceTime
-  distinctUntilChanged
-  catchError
-  tap
-  takeUntil
