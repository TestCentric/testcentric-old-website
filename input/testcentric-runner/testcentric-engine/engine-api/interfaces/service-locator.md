Title: IServiceLocator
Order: 3
---
The `ITestEngine.Services` property exposes the IServiceLocator interface, which allows the runner to use public services of the engine.

```c#
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
```

Some services are available publicly while others are internal only. Public services are those for which an interface is exposed in the API.

<div class="notice">
<b>TODO</b>: Add info about each service that is available.
</div>
