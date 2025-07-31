# VehicleCardSystemStudy
Bu proje, araç kayýt ve takip sistemini içeren katmanlý web uygulamasýdýr.


Kullanýlan Teknolojiler

.NET 8 (ASP.NET Core MVC )

Entity Framework Core (Code-First yaklaþýmý) 

Katmanlý Mimari

Asynchronous REST API 

Bootstrapile UI 

Fluent Validation

Visual Studio 2022




Katmanlar

Proje, 4 ana katmana ayrýlmýþtýr:

VehicleCardSystem.Core: Uygulamanýn domain modellerini (Entity'leri) içerir. (Vehicle, VehicleType)

VehicleCardSystem.Data: DbContext ve Migration iþlemleri burada tanýmlanmdý.

VehicleCardSystem.Service: RESTful API controller'larý, servis sýnýflarý ve IService arayüzleri burada yer alýr.

VehicleCardSystem.Web: Kullanýcý arayüzü (UI) bu katmandadýr. MVC Controller ve View’lar bulunur. API ile haberleþerek kullanýcýya görsel arayüz saðlar. 




Modeller

VehicleType: Brand, Model, Capacity (KG), Capacity (M3)

Vehicle: Plate, Type, Model Year, Color




Özellikler

EF Core ile Code-First altyapý kuruldu.

Araç ve araç tipi (Vehicle, VehicleType) CRUD iþlemleri.

Katmanlý mimari uygulandý (Web, Service, Data, Core)

Katmanlý yapý sayesinde loosely coupled (gevþek baðlý) mimari.

API Controller’lar ayrý katmanda oluþturuldu.

Tüm CRUD iþlemleri hem UI hem API tarafýnda ayrý ayrý kodlandý.

Asenkron API iþlemleri.

Arayüz üzerinden API ile tam iletiþim.

Validations.

AsNoTracking() ile performans optimizasyonu saðlandý.

Vehicle ve VehicleType için UI'da form kontrolleri ve doðrulamalar yapýldý.




Çalýþtýrma

Visual Studio ile açýn.

Update-Database komutu ile veritabanýný oluþturun.

VehicleCardSystem.Services ve VehicleCardSystem.Web projelerini birlikte çalýþtýrýn.(Multiple startup project)

UI üzerinden araç ve araç tipi iþlemlerini gerçekleþtirin.

Proje referanslarýný kontrol edin olasý hatalarýn önüne geçmek için önemlidir. Katmanlý mimari yapýsý gereði projeler arasý referanslar mevcuttur.
