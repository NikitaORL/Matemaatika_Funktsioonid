Funktsiooni uurimine — juhend testijale
Sissejuhatus
Funktsiooni uurimine on veebirakendus, mis on loodud matemaatiliste funktsioonide automaatseks analüüsiks. Kasutaja sisestab funktsiooni valemi (näiteks x^3 - 6*x + 3) ja rakendus teeb tema eest ära kogu selle rutiinse töö, mida tavaliselt tehakse käsitsi paberil: leiab määramispiirkonna, nullkohad, tuletise, kriitilised punktid ja ekstreemumid, seejärel joonistab graafiku ja näitab samm-sammulist lahendust.

1. Mida rakendus teeb
Rakenduse põhifunktsioonid:

Leiab määramispiirkonna — rakendus analüüsib valemit ja otsustab, millistel x väärtustel on funktsioon üldse määratud. Näiteks 1/x puhul jäetakse välja punkt x = 0, sqrt(x) puhul ainult x ≥ 0.

Leiab nullkohad — lahendatakse võrrand f(x) = 0 ja kuvatakse kõik leitud lahendid.

Arvutab tuletise — rakendus leiab sümboolselt tuletise f'(x) ja näitab seda kasutajale eraldi väljana.

Leiab kriitilised punktid — lahendatakse võrrand f'(x) = 0.

2. Kasutatud tehnoloogiad
Komponent	Tehnoloogia
Keel	C#
Raamistik	ASP.NET Core MVC
.NET versioon	.NET 10
Sümbolarvutus	MathNet.Symbolics
Andmebaas	SQLite
ORM	Entity Framework Core
3. Nõuded ja ettevalmistus
Enne käivitamist veendu, et sinu arvutis on olemas:

.NET 10 SDK

Git — repositooriumi kloonimiseks

Brauser — Chrome, Edge või Firefox

Koodiredaktor

Kontrolli .NET versiooni terminalis:

bash
dotnet --version
Kui kuvatakse 10.x.x — on kõik korras.

4. Rakenduse käivitamine
4.1. Repositooriumi kloonimine
bash
git clone https://github.com/[kasutaja]/FunktsiooniUurimine.git
cd FunktsiooniUurimine
4.2. Sõltuvuste taastamine
bash
dotnet restore
4.3. Rakenduse käivitamine
bash
dotnet run
4.4. Avamine brauseris
Terminal prindib välja aadressi.

Ava üks neist brauseris.

5. Mida igal lehel teha
5.1. Avaleht /
Avaleht on rakenduse sisenemispunkt. Siin näed lühikest kirjeldust ja linke põhisektsioonidesse. Tavaliselt on kaks peamist nuppu:

„Lisa uus funktsioon“ — viib sisestusvormile

5.2. Funktsioonide nimekiri
Siin kuvatakse tabel kõigist andmebaasis olevatest funktsioonidest. Iga rea kohta on näha vähemalt:

funktsiooni valem,

tegevusnupud.

Iga rea juures on kolm nuppu:

Details — avab detailvaate, kus on kogu analüüs ja graafik

Edit — avab muutmisvormi

Delete — kustutab kirje

Tabeli kohal on nupp „Lisa uus“, mis viib sisestusvormile.

5.3. Uue funktsiooni lisamine
See on kõige olulisem leht testimise seisukohast. Vormil on üks sisestusväli — valem.

Samm-sammult:

Klõpsa nupul „Lisa uus“.

Sisesta valem muutuja x suhtes. Näiteks:

x^3 - 6*x + 3

x^2 - 4*x + 3

sin(x)

1/x

Vajuta „Salvesta“.

5.4. Detailvaade
Siin näed kõike, mida rakendus on sisestatud valemi kohta arvutanud. Leht peaks sisaldama:

sisestatud valemit,

määramispiirkonda — millistel x väärtustel on funktsioon määratud,

nullkohti — kõiki lahendeid f(x) = 0,

tuletist f'(x) — sümboolsel kujul.

5.5. Muutmine
Sama vorm kui lisamisel, ainult väljad on eeltäidetud. Pärast muudatuse salvestamist:

Kontrolli, et uus valem oleks nimekirjas ja detailvaates näha.

5.6. Kustutamine
Kustutamise juures peaks rakendus küsima kinnitust (jah/ei). Pärast kustutamist:

kirje ei tohi olla nimekirjas.
