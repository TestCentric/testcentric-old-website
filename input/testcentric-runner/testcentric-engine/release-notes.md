Title: Release Notes
Description: Display the Engine <a href="release-notes.html">release notes</a>
Order: 9
---

### TestCentric Engine 2.0.0-beta2 - September 3, 2023

This release includes several new features as well as bug fixes.

It is also being made to provide a new starting point for future changes. After this release, we will no longer attempt to maintain compatibility with the NUnit engine as we have in the past.

#### Features

* 129 Make testcentric.extensibiltiy.dll available as an independent package.
* 138 Allow agents to be run independently for testing purposes

#### Bugs

* 128 TCP agent protocol causes agent crashes without displaying the reason
* 142 Clicking 'X' leaves the runner process in memory

#### Build

* 130 Eliminate use of nuspec files for creating packages

### TestCentric Engine 2.0.0-beta1 - May 9, 2023

This is the first beta release of the TestCentric engine.

The major change from the alpha8 release is that all built-in agents have now been removed from the engine itself. This completes our pivot to using pluggable agent extensions for all tests. At this point, the engine alone is no longer capable of running any tests. It's up to the runner making use of the agent to ensure that at least one agent extension is installed. To put it another way: the runner decides what kinds of tests it is capable of running and in what environments, not the engine.

__Note:__ The upcoming beta release of the GUI will include agents for .NET Framework 4.6.2, .NET 6.0 and .NET 7.0. The following additional agents are currently available for user installation: .NET 8.0, .NET 5.0, .NET Core 3.1, .NET Core 2.1, .NET Framework 2.0.

This release was built using the first production release of our TestCentric.Cake.Recipe package.

#### Features

* 2 Create .NET 6.0 Pluggable Agent Extension
* 3 Make all agents pluggable extensions
* 15 Remove Built-in .NET 4.6.2 Framework Agent from the engine
* 108 Create .NET 7.0 Pluggable Agent
* 109 Remove built-in net6.0 agent from the engine
* 110 Remove built-in net7.0 agent from the engine
* 111 Create net462 agent extension

#### Build

* 118 Add tests using Net462PluggableAgent
* 119 Add tests using Net60Pluggable agent
* 120 Add tests using Net70PluggableAgent
* 126 Update recipe to production version 1.0.0

### TestCentric Engine 2.0.0-alpha8 - April 24, 2023

This release makes extensive use of pluggable agents, which had been available as an experimental feature up to now. Built-in support for the .NET Core 3.1 and .NET 5.0 runtimes has been removed and pluggable agents for each of them have been released as separate extensions. Without the extensions, such tests will now be run under .NET 6.0. In addition, tests may now be run under .NET 8.0 using the .NET 8.0 pluggable engine, available as a download from our MyGet feed. That agent is still in pre-alpha development.

The engine is now built using our cake recipe, TestCentric.Cake.Recipe, which was extended in order to support it.

#### Features

* 17 Remove Built-in .NET Core 3.1 Agent from the engine
* 18 Remove Built-in .NET 5.0 Agent from the engine
* 82 Create .NET 8.0 Pluggable Agent

#### Enhancement

* 91 Select best agent of those available for running tests

#### Bugs

* 83 TestCentric.Engine.Core package does not contain .Net Core 3.1 build of testcentric.engine.core
* 85 TestAssemblyResolver doesn't handle dotnet preview releases correctly

#### Build

* 74 Use TestCentric-specific environment variable names for API keys
* 77 Build script should specify versions of extensions used
* 79 Add test using .NET Core 2.1 Pluggable Agent
* 80 Make build script consistent with that of the GUI
* 89 Update TestCentric.Metadata to version 2.0.0
* 93 Eliminate unnecessary builds of TestCentric.Engine.Api
* 96 Test with new pluggable agent releases
* 97 Use TestCentric.Cake.Recipe for build
* 101 Use test level to reduce number of package tests run
* 105 Remove pluggable agent tests from build

### TestCentric Engine 2.0.0-alpha7 - January 29, 2023

#### Features

* 56 Separate assembly for NUnit extensibility
* 59 Return to use of the NUnit 3.0 API
* 61 Create a builtin .NET 7.0 agent
* 62 Build testcentric.engine.core for .NET Core 3.1
* 66 Create a built-in .NET 6.0 agent

#### Enhancement

* 64 Implement InternalTrace logging in extensibility assembly

#### Bugs

* 54 All assemblies appear to run even when selecting items from a single assembly
* 72 Exception thrown when an extension is found for which there is no extension point.

#### Build

* 57 Get build working again
* 70 Remove testcentric-agent.runtimeconfig.dev.json from nuget package

### TestCentric Engine 2.0.0-alpha6 - June 17, 2022

#### Enhancement

* 35 Add package setting indicating the agent actually used

#### Bugs

* 29 When opening a non-test assembly, error message is unclear
* 30 Should recognize .NET Standard runtime even though we don't run tests targeting it
* 36 Engine assemblies not showing correct version
* 39 The Stop button doesn't work on test cases
* 43 Cannot load extensions with a required engine version specified

#### Build

* 32 Use current version of nunit.engine.api
* 42 Get engine tests working with extensions

### TestCentric Engine 2.0.0-alpha5 - November 24, 2021

This is the first independent release of the TestCentric Engine, which was previously part of the TestCentric GUI project. Bundled releases were done in conjunction with the GUI through 2.0.0-alpha4. Consequently, this new release is designated as 2.0.0-alpha5.

#### Breaking Changes

* 4 Remove .NET 2.0 Framework Agent from the engine
* 16 Remove .NET Core 2.1 Agent from the engine

#### Build

* 20 Eliminate end-of-life checks for .NET Core 2.1 builds
