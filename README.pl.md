<p align="center">
  <img src="lumizoom-logo-horizontal.svg" alt="LumiZoom" width="520">
</p>

# LumiZoom

**Polski** · [English](README.md)

LumiZoom to bezpłatna lupa ekranowa typu live zoom dla systemu Windows, udostępniana jako otwarte oprogramowanie. Powstała przede wszystkim z myślą o osobach niedowidzących i starszych użytkownikach komputera, którzy potrzebują prostego powiększania całego pulpitu bez stale widocznego okna lupy.

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
- obsługa z zasobnika systemowego i opcjonalny autostart;
- awaryjne wyłączenie powiększenia klawiszem `Esc`;
- zabezpieczenie przed uruchomieniem kilku kopii programu.

## Pobieranie

Najnowszy instalator znajduje się na stronie [Releases](https://github.com/lumizoom-project/LumiZoom/releases). Windows może ostrzegać przed wczesnymi wydaniami bez publicznie zaufanego podpisu. Instalator RC tworzy lokalnie zaufany certyfikat wymagany przez Windows UIAccess, dzięki czemu kliknięcia myszy są poprawnie mapowane podczas powiększenia.

## Wymagania

- Windows 10 lub Windows 11, 64-bit;
- .NET 8 Desktop Runtime;
- uprawnienia administratora podczas instalacji.

Windows 7 nie jest obsługiwany przez obecną platformę aplikacji i używany interfejs powiększania wejścia.

## Domyślny skrót

`Ctrl + Alt + Shift + 9`

Można go zmienić w **Ustawienia → Główna**.

## Budowanie ze źródeł

1. Zainstaluj .NET 8 SDK.
2. Uruchom `dotnet build LumiZoom.csproj -c Release`.
3. Aby zbudować instalator Windows, zainstaluj Inno Setup 6 i skompiluj `LumiZoom.iss`.

## Prywatność

LumiZoom nie zawiera telemetrii, analityki, reklam ani obowiązkowych kont internetowych. Zobacz [Politykę prywatności](PRIVACY.pl.md).

## Autor i kontakt

Autor: **Łukasz Kuczek**.  
Kontakt: [lumizoom.project@gmail.com](mailto:lumizoom.project@gmail.com)

## Licencja

LumiZoom jest udostępniany na zasadach [licencji MIT](LICENSE).

