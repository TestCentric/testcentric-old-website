Title: IAgentLauncher
Order: 4
---
This interface is key to the implementation of Pluggable Agents, which implement `IAgentLauncher`. The interface itself is in a nested Extensibility interface to avoid cluttering the namespace exposed to users.

```c#
namespace TestCentric.Engine
{
    namespace Extensibility
    {
        [TypeExtensionPoint(
            Description = "Launches an Agent Process for supported target runtimes")]
        public interface IAgentLauncher
        {
            TestAgentInfo AgentInfo { get; }
            bool CanCreateProcess(TestPackage package);
            Process CreateProcess(Guid agentId, string agencyUrl, TestPackage package);
        }
    }

    public interface ITestAgentInfo
    {
        /// <summary>
        /// Gets a list containing <see cref="TestAgentInfo"/> for all available agents.
        /// </summary>
        IList<TestAgentInfo> GetAvailableAgents();

        /// <summary>
        /// Gets a list containing <see cref="TestAgentInfo"/> for any available agents,
        /// which are able to handle the specified package.
        /// </summary># IAgentLauncher


        /// <param name="package">A Testpackage</param>
        /// <returns>
        /// A list of suitable agents for running the package or an empty
        /// list if no agent is available for the package.
        /// </returns>
        IList<TestAgentInfo> GetAgentsForPackage(TestPackage package);
    }

    /// <summary>
    /// The TestAgentInfo struct provides information about an
    /// available agent for use by a runner.
    /// </summary>
    public struct TestAgentInfo
    {
        public string AgentName;
        public TestAgentType AgentType;
        public FrameworkName TargetRuntime;

        public TestAgentInfo(string agentName, TestAgentType agentType, FrameworkName targetRuntime)
        {
            AgentName = agentName;
            AgentType = agentType;
            TargetRuntime = targetRuntime;
        }
    }

    /// <summary>
    /// TestAgentType is an enumeration of the types
    /// of agents, which may be available. Currently, three
    /// types are defined, of which one is implemented.
    /// </summary>
    /// <remarks>
    /// A user requests a particular agent type by incuding a
    /// "TestAgentType" setting in the test package. The setting
    /// is optional and the runner will select an agent of any
    /// type available if it isn't specified.
    /// </remarks>
    public enum TestAgentType
    {
        /// <summary>
        /// Any agent type is acceptable. This is the default value,
        /// so it never needs to be specified.
        /// </summary>
        Any = 0,

        /// <summary>
        /// An in-process agent. This type is not directly supported
        /// by the engine but may be provided by an extension.
        /// </summary>
        InProcess = 1,

        /// <summary>
        /// An agent running as a separate local process.
        /// A supplier for this type is built into the engine.
        /// </summary>
        LocalProcess = 2,

        /// <summary>
        /// An agent running on a server, that is a separate
        /// machine, which may be specified in the request or
        /// left up to the agent supplier to determine. A supplier
        /// for this type is under development in the engine.
        /// </summary>
        RemoteProcess = 3
    }
}
```
