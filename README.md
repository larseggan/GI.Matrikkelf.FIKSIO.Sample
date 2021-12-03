# GI.Matrikkelf.FIKSIO.Sample
Eksempel på oppretting og mottak av melding for matrikkelføring fra eByggesak vha. FIKS-IO.
Dette bygger på versjon 2 av standarden: https://ks-no.github.io/fiks-plattform/tjenester/fiksio/matrikkelfoering/

Les mer om FIKS IO her: https://ks-no.github.io/fiks-plattform/tjenester/fiksio/


Deh gamle versjonen som benytter Svarut/SvarInn (versjon 1) eksempel kan du finne her: https://github.com/ks-no/Geointegrasjon.Matrikkelf-ring.Sample

Funksjonalitet
--------------

Eksemplet `SendSample` sender meldinger med forsendelsestype 
`Geointegrasjon.Matrikkelføring`, slik at de kan plukkes opp av mottakstjenesten  som lytter på dette. Meldingen sendes med egenskapen "kun digital levering", slik 
at den ikke går videre til brevpost ved manglende henting.  Det blir sendt 
meldinger med ulike nivåer av klarhet for matrikkelføring, fra nivå 0 (det har 
skjedd et vedtak) til nivå 4 (full situasjonsplan). Se koden for nærmere info om 
hva som gjøres i hvert nivå. Dette eksempelet tilsvarer altså det arbeidet som 
skal gjøres i eByggeSak-systemet for å sende meldinger til matrikkelklienten.

Når du har sendt meldinger vil de IKKE være synlige slik som i Svarut/SvarInn, men det er laget en WinForms applikasjon med en enkel visning som kan benyttes.

Eksempelet `ReceiveSample` er en mottakstjeneste som lytter på slike meldinger. 
Den henter ut listen over mottatte meldinger, laster ned innholdet og dekrypterer 
det, og sender kvittering på at innholdet er korrekt mottatt. Dette eksempelet tilsvarer altså det arbeidet som skal gjøres i matrikkelklienten/automatisert 
matrikkeoppdateringstjeneste for å ta imot informasjonen og bekrefte at 
matrikkelføring er utført.

Det er benyttet nuget-pakken: https://github.com/ks-no/fiks-io-client-dotnet\

Konfigurasjon
-------------

Koden krever noen private nøkler som du må hente ut fra https://forvaltning.fiks.test.ks.no/

For at ikke de skal havne ut i kildekontroll, legges de i filen 
LocalSettings.config, som er referert fra csproj-filene men lagt inn i .gitignore. 
Du må kopiere LocalSettings.default.config og omdøpe den, og deretter legge inn verdiene.

Sertifikat
-------------

Man må ha et sertifikat f.eks. et buypass sertifikat.
Dette må konverteres til et Microsoft Enhanced RSA and AES Cryptographic Provider.
Eksempel der det inne i <> må fylles ut av hver enkelt:
certutil  -p \<passord> -csp "Microsoft Enhanced RSA and AES Cryptographic Provider" -v  -importPFX "Buypass ID-\<firma>-\<serienummer>.p12" AT_KEYEXCHANGE,NoExport,NoProtect



