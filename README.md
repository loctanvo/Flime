[![Build status](https://ci.appveyor.com/api/projects/status/nuxp4l0gv76joq3d/branch/master?svg=true)](https://ci.appveyor.com/project/loctanvo/flime/branch/master)
[![NuGet Stable](http://img.shields.io/nuget/v/loctanvo.fluent.time.svg?style=flat)](https://www.nuget.org/packages/loctanvo.fluent.time/)
[![Downloads](https://img.shields.io/nuget/dt/loctanvo.fluent.time.svg)](https://www.nuget.org/packages/loctanvo.fluent.time/)

Flime - Fluent.Time
===========

Convenient (extensions) methods on TimeSpan and DateTimeOffset with fluent ish syntax

**Examples**

``` csharp
[Test]
public void And_AddsTheTime()
{
    Assert.That(2.Hours().And(10.Minutes()), Is.EqualTo(TimeSpan.FromMinutes(130)));
}
```

``` csharp
[Test]
public void OClock_NotSpecified_ReturnsTimeToday()
{
    TimeMachine.SandBox(time =>
    {
        time.FreezeTo(Some.Time);

        var twoOClock = 2.OClock();

        Assert.That(twoOClock.TimeOfDay.Hours, Is.EqualTo(2));
        Assert.That(twoOClock.TimeOfDay.Minutes, Is.EqualTo(0));
        Assert.That(twoOClock.TimeOfDay.Seconds, Is.EqualTo(0));
        Assert.That(twoOClock.TimeOfDay.Milliseconds, Is.EqualTo(0));
        Assert.That(twoOClock.Date, Is.EqualTo(Day.Today.Date));
    });
}
```
```csharp
[Test]
public void DayAfterTomorrow_IsTomorrowAddedOneDay()
{
    TimeMachine.SandBox(time =>
    {
        time.FreezeTo(Some.Time);

        var tomorrow = Day.Tomorrow;
        var afterTomorrow = Day.AfterTomorrow;

        Assert.That(afterTomorrow.Subtract(tomorrow), Is.EqualTo(1.Days()));
    });
}
```
