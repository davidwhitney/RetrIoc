RetrIoc - A WebForms DI container shim
====================

Using webforms? Having a terrible time? Really want DI? This is for you.

DI containers are excellent productivity tools, but for those of us trapped maintaining (hopefully end of life) "Classic ASPX WebForms" sites, using a DI container look like a horrible message of static service location.

RetrIoc is a HTTP module shim that you can wrap around "the IOC container of your choice" which runs on every request and performs DI on your WebForms pages.


# Features

This package is deliberatley feature lite - all lifecycle and DI concerns are the responsibility of your container - this simply provides a HTTP Module to glue everything together.

Using the ```Inject``` attribute you can mark:
* Public and Private Properties
* Public and Private Fields

As "Injected" on ASPX pages and controls.
Per-request, your container will be invoked to populate the values of these properties, providing you a single hook for using Constructor injection across all the properties that you inject.

# Getting Started

You'll need to do four things:

1. Add the RetrIoc Http module to your web.config
2. Implement our `IResolveTypes` interface
3. Register your implementation
4. Markup your WebForms pages with attributes

Given the following WebForms page:

```csharp
public class TestPage : Page
{
  public Dep SomeUserControl { get; set; }
}
```

### 1 - Add the module

* Add a nuget package reference to RetrIoc.
* Open your web.config
* Add <add name="RetrIoc" type="RetrIoc.Autowire, RetrIoc"/> to your http modules

### 2 - Implement IResolveTypes

This is really down to you, but you need to wrap the configured instance of your container. Consider this example that uses Activator:

```csharp
public class ActivatorContainer : IResolveTypes
{
  public object Resolve(Type type)
  {
    return Activator.CreateInstance(type);
  }

  public object ResolveAll(Type type)
  {
    return Activator.CreateInstance(type);
  }

  public void Release(object instance)
  {
    //noop;
  }
}
```

Provide an implementation for the fully configured container of your choosing.

### 3 - Register your implementation

Open up your ```global.asax``` file and add the following block of code:

```csharp
protected void Application_Start(object sender, EventArgs e)
{
  Autowire.ConfigureWith(new YourTypeResolverHere());
}
```

Obviously, don't replace your existing application start if you have one.

### 4 - Markup your pages

To enable DI simply add the `Inject` attribute to your code - using our previous example:

```csharp
public class TestPage : Page
{
  [Inject]
  public Dep SomeUserControl { get; set; }
}
```
