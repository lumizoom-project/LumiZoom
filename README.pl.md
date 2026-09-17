<p align="center">
  <img src="lumizoom-logo-horizontal.svg" alt="LumiZoom" width="520">
</p>

# LumiZoom

**Polski** · [English](README.md)

LumiZoom to bezpłatna lupa ekranowa typu live zoom dla systemu Windows, udostępniana jako otwarte oprogramowanie. Powstała przede wszystkim z myślą o osobach niedowidzących i starszych użytkownikach komputera, którzy potrzebują prostego powiększania całego pulpitu bez stale widocznego okna lupy.

## Lupa ekranowa stworzona z myślą o codziennej dostępności

Niektóre narzędzia do powiększania ekranu są projektowane głównie z myślą o prezentacjach. Podczas codziennej pracy menu Windows może zostać powiększone drugi raz, przez co staje się trudne do odczytania i obsługi. LumiZoom powstał z myślą o osobach niedowidzących, które potrzebują wygodnej lupy do pracy przy komputerze. Zapewnia spójne powiększenie pulpitu, tak aby menu Start i pozostałe menu systemowe pozostawały czytelne.

## Najważniejsze możliwości

- płynne włączanie i wyłączanie powiększenia całego ekranu;
- ustalany poziom powiększenia;
- śledzenie kursora z opcją utrzymywania go na środku;
- regulowana szybkość śledzenia i czas animacji;
- opcjonalne kolorowe podświetlenie kursora z wyborem koloru i przezroczystości;
- zmieniany globalny skrót klawiaturowy;
- motyw jasny, ciemny albo zgodny z systemem;
- trzy wielkości czcionki interfejsu;
- wielojęzyczny interfejs;
- obsługa z zasobnika systemowego i domyślnie włączony autostart;
- awaryjne wyłączenie powiększenia klawiszem `Esc`;
- zabezpieczenie przed uruchomieniem kilku kopii programu.

## Zrzuty ekranu

Poniższe zrzuty pokazują angielską wersję okna ustawień — skupiają się na aplikacji, a nie na całym pulpicie.

<p align="center">
  <img src="store-listing/en-US/1366px/01-main.png" alt="Główne ustawienia powiększenia" width="48%">
  <img src="store-listing/en-US/1366px/02-cursor.png" alt="Ustawienia podświetlania kursora" width="48%">
</p>
<p align="center">
  <img src="store-listing/en-US/1366px/03-program.png" alt="Ustawienia programu i uruchamiania" width="48%">
  <img src="store-listing/en-US/1366px/04-appearance.png" alt="Ustawienia wyglądu" width="48%">
</p>
<p align="center">
  <img src="store-listing/en-US/1366px/05-about.png" alt="Informacje o LumiZoom" width="48%">
</p>

## Pobieranie

### [Pobierz najnowsze wydanie LumiZoom dla Windows 10/11 (64-bit)](https://github.com/lumizoom-project/LumiZoom/releases/latest)

Zalecany instalator jest samowystarczalny i nie wymaga osobnej instalacji .NET.

- [Najnowsze wydanie i instalator](https://github.com/lumizoom-project/LumiZoom/releases/latest)
- [Wszystkie wydania i starsze wersje](https://github.com/lumizoom-project/LumiZoom/releases)
- [Sumy kontrolne SHA-256](dist/SHA256SUMS.txt)

Windows może ostrzegać przed wczesnymi wydaniami bez publicznie zaufanego podpisu. Instalator tworzy lokalnie zaufany certyfikat wymagany przez Windows UIAccess, dzięki czemu kliknięcia myszy są poprawnie mapowane podczas powiększenia.

## Polityka podpisywania kodu

Wydania są budowane z kodu źródłowego i skryptów budowania znajdujących się w tym repozytorium. Tagi wydań i sumy kontrolne publikujemy na GitHubie. Do czasu uzyskania publicznie zaufanego certyfikatu podpisu Windows może wyświetlać ostrzeżenie SmartScreen dla pobranych instalatorów. LumiZoom nie wymaga wyłączania zabezpieczeń Windows. Pytania dotyczące podpisu można zgłaszać w [GitHub Issues](https://github.com/lumizoom-project/LumiZoom/issues).

## Wymagania

- Windows 10 lub Windows 11, 64-bit;
- uprawnienia administratora podczas instalacji.

Instalator jest samowystarczalny i nie wymaga osobnej instalacji środowiska .NET.

Windows 7 nie jest obsługiwany przez obecną platformę aplikacji i używany interfejs powiększania wejścia.

## Domyślny skrót

`Ctrl + Alt + Shift + 9`

Można go zmienić w **Ustawienia → Główna**.

## Budowanie ze źródeł

1. Zainstaluj .NET 8 SDK.
2. Uruchom `dotnet publish LumiZoom.csproj -c Release -r win-x64 --self-contained true`.
3. Aby zbudować instalator Windows, zainstaluj Inno Setup 6 i skompiluj `LumiZoom.iss`.

## Prywatność

LumiZoom nie zawiera telemetrii, analityki, reklam ani obowiązkowych kont internetowych. Zobacz [Politykę prywatności](PRIVACY.pl.md).

## Autor i kontakt

Autor: **Łukasz Kuczek**.  
Kontakt: [lumizoom.project@gmail.com](mailto:lumizoom.project@gmail.com)

## Licencja

LumiZoom jest udostępniany na zasadach [licencji MIT](LICENSE).
