# QuickEmailVerification.NET
[QuickEmailVerification](http://www.quickemailverification.com) .net client

Only the most basic verify was implemented.

## Status

[![Build status](https://ci.appveyor.com/api/projects/status/swe9wr7y5fn41q33?svg=true)](https://ci.appveyor.com/project/ssemi/quickemailverification-net)



### Test

```CSharp
var quickEmail = new Quickemailverification("your_APIKey_is_Here");
bool flag = await quickEmail.Verify("email@email.com");
```
or
```CSharp
var quickEmail = new Quickemailverification("your_APIKey_is_Here");
var model = await quickEmail.VerifyInfo("email@email.com");
Console.WriteLine(model.Code);
Console.WriteLine(model.Success);
Console.WriteLine(model.Result);
```
