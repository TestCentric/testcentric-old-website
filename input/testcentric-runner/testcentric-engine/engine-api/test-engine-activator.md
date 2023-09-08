Title: Test Engine Activator
Order: 1
---
The static class TestEngineActivator is used to get an interface to the engine. Its CreateInstance member has two overloads, depending on whether a particular minimum version of the engine is required.

```c#
public static ITestEngine CreateInstance(bool unused = false);
public static ITestEngine CreateInstance(Version minVersion, bool unused = false);
```

(The unused bool parameter previously allowed users to indicate if wished to restrict usage of global NUnit Engine installations. The latter functionality is no longer available and the interface will be redefined in a coming release.)

The TestEngineActivator searches for an engine to load in two places. First, the current App Domain Base Directory is searched, and then any path set as the App Domain's RelativeSearchPath.
