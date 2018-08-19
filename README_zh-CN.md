# IPTools
快速查询IP信息，支持国内和国外IP信息查询，支持查询经纬度，地理位置最高支持到城市。

## 1. IPTools.China

快速查询中国IP地址信息，包含国家、省份、城市、和网络运营商。非中国IP只支持查询国家。

### (1) 安装

````shell
Install-Package IPTools.China
````

### (2) 使用

````shell
IpTool.Search("你的ip地址");
````

示例.

````csharp
var ipinfo = IpTool.Search("171.210.12.163");
Console.WriteLine(ipinfo.Country); // 中国
Console.WriteLine(ipinfo.Province); // 四川省
Console.WriteLine(ipinfo.City); // 成都市
Console.WriteLine(ipinfo.NetworkOperator);// 电信
````

### (3) 异步使用

````shell
await IpTool.Searcher.SearchAsync("你的ip地址")
````

### (4) 国际化

不支持国际化，如果你是用 `IpTool.Searcher.SearchWithI18NAsync()`
& `IpTool.Searcher.SearchWithI18N()  `方法，将会发生异常。

### (5) 性能测试

单线程，双重for循环，查询65025个IP，花费190毫秒。

## 2. IPTools.International

快速查询全球IP信息，支持多语言，但是不支持异步调用，地理信息包括国家、省份、城市、邮政编码、纬度和精度。

### (1) 安装

```shell
Install-Package IPTools.International
```

### (2) 使用

````csharp
IpTool.Search("你的ip地址");
````

示例.

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

### (3) 异步使用

不支持异步使用，如果你使用`IpTool.Searcher.SearchWithI18NAsync()`
& `IpTool.Searcher.SearchAsync()  `方法，将会发生异常。

### (4) 国际化

````csharp
IpTool.SearchWithI18N("你的ip地址");
````

示例.

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

默认语言为中文，如何改变？使用下面的代码进行设置。中文为 `zh-CN`，英文为`en`

````csharp
IpToolSettings.DefaultLanguage = "en";
````

### (5) 性能测试

单线程，双重for循环，查询65025个IP，花费1500毫秒。

## 3. ASP.NET Core 支持

IPTools 提供了 `HttpContext`对象的扩展方法。

使用:

````csharp
HttpContext.GetRemoteIpInfo();
HttpContext.GetRemoteIpInfo(headerKey); // 从请求头获取ip地址信息，如果你使用了nginx、haproxy等代理
````

## 4. 使用的开源项目

[**ip2region**](https://github.com/lionsoul2014/ip2region) by [lionsoul2014](https://github.com/lionsoul2014).

[**GeoIP2-dotnet**](https://github.com/maxmind/GeoIP2-dotnet) by [maxmind](https://github.com/maxmind).