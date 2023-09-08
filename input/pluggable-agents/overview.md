Title: Overview
Description: Provides a <a href="overview.html">general overview</a> of how Pluggable Agents work.
Order: 1
---
With Version 2.x of the TestCentric runner, all test execution is handled by an agent. Currently, a separate agent instance is used for each test assembly. If multiple agents are able to run a particular test assembly, the user may select the desired agent.

Originally, all agents were built-in as part of the agent. We decided to move to pluggable agents for greater flexibility in configuration and to simplify dealing with changes in the platforms we support. A pluggable agent is simply an engine extension, that is able to run certain tests, usually based on the target platform. By leveraging the existing extension mechanism we were able to implement this concept very simply.

The engine no longer includes code either for test agents themselves or for the launching of agents. When loading of a test assembly is performed, it asks each installed pluggable agent if it is able to execute that assembly and uses the first one giving a positive response.
