# GI.Matrikkelf.FIKSIO.Sample
Eksempel på oppretting og mottak av melding for matrikkelføring fra eByggesak vha. FIKS-IO.
Dette bygger på versjon 2 av standarden: https://ks-no.github.io/fiks-plattform/tjenester/fiksio/matrikkelfoering/

Svarut/SvarInn versjon1 eksempel kan du finne her: https://github.com/ks-no/Geointegrasjon.Matrikkelf-ring.Sample

Konfigurasjon
-------------

Koden krever noen private nøkler som du må hente ut fra https://forvaltning.fiks.test.ks.no/![image](https://user-images.githubusercontent.com/11415599/143021295-76ac8523-f10d-43e8-b528-ae5dfc3adf07.png)


For at ikke de skal havne ut i kildekontroll, legges de i filen 
LocalSettings.config, som er referert fra csproj-filene men lagt inn i .gitignore. 
Du må kopiere LocalSettings.default.config og omdøpe den, og deretter legge inn verdiene.
