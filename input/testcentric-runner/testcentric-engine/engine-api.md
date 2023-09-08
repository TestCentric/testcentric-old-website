Title: TestCentric Engine API
Description: Describes the <a href="engine-api.html">API for using the engine</a>
Order: 3
---
<div class="notice">
<b>WARNING:</b> Some parts of this description are out of date.
</div>

The engine exposes an API designed to be used by test runners, which is only updated in a backwards-compatible way wherever possible. In order to ensure future compatibility, runners should interact with the engine strictly through the API. The engine also hosts various extension points, to allow further customization.

The API is published on __nuget.org__ in package __TestCentric.Engine.Api__. Runners should reference `testcentric.engine.api.dll`.

# Getting an Engine Reference

The static class TestEngineActivator is used to get an interface to the engine. Its CreateInstance member has two overloads, depending on whether a particular minimum version of the engine is required.

```c#
public static ITestEngine CreateInstance(bool unused = false);
public static ITestEngine CreateInstance(Version minVersion, bool unused = false);
```

(The unused bool parameter previously allowed users to indicate if wished to restrict usage of global NUnit Engine installations. The latter functionality is no longer available.)

The TestEngineActivator searches for an engine to load in two places. First, the current App Domain Base Directory is searched, and then any path set as the App Domain's RelativeSearchPath.

# ITestEngine Interface

This is the primary interface to the engine, which provides all other interfaces to the caller.

```c#
namespace NUnit.Engine
{
    /// <summary>
    /// ITestEngine represents an instance of the test engine.
    /// Clients wanting to discover, explore or run tests start
    /// require an instance of the engine, which is generally
    /// acquired from the TestEngineActivator class.
    /// </summary>
    public interface ITestEngine : IDisposable
    {
        /// <summary>
        /// Gets the IServiceLocator interface, which gives access to
        /// certain services provided by the engine.
        /// </summary>
        IServiceLocator Services { get; }

        /// <summary>
        /// Gets and sets the directory path used by the engine for saving files.
        /// Some services may ignore changes to this path made after initialization.
        /// The default value is the current directory.
        /// </summary>
        string WorkDirectory { get; set;  }

        /// <summary>
        /// Gets and sets the InternalTraceLevel used by the engine. Changing this
        /// setting after initialization will have no effect. The default value
        /// is the value saved in the NUnit settings.
        /// </summary>
        InternalTraceLevel InternalTraceLevel { get; set; }

        /// <summary>
        /// Initialize the engine. This includes setting the trace level and
        /// creating the standard set of services used in the Engine.
        ///
        /// This interface is not recommended to be called by user code. The TestEngineActivator
        /// will provide a pre-initialized engine, which should be used as provided.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Returns a test runner instance for use by clients in discovering,
        /// exploring and executing tests.
        /// </summary>
        /// <param name="package">The TestPackage for which the runner is intended.</param>
        /// <returns>An ITestRunner.</returns>
        ITestRunner GetRunner(TestPackage package);
    }
}
```

The normal sequence of calls for initially acquiring this interface is:

```c#
ITestEngine engine = TestEngineActivator.CreateInstance(...);
engine.WorkDirectory = ...;         // Defaults to the current directory
engine.InternalTraceLevel = ...;    // Defaults to off
```

The engine provides a number of services, some internal and some public. Public services are those for which the interface is publicly defined in the nunit.engine.api assembly, listed later in this document.

The final and probably most frequently used method on the interface is GetRunner. It takes a TestPackage and returns an ITestRunner that is appropriate for the options specified.

# ITestRunner Interface

This interface allows loading test assemblies, exploring the tests contained in them and running the tests.

```c#
namespace NUnit.Engine
{
    /// <summary>
    /// Interface implemented by all test runners.
    /// </summary>
    public interface ITestRunner : IDisposable
    {
        /// <summary>
        /// Get a flag indicating whether a test is running
        /// </summary>
        bool IsTestRunning { get; }

        /// <summary>
        /// Load a TestPackage for possible execution
        /// </summary>
        /// <returns>An XmlNode representing the loaded package.</returns>
        /// <remarks>
        /// This method is normally optional, since Explore and Run call
        /// it automatically when necessary. The method is kept in order
        /// to make it easier to convert older programs that use it.
        /// </remarks>
        XmlNode Load();

        /// <summary>
        /// Unload any loaded TestPackage. If none is loaded,
        /// the call is ignored.
        /// </summary>
        void Unload();

        /// <summary>
        /// Reload the current TestPackage
        /// </summary>
        /// <returns>An XmlNode representing the loaded package.</returns>
        XmlNode Reload();

        /// <summary>
        /// Count the test cases that would be run under
        /// the specified filter.
        /// </summary>
        /// <param name="filter">A TestFilter</param>
        /// <returns>The count of test cases</returns>
        int CountTestCases(TestFilter filter);

        /// <summary>
        /// Run the tests in the loaded TestPackage and return a test result. The tests
        /// are run synchronously and the listener interface is notified as it progresses.
        /// </summary>
        /// <param name="listener">The listener that is notified as the run progresses</param>
        /// <param name="filter">A TestFilter used to select tests</param>
        /// <returns>An XmlNode giving the result of the test execution</returns>
        XmlNode Run(ITestEventListener listener, TestFilter filter);

        /// <summary>
        /// Start a run of the tests in the loaded TestPackage. The tests are run
        /// asynchronously and the listener interface is notified as it progresses.
        /// </summary>
        /// <param name="listener">The listener that is notified as the run progresses</param>
        /// <param name="filter">A TestFilter used to select tests</param>
        /// <returns></returns>
        ITestRun RunAsync(ITestEventListener listener, TestFilter filter);

        /// <summary>
        /// Cancel the ongoing test run. If no test is running, the call is ignored.
        /// </summary>
        /// <param name="force">If true, cancel any ongoing test threads, otherwise wait for them to complete.</param>
        void StopRun(bool force);

        /// <summary>
        /// Explore a loaded TestPackage and return information about the tests found.
        /// </summary>
        /// <param name="filter">The TestFilter to be used in selecting tests to explore.</param>
        /// <returns>An XmlNode representing the tests found.</returns>
        XmlNode Explore(TestFilter filter);
    }
}
```

For the most common use cases, it isn't necessary to call Load, Unload or Reload. Calling either Explore, Run or RunAsync will cause the tests to be loaded automatically.

The Explore method returns an XmlNode containing the description of all tests found. The Run method returns an XmlNode containing the results of every test. The XML format for results is the same as that for the exploration of tests, with additional nodes added to indicate the outcome of the test. RunAsync returns an ITestRun interface, which allows retrieving the XML result when it is complete.

The progress of a run is reported to the ITestEventListener passed to the run methods. Notifications received on this interface are strings in XML format, rather than XmlNodes, so that they may be passed directly across a Remoting interface.

# Engine Services

The `ITestEngine.Services` property exposes the IServiceLocator interface, which allows the runner to use public services of the engine.

namespace NUnit.Engine
{
    /// <summary>
    /// IServiceLocator allows clients to locate any NUnit services
    /// for which the interface is referenced. In normal use, this
    /// limits it to those services using interfaces defined in the
    /// nunit.engine.api assembly.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Return a specified type of service
        /// </summary>
        T GetService<T>() where T : class;

        /// <summary>
        /// Return a specified type of service
        /// </summary>
        object GetService(Type serviceType);
    }
}

Some services are available publicly while others are internal only. Public services are those for which an interface is exposed in the API.

<div class="notice">
<b>TODO</b>: Add info about each service that is available.
</div>
