# IPTools | [中文文档](README_zh-CN.md)
Quickly query IP information, support domestic and foreign IP information query, support query latitude and longitude, and support geographical location to the city.

IPTools.China: [![nuget](https://img.shields.io/nuget/v/IPTools.China.svg?style=flat-square)](https://www.nuget.org/packages/IPTools.China/)

IPTools.International: [![nuget](https://img.shields.io/nuget/v/IPTools.International.svg?style=flat-square)](https://www.nuget.org/packages/IPTools.International/)

## 1. IPTools.China

Quickly query China IP information, country, province, city and network operators. Non China IP can only query national information.

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

### (3) I18N

Not support . So you can't use `IpTool.SearchWithI18NAsync()`.

### (4) performance testing

Single thread double for loop queries 65025 IP, takes 170 ms.

## 2. IPTools.International

Quickly query global IP information, support i18n, country, province, city, post code, longitude and latitude. 

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

### (3) I18N

````csharp
IpTool.SearchWithI18N("your ip address");
````

eg.

````csharp
var ipinfo = IpTool.SearchWithI18N("171.210.12.163","en");//If language code is not set, Chinese will be used by default.
Console.WriteLine(ipinfo.Country); // China
Console.WriteLine(ipinfo.CountryCode); // CN
Console.WriteLine(ipinfo.Province); // Sichuan
Console.WriteLine(ipinfo.ProvinceCode); // SC
Console.WriteLine(ipinfo.City); // Chengdu
Console.WriteLine(ipinfo.Latitude); // 30.6667
Console.WriteLine(ipinfo.Longitude); // 104.6667
Console.WriteLine(ipinfo.AccuracyRadius);// 50
````

Default language is chinese(zh-CN), How to change?

````csharp
IpToolSettings.DefaultLanguage = "en";// set default language is english.
````

### (4) performance testing

Single thread double for loop queries 65025 IP, takes 1500 ms.

## 3. ASP.NET Core Support

IPTools provides an extension method for `HttpContext`.

usage:

````csharp
HttpContext.GetRemoteIpInfo();
HttpContext.GetRemoteIpInfo(headerKey); // Get ip from header if you use nginx, haproxy etc.
````

## 4. Use both IPTools.China and IPTools.International

Both IPTools.China and IPTools.International implement `IIpSearcher`. The `IpTool` class will detect the package you installed during initialization and initialize it only once. `IpTool` has three static read-only properties, namely `DefaultSearcher`, `IpChinaSearcher`, `IpAllSearcher`.

- `DefaultSearcher`. `IpTool.Search()` and `IpTool.SearchWithI18N()` will use the default Ip searcher.
- `IpChinaSearcher`. IPTools.China Implemented searcher.
- `IpAllSearcher`. IPTools.International Implemented searcher.

If you just installed IPTools.China then `DefaultSearcher` will be `IpChinaSearcher` and `IpAllSearcher` will be null.

If you just installed IPTools.International then `DefaultSearcher` will be `IpAllSearcher` and `IpChinaSearcher` will be null.

If you have both components installed at the same time, by default `DefaultSearcher` will be `IpChinaSearcher`, `IpChinaSearcher` and `IpAllSearcher` will not be null.

To change the default Searcher used by `DefaultSearcher`, please use the following code, if you have two components installed at the same time, it will take effect.

```csharp
IpToolSettings.DefalutSearcherType = IpSearcherType.China;
IpToolSettings.DefalutSearcherType = IpSearcherType.International;
```

## 5. Referencing project

[**ip2region**](https://github.com/lionsoul2014/ip2region) by [lionsoul2014](https://github.com/lionsoul2014).

[**GeoIP2-dotnet**](https://github.com/maxmind/GeoIP2-dotnet) by [maxmind](https://github.com/maxmind).