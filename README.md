# ReCaptcha.NET #

**ReCaptcha.NET** provides a .NET wrapper library for Google's [reCaptcha](https://www.google.com/recaptcha).


## Package Status ##

* [NuGet](https://nuget.org) Package Status:
  * **Aliencube.ReCaptcha.NET**: [![](https://img.shields.io/nuget/v/Aliencube.ReCaptcha.NET.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) [![](https://img.shields.io/nuget/dt/Aliencube.ReCaptcha.NET.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/)
  * **Aliencube.ReCaptcha.NET.MVC**: [![](https://img.shields.io/nuget/v/Aliencube.ReCaptcha.NET.MVC.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/) [![](https://img.shields.io/nuget/dt/Aliencube.ReCaptcha.NET.MVC.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/)
* [AppVeyor](https://appveyor.com) Build Status: [![Build status](https://ci.appveyor.com/api/projects/status/i5ife0np7indhdiu?svg=true)](https://ci.appveyor.com/project/justinyoo/recaptcha-net)


## Getting Started ##

In order to use **ReCaptcha.NET** in your apps, you should get the [**Aliencube.ReCaptcha.NET**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) package as a minimum. The following section shows how this is used in ASP.NET MVC apps.


### ASP.NET MVC ###

In order to use **ReCaptcha.NET** in your [ASP.NET MVC](https://asp.net/mvc) apps, on top of the [**Aliencube.ReCaptcha.NET**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) package, you should get the [**Aliencube.ReCaptcha.NET.MVC**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/) package. Then add the following into your Razor view script:

```csharp
@using (Html.BeginForm(MVC.Home.ActionNames.Index, MVC.Home.Name, FormMethod.Post))
{
  ...

  @Html.ReCaptcha(new Dictionary<string, object>() { { "class", "[class names]" }, { "data-sitekey", Model.SiteKey } })

  ...
}

@section Scripts
{
  @Html.ReCaptchaApiJs(new Dictionary<string, object>() { { "src", Model.ApiUrl } })
}
```

* `@Html.Recaptcha()` renders the reCaptcha control.
* `@Html.ReCaptchaApiJs()` renders JavaScript for the reCaptcha control.

In order to handle this reCaptcha control in your controllers, take a look at the following:

```csharp
[HttpPost]
public virtual async Task<ActionResult> Index(HomeIndexViewModel form)
{
  var result = await this._reCaptcha.SiteVerifyAsync(this._settings, this.Request.Form, this.Request.ServerVariables);

  var vm = form;
  vm.Success = result.Success;
  vm.ErrorCodes = result.ErrorCodes;
  return View(vm);
}
```

* `ReCaptchaV2.SiteVerifyAsync()` takes parameters of `ReCaptchaV2Settings`, `Form` and `ServerVariables` and returns the result.


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work, please send us a pull request onto our `dev` branch for review.


## License ##

**ReCaptcha.NET** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2015 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
