# Szoftvertervezés és -fejlesztés II. tantárgy féléves feladata.

## Feladat leírása:

	Vatera-szerű online vásárlási felületet szeretnénk készíteni. A rendszerrel szemben elvárás, hogy
	különféle termékeket és szolgáltatásokat tudjon kezelni, azok között gyors keresésre legyünk
	képesek, és segítséget nyújtson az eladásra kínált termékek vásárlók közötti kiosztásában is.
	
	Készítse el a szükséges osztályokat:
	
		Legyen egy ITranzakciókbanRésztvevő interfész, amely Adószám, Kontaktszemély, Értékelés
		(1-5) és Terméklista tulajdonságok megvalósítását írja elő. Az Eladó és a Vásárló osztályok
		valósítsák meg ezt az interfészt.
		
		Legyen egy tetszőleges osztályhierarchia eladókhoz és vásárlókhoz is. Pl. eladó és vásárló is
		lehet magánszemély vagy jogi személy, a jogi személyen belül is vannak elemek. Nem
		feltétlenül kell hogy az eladók és vásárlók pontosan ugyanolyan típusú elemek lehessenek.
		Valósítsa meg lehetőleg különbözőképpen az ITranzakciókbanRésztvevő által előírt
		tulajdonságokat (pl. magánszemély Kontaktszemélye biztosan nem más, mint ő maga; eladók
		esetében az értékelés az eladott termékek számától függjön, stb.)
		
		Legyenek Termékek. Az eladókban láncolt listában legyenek tárolva az általuk eladásra kínált
		Termékek, a vásárlókban pedig az általuk megvásárolt termékek. A Termékek valósítsák meg
		az IComparable interfészt név szerinti rendezés céljából.
		
	Ezután készítse el az árukezelő rendszert, amely a következőképpen épüljön fel:
		
		A rendszerbe lehessen eladókat és vásárlókat regisztrálni. Mindkettőt láncolt listában tárolja
		rendszer.
		
		Lehessen regisztrálni az eladókhoz új termékeket – a rendszer dobjon kivételt, hogyha olyan
		eladóhoz akarunk terméket regisztrálni, aki nem szerepel az eladólistában. Legyen lehetőség
		az összes eladó áru kilistázására.
		
		A vevők tudjanak megvenni termékeket eladóktól (tetszőleges módon). Ekkor a termék
		kerüljön át az eladók listájából az ő listájukba.
		
		Biztosítsunk a rendszerben funkciót arra, hogy a sok terméket megvásárló vevőket jutalmazni
		tudjuk. Időnként meghatározott mennyiségű ajándékot (Terméket) akarunk közöttük
		kiosztani ingyen. Minden vevőnek pontosan annyi darab Terméket adunk, amennyi az
		értékelése. Osszuk szét a vevők között a Termékeket úgy, hogy lehetőleg azoknak adjunk,
		akik a legtöbb terméket vásárolták meg eladásra, és a lehető legjobban megközelítsük a
		kiosztható ajándékmennyiséget! Dobjunk kivételt, ha nem sikerült az összes ajándék
		kiosztása. Jelezzük eseménnyel, ha egy vásárló ajándékot kapott. 

## Program használata:

	Az eladoLista.txt és vevoLista.txt fajlokba az alábbiak szerint kell feltölteni tagokat:

		Feltöltés fájlba Magánszemély esetén: (formátum: 0,név,adószám)
		pl	0;Ostoros Bela;3333

		Feltöltés fájlba KFT esetén: (formátum: 1,név,kapcsolattarto neve,adószám)
		pl	1;Media Markt;1234;Halasz Zsuzsa;1987

		Feltöltés fájlba ZRT esetén: (formátum: 2,név,kapcsolattarto neve,adószám)
		pl	2;Media Markt;1234;Halasz Zsuzsa;1987

	A termekLista.txt nevű fájlba az alábbiak szerint kell feltölteni:

		Feltöltés fájlba Termek esetén: (formátum: név,ár,adószám)
		pl	Fenykepezogep;60000;1234

	Ahhoz, hogy működjön az Ajándékozás funkció, előbb a Vásárlás funkcióval meg kell venni legalább egy terméket.