# VehicleCardSystemStudy
Bu proje, ara� kay�t ve takip sistemini i�eren katmanl� web uygulamas�d�r.


Kullan�lan Teknolojiler

.NET 8 (ASP.NET Core MVC )

Entity Framework Core (Code-First yakla��m�) 

Katmanl� Mimari

Asynchronous REST API 

Bootstrapile UI 

Fluent Validation

Visual Studio 2022




Katmanlar

Proje, 4 ana katmana ayr�lm��t�r:

VehicleCardSystem.Core: Uygulaman�n domain modellerini (Entity'leri) i�erir. (Vehicle, VehicleType)

VehicleCardSystem.Data: DbContext ve Migration i�lemleri burada tan�mlanmd�.

VehicleCardSystem.Service: RESTful API controller'lar�, servis s�n�flar� ve IService aray�zleri burada yer al�r.

VehicleCardSystem.Web: Kullan�c� aray�z� (UI) bu katmandad�r. MVC Controller ve View�lar bulunur. API ile haberle�erek kullan�c�ya g�rsel aray�z sa�lar. 




Modeller

VehicleType: Brand, Model, Capacity (KG), Capacity (M3)

Vehicle: Plate, Type, Model Year, Color




�zellikler

EF Core ile Code-First altyap� kuruldu.

Ara� ve ara� tipi (Vehicle, VehicleType) CRUD i�lemleri.

Katmanl� mimari uyguland� (Web, Service, Data, Core)

Katmanl� yap� sayesinde loosely coupled (gev�ek ba�l�) mimari.

API Controller�lar ayr� katmanda olu�turuldu.

T�m CRUD i�lemleri hem UI hem API taraf�nda ayr� ayr� kodland�.

Asenkron API i�lemleri.

Aray�z �zerinden API ile tam ileti�im.

Validations.

AsNoTracking() ile performans optimizasyonu sa�land�.

Vehicle ve VehicleType i�in UI'da form kontrolleri ve do�rulamalar yap�ld�.




�al��t�rma

Visual Studio ile a��n.

Update-Database komutu ile veritaban�n� olu�turun.

VehicleCardSystem.Services ve VehicleCardSystem.Web projelerini birlikte �al��t�r�n.(Multiple startup project)

UI �zerinden ara� ve ara� tipi i�lemlerini ger�ekle�tirin.

Proje referanslar�n� kontrol edin olas� hatalar�n �n�ne ge�mek i�in �nemlidir. Katmanl� mimari yap�s� gere�i projeler aras� referanslar mevcuttur.
