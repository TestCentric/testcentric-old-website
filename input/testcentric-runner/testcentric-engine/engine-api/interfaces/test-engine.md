Title: ITestEngine
Order: 1
---
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
