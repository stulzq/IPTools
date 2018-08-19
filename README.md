# IPTools
Querying IP address information.

## 1. IPTools.China

Quickly query China IP information, national, provincial, city and network operators. Non China IP can only query national information.

### (1) Install

````shell
Install-Package IPTools.China
````

### (2) Usage

````shell
IpTool.Search("your ip address");
````

eg.

````csharp
var ipinfo = IpTool.Search("171.210.12.163");
Console.WriteLine(ipinfo.Country); // 中国
Console.WriteLine(ipinfo.Province); // 四川省
Console.WriteLine(ipinfo.City); // 成都市
Console.WriteLine(ipinfo.NetworkOperator);// 电信
````

### (3) Async Usage

````shell
await IpTool.Searcher.SearchAsync("your ip address")
````

### (4) I18N

No support for I18N. If you use  `IpTool.Searcher.SearchWithI18NAsync()`
& `IpTool.Searcher.SearchWithI18N()  `will get a exception.

### (5) performance testing

Single thread double for loop queries 65025 IP, takes 190 ms time.

## 2. IPTools.International

### (1) Install

```shell
Install-Package IPTools.International
```

### (2) Usage

````csharp
IpTool.Search("your ip address");
````

eg.

````csharp
var ipinfo = IpTool.Search("171.210.12.163");
Console.WriteLine(ipinfo.Country); // China
Console.WriteLine(ipinfo.CountryCode); // CN
Console.WriteLine(ipinfo.Province); // Sichuan
Console.WriteLine(ipinfo.ProvinceCode); // SC
Console.WriteLine(ipinfo.City); // Chengdu
Console.WriteLine(ipinfo.Latitude); // 30.6667
Console.WriteLine(ipinfo.Longitude); // 104.6667
Console.WriteLine(ipinfo.AccuracyRadius);// 50
````

### (3) Async Usage

No support. If you use  `IpTool.Searcher.SearchWithI18NAsync()`
& `IpTool.Searcher.SearchAsync()  `will get a exception.

### (4) I18N

````csharp
IpTool.SearchWithI18N("your ip address");
````

eg.

````csharp
var ipinfo = IpTool.SearchWithI18N("171.210.12.163");
Console.WriteLine(ipinfo.Country); // 中国
Console.WriteLine(ipinfo.CountryCode); // CN
Console.WriteLine(ipinfo.Province); // 四川省
Console.WriteLine(ipinfo.ProvinceCode); // SC
Console.WriteLine(ipinfo.City); // 成都
Console.WriteLine(ipinfo.Latitude); // 30.6667
Console.WriteLine(ipinfo.Longitude); // 104.6667
Console.WriteLine(ipinfo.AccuracyRadius);// 50
````

Default language is chinese(zh-CN), How to change?

````csharp
IpToolSettings.DefaultLanguage = "en";
````

## 3. ASP.NET Core Support

IPTools provides an extension method for `HttpContext`.

usage:

````csharp
HttpContext.GetRemoteIpInfo();
HttpContext.GetRemoteIpInfo(headerKey); // Get ip from header if you use nginx, haproxy etc.
````

## 4. Referencing project

[**ip2region**](https://github.com/lionsoul2014/ip2region) by [lionsoul2014](https://github.com/lionsoul2014).

[**GeoIP2-dotnet**](https://github.com/maxmind/GeoIP2-dotnet) by [maxmind](https://github.com/maxmind).