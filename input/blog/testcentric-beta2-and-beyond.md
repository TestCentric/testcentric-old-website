Title: TestCentric Beta 2 and Beyond
Published: 9/16/2023
Category: TestCentric
Author: Charlie Poole
---
I released version 2.0.0-beta2 of the TestCentric Runner about two weeks ago. This release is both an ending and a beginning. On the one hand, it marks the end of a particular phase of development. On the other, it will serve as the basis for a fairly significant change in future releases.

Specifically, this will be the last release in which we try to keep the code close to that of the NUnit engine and console runner.

When I started developing the TestCentric GUI Runner and engine, there was a strong expectation that the engine would eventually be merged into Version 4 of the NUnit engine and that the GUI would then use that engine instead of having its own. At this point, however, it's clear that the NUnit and TestCentric engines are evolving in somewhat different directions and that re-merging the code is no longer an option. 

Keeping that option open up to now has made progress slightly more difficult and certain features unfeasible. Eliminating it should open up a number of possibilities for future development.

## Progress to Date

Before getting into what comes next, let's quickly look at a few of the changes already made. I'll limit myself to only the major changes.

### Focus on Agents

Version 1 of the GUI used agents but kept them more or less hidden from the casual user. In version 2, agents have more visibility. In fact, users have the option of selecting a particular agent to run tests. Agent selection replaces a lot of options which were previously specified, such as use of Process and AppDomain isolation for the tests. These choices are now implied by the selection of an agent.

### Eliminate Built-in Agents

Since beta1, the engine no longer includes any built-in agents. All agents for running tests are now pluggable extensions and at least one agent must be installed in order to make the engine usable.

The intent is that each runner using the engine should bundle one or more appropriate agents as package dependencies. Our current GUI package is distributed with a dependency on three runners: .NET 4.6.2, .NET 6.0 and .NET 7.0. As a result, it is immediately usable out of the box, but users may remove and add agents at will.

The bundled runners will change as new platforms go into production or reach end of life. One effect of this is that we can continue to support legacy platforms by simply keeping the pluggable agent for each platform available.

In addition to the three bundled agents, agents are currently available for .NET 2.0, .NET 4.0, .NET Core 2.1, .NET Core 3.1, .NET 5.0 and .NET 8.0 preview 7.

### Dropping the Zip Package

As of beta2, there is no longer a zip package for the GUI. We've had some online discussion about this and the conclusion was that removing the zip would simplify our build and release process without limiting usage significantly. For those who want to install an extra copy of the gui for experimentation or testing the nuget package is available. It can be installed any chosen directory using `nuget.exe` from the command-line.

### Running Agents from the Command-line

Also as of beta2, agents may now be run from the command-line, passing the name of a test assembly. This permits running them without using the GUI for testing and debugging. It allows us to test new pluggable agents without a circular dependency on the GUI. Note that this feature is not intended to replace use of a runner, so the available command-line options are kept fairly limited by design.

This feature has been implemented for the three agents bundled with the GUI (.NET 4.6.2, 6.0 and 7.0) and will be rolled out gradually in updates to each of the other pluggable agents.

## What Comes Next?

The beta3 release will primarily focus on the boilerplate changes needed to reduce and eventually eliminate dependency on the NUnit Api assembly, which is the only one we use. We'll stop using the nunit signing key. Our pluggable agent extensions, which are only supported by TestCentric, will use the "TestCentric" prefix rather than "NUnit". There is enough of this kind of work to do that the beta3 release will probably not have many new features - possibly none at all.

Beyond beta3, expect to see TestCentric become more modular. Additional builtin components will become extensions. The ExtensionManager itself is already in a separate assembly, which allows us to implement GUI extensions outside of the engine. Some extensions will have both a GUI and an Engine component.

Either a console mode of operation or a separate console runner is likely to be part of the final release.
