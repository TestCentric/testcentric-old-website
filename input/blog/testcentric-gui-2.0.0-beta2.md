Title: TestCentric Runner 2.0.0-beta2 Released
Published: 9/3/2023
Category: Release
Author: Charlie Poole
---
This release is part of a group of related releases:

    TestCentric Runner 2.0.0-beta2
    TestCentric Engine 2.0.0-beta2
    Net 4.6.2 Pluggable Agent 2.1.1
    Net 6.0 Pluggable Agent 2.1.0
    Net 7.0 Pluggable Agent 2.1.0

Together they form a kind of plateau in the development of TestCentric and a basis for redirecting that development. Specifically, they will be the last releases where the code is constrained to remain compatibility with the NUnit engine and console runner.

At this point, it's clear that the NUnit and TestCentric engines are evolving in somewhat different directions and that re-merging the code is no longer very likely. The next releases of these packages - and other packages - by TestCentric will continue to support a certain degree of compatibility in usage but we no longer anticipate merging the two engines in the future.
This release contains one breaking change and one new feature:

__Breaking Change__: There is no longer a zip package for the GUI. This simplifies our build process without limiting usage significantly. For those who want to install an extra copy of the gui for experimentation or testing we suggest installing the nuget package into a chosen directory from command-line.

__New Feature__: Agents may now be run from the command-line. This is intended for testing and debugging rather than as a substitute for the use of the runner. Currently, this has been implented for the three agents bundled with the GUI.
