#Flime - Fluent.Time [![Build status](https://ci.appveyor.com/api/projects/status/nuxp4l0gv76joq3d/branch/master?svg=true)](https://ci.appveyor.com/project/loctanvo/flime/branch/master) [![NuGet Stable](http://img.shields.io/nuget/v/loctanvo.fluent.time.svg?style=flat)](https://www.nuget.org/packages/loctanvo.fluent.time/) [![Downloads](https://img.shields.io/nuget/dt/loctanvo.fluent.time.svg)](https://www.nuget.org/packages/loctanvo.fluent.time/)

Convenient (extensions) methods on TimeSpan and DateTimeOffset with fluent ish syntax.

## Examples

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
```csharp
[Test]
public void Ago_Default_SubstractsFromNow()
{
	TestUtilities.TimeHandling.TimeMachine.SandBox(travel =>
	{
	    travel.FreezeTo(Some.Time);

	    Assert.That(2.Hours().Ago(), Is.EqualTo(Now.Utc.Subtract(2.Hours())));
	});
}
```
```csharp
[TestCase("1.Second", 1)]
[TestCase("1.second", 1)]
[TestCase("1.Seconds", 1)]
[TestCase("42.second", 42)]
[TestCase("42.Seconds", 42)]
public void ToTimeSpan_ValidSeconds_ParseCorrectly(string input, int seconds)
{
    AssertEquals(input, seconds.Seconds());
}
```
## License
The MIT License (MIT)

Copyright (c) 2014 Loc Tan Vo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
