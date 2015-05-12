# ReCaptcha.NET #

**ReCaptcha.NET** provides a .NET wrapper library for Google's [reCaptcha](https://www.google.com/recaptcha).


## NuGet Package Status ##

| **Aliencube.ReCaptcha.NET** | **Aliencube.ReCaptcha.NET.MVC** |
|:---------------------------:|:-------------------------------:|
| [![](https://img.shields.io/nuget/v/Aliencube.ReCaptcha.NET.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) [![](https://img.shields.io/nuget/dt/Aliencube.ReCaptcha.NET.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) | [![](https://img.shields.io/nuget/v/Aliencube.ReCaptcha.NET.MVC.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/) [![](https://img.shields.io/nuget/dt/Aliencube.ReCaptcha.NET.MVC.svg)](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/) |


## Build Status ##

| `master` | `dev` | `release` |
|:--------:|:-----:|:---------:|
| [![Build status](https://ci.appveyor.com/api/projects/status/i5ife0np7indhdiu/branch/master?svg=true)](https://ci.appveyor.com/project/justinyoo/recaptcha-net/branch/master) | [![Build status](https://ci.appveyor.com/api/projects/status/i5ife0np7indhdiu/branch/dev?svg=true)](https://ci.appveyor.com/project/justinyoo/recaptcha-net/branch/dev) | [![Build status](https://ci.appveyor.com/api/projects/status/i5ife0np7indhdiu/branch/release?svg=true)](https://ci.appveyor.com/project/justinyoo/recaptcha-net/branch/release) |


## Getting Started - Basic Usage ##

In order to use **ReCaptcha.NET** in your apps, you should get the [**Aliencube.ReCaptcha.NET**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) package as a minimum. The following section shows how this is used in ASP.NET MVC apps.

For your [ASP.NET MVC](https://asp.net/mvc) apps, you should get the [**Aliencube.ReCaptcha.NET.MVC**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET.MVC/) package, on top of the [**Aliencube.ReCaptcha.NET**](https://www.nuget.org/packages/Aliencube.ReCaptcha.NET/) package.

Then add the following into your Razor view script:

```csharp
@using (Html.BeginForm(MVC.Home.ActionNames.Basic, MVC.Home.Name, FormMethod.Post))
{
  ...

  @Html.ReCaptcha(Model.SiteKey,
                  new { @class = "class1 class2" })

  ...
}

@section Scripts
{
  @Html.ReCaptchaApiJs(Model.ApiUrl)
}
```

* `@Html.Recaptcha()` renders the reCaptcha control.
* `@Html.ReCaptchaApiJs()` renders JavaScript for the reCaptcha control.
* More details can be found on [Basic.cshtml](https://github.com/aliencube/ReCaptcha.NET/blob/master/SourceCodes/02_Apps/ReCaptcha.Wrapper.WebApp/Views/Home/Basic.cshtml) as an example.


## Advanced Usage ###

Using the `RenderParameters` class gives your more control. Properties in the `RenderParameters` class can be found at: [https://developers.google.com/recaptcha/docs/display#render_param](https://developers.google.com/recaptcha/docs/display#render_param).

```csharp
@using (Html.BeginForm(MVC.Home.ActionNames.Advanced, MVC.Home.Name, FormMethod.Post))
{
  ...

  @Html.ReCaptcha(new RenderParameters() { SiteKey = Model.SiteKey, Theme = RenderThemeType.Dark },
                  new { @class = "form-group" })

  ...
}
```

Rendering `api.js` can be asynchronous. For this, you can add `ApiJsRenderingOptions` enum like:

```csharp
@section Scripts
{
  @Html.ReCaptchaApiJs(Model.ApiUrl, ApiJsRenderingOptions.Async | ApiJsRenderingOptions.Defer)
}
```

* `@Html.Recaptcha()` renders the reCaptcha control.
* `@Html.ReCaptchaApiJs()` renders JavaScript for the reCaptcha control.
* More details can be found on [Advanced.cshtml](https://github.com/aliencube/ReCaptcha.NET/blob/master/SourceCodes/02_Apps/ReCaptcha.Wrapper.WebApp/Views/Home/Advanced.cshtml) as an example.


## Callback Usage ##

Instead of rendering the reCaptcha controls automatically, you can explicitly initialise rendering options by using a callback function.

```csharp
@section Scripts
{
  var callback = "onLoadCallback";
  var elementId = "recaptcha";

  @Html.ReCaptchaApiJs(Model.ApiUrl,
                       ApiJsRenderingOptions.Async | ApiJsRenderingOptions.Defer,
                       new ResourceParameters()
                       {
                         OnLoad = callback,
                         Render = WidgetRenderType.Explicit,
                         LanguageCode = WidgetLanguageCode.Korean
                       })
  @Html.ReCaptchaCallbackJs(callback,
                            elementId,
                            new RenderParameters()
                            {
                              SiteKey = Model.SiteKey,
                              Theme = RenderThemeType.Dark
                            })
}
```

For this, the `ResourceParameters` class in `ReCaptchaApiJs()` is used. This enables to load callback function and the callback function is loaded by using `ReCaptchaCallbackJs()` method. As all rendering options are defined here, the actual HTML part look like:

```csharp
@using (Html.BeginForm(MVC.Home.ActionNames.Advanced, MVC.Home.Name, FormMethod.Post))
{
  ...

  <div class="form-group" id="@elementId"></div>

  ...
}
```

* `@Html.ReCaptchaApiJs()` renders JavaScript for the reCaptcha control.
* `@Html.RecaptchaCallbackJs()` renders JavaScript callback function for the reCaptcha control.
* More details can be found on [Advanced.cshtml](https://github.com/aliencube/ReCaptcha.NET/blob/master/SourceCodes/02_Apps/ReCaptcha.Wrapper.WebApp/Views/Home/Callback.cshtml) as an example.


## Controller ##

In order to handle the reCaptcha control in your controllers, take a look at the following:

```csharp
[HttpPost]
public virtual async Task<ActionResult> Index(HomeReCaptchaViewModel form)
{
  var result = await this._reCaptcha.SiteVerifyAsync(this.Request.Form, this.Request.ServerVariables);

  var vm = form;
  vm.Success = result.Success;
  vm.ErrorCodes = result.ErrorCodes;
  return View(vm);
}
```

* `ReCaptchaV2.SiteVerifyAsync()` takes parameters of `Form` and `ServerVariables` and returns the result.
* More details can be found on [HomeController.cs](https://github.com/aliencube/ReCaptcha.NET/blob/master/SourceCodes/02_Apps/ReCaptcha.Wrapper.WebApp/Controllers/HomeController.cs) as an example.


## Settings ##

As you can see the above example codes, configuration settings needs to be instantiated first by calling:

```csharp
var settings = ReCaptchaV2Settings.CreateInstance();
```

Alternatively, the `settings` instance can be injected by any IoC container. The following code is, for example, using [Autofac](http://autofac.org)

```csharp
var builder = new ContainerBuilder();

...

builder.Register(p => ReCaptchaV2Settings.CreateInstance()).As<IReCaptchaV2Settings>();
builder.RegisterType<ReCaptchaV2>().As<IReCaptchaV2>();

...

var container = builder.Build();
```

This `settings` instance comes from either `reCaptchaV2Settings` section or `appSettings` section on `App.config` or `Web.config`. It firstly look for the `reCaptchaV2Settings` section and, if no `reCaptchaV2Settings` section is found, then look for the `appSettings` section.

```xml
<configuration>
  <configSections>
    <section name="reCaptchaV2Settings" type="Aliencube.ReCaptcha.Wrapper.ReCaptchaV2Settings, Aliencube.ReCaptcha.Wrapper" requirePermission="false" />
  </configSections>

  <reCaptchaV2Settings
    requestUrl="https://www.google.com/recaptcha/api/siteverify"
    apiUrl="https://www.google.com/recaptcha/api.js"
    siteKey="[YOUR_SITE_KEY]"
    secretKey="[YOUR_SECRET_KEY]" />
</configuration>
```

If you want to simply use the `appSettings` section, you can do the following instead:

```xml
<configuration>
  <appSettings>
    <add key="RequestUrl" value="https://www.google.com/recaptcha/api/siteverify" />
    <add key="ApiUrl" value="https://www.google.com/recaptcha/api.js" />
    <add key="SiteKey" value="[YOUR_SITE_KEY]" />
    <add key="SecretKey" value="[YOUR_SECRET_KEY]" />
  </appSettings>
</configuration>
```

> **NOTE**: Make sure that:
> 
> * Both SiteKey and SecretKey **MUST** be changed to yours before running this code; otherwise you'll get an error. They can be obtained from [https://google.com/recaptcha](https://google.com/recaptcha), once you login.


## Acknowledgements ##

* **ReCaptcha.NET** currently support Version 2 only. Find another library for Version 1.


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
