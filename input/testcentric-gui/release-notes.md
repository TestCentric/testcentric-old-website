Description: Displays the <a href="release-notes.html">Release Notes</a> showing changes made in each release of TestCentric.
Order: 9
---

### TestCentric Runner for NUnit 2.0.0-alpha7- February 6, 2023

The primary feature added in this release comes from use of version 2.0.0-alpha7 of the test engine. The GUI is now able to run tests, which target .NET 6.0 and .NET 7.0.

#### Features

- 706 Specify test run parameters on command-line
- 890 Support use of VisualState when test assembly has changed.
- 914 Update to use alpha7 version of engine
- 933 Update Gui to use .NET 4.6.2 rather than 4.5

#### Enhancements

- 774 Save and Restore Visual State for fixture and test list display formats
- 906 Better handling of "dynamic" test groups

#### Bugs

- 201 VisualState.xml should be saved *before* running tests
- 901 Shown tooltip is hard to hide for failed test
- 907 Missing output with failed test stack traces for Assert.Multiple
- 911 Run Summary should close automatically when new run is starting
- 941 Unhandled exception starting GUI if settings file is corrupted

#### Build

- 934 Get build working again!
- 939 Use TestCentric-specific environment variable names for API keys
- 943 Make CHANGES file a pointer to the Release Notes

### TestCentric Runner for NUnit 1.6.4- December 2, 2022

This release fixes a critical bug in version 1.6.3. In addition, due to changes in the environment and in Microsoft tool and runtime support, further changes were made to allow the build scripts to function.

#### Bug

- 925 TestCentric-Gui 1.6.3 + NUnit IDriverFactory extension

#### Build

- 929 Update cake scripts
- 926 Update Version 1 GUI to build with current tools

### TestCentric Runner for NUnit 1.6.3- July 31, 2022

#### Feature

- 921 Remove Experimental GUI

#### Enhancement

- 919 Eliminate dependency on CLR version when initializing TestCentric

#### Bug

- 916 Testcentric 1.6.2 does not start when .Net 6.0 is installed

#### Build

- 917 Set up branch for V1 releases

### TestCentric Runner for NUnit 2.0.0-alpha6- June 18, 2022

#### Features

- 903 Update GUI to use engine version 2.0.0-alpha6
- 895 VisualState should handle adding new tests while maintaining the display correctly

#### Enhancement

- 892 Visual state at reloading assembly

#### Bugs

- 902 Get cancellation working using engine version 2.0.0-dev00050
- 898 UI for stopping/killing test run is a bit confusing
- 891 VisualState- When a single test is deleted other tests are mis-identified
- 887 Tree view reload after assembly is reloaded

#### Documentation

- 885 Document GUI Alpha releases

### TestCentric Runner for NUnit 2.0.0-alpha5- May 14, 2022

This release includes major revisions to the UI. There is no longer a `Test` menu. Rather, all test execution is performed through the toolbar or the context menu. The toolbar now contains buttons for running all or selected tests, repeating the last run and running only failed tests.

__Note:__ The selected (highlighted) test item in the tree is now referred to as the "Active" item. This is the item for which any detailed information is displayed, as in the properties tab, for example. If `Checkboxes` are enabled, the checked items are referred to as "Selected" for running. If they are disabled, or if no items are checked, the "Active" item is also considered as "Selected".

Reflecting changes in the TestCentric engine, there are no longer built-in agents for .NET 2.0 and .NET Core 2.1. These will be provided by separately installed extensions. The .NET 2.0 Pluggable Agent extension is already available and used in our tests. The .NET Core 2.1 agent is being developed.

#### Breaking Changes

- 842 Eliminate built-in .NET Core 2.1 agent
- 841 Eliminate built-in net20 agent

#### Features

- 881 Specify full- vs mini-gui on command line
- 877 Re-Implement Debugging of tests__](https://github.com/TestCentric/testcentric-gui/issues/921)
- 870 Run Failed tests from previous runs
- 869 Rerun Last Test
- 245 Make XML display of tests and test results a popup window

#### Enhancements

- 872 Move RunSummary button next to progress bar
- 871 Reorganize "Group By" functionality in the UI
- 861 Disallow both ReloadOnChange and ReloadOnRun
- 836 Convert command-line processing to latest version of Mono.Options

#### Bugs

- 866 TestProperties tab panels not expanding to full width available
- 854 Need a better way to run a subset of the tests
- 853 test duration time is changing
- 852 Assembly Reload: "Reload before each test run" does not work
- 851 Double click test to start
- 848 Incorrect display when opening a project file without the proper extension installed.
- 846 Error when attempting to open an assembly targeting .NET Standard
- 827 Mono,Win10 Error

#### Build

- 844 Remove unused copies of engine files from the repository
- 829 Eliminate TestCentric.Common project
- 828 Make TestCentric Engine a separate project

### TestCentric Runner for NUnit 2.0.0-alpha4- October 2, 2021

This release incorporates a critical fix to a bug, which caused the program to crash when run on a machine with .NET 6.0 installed.

#### Bug

- 821 System.ArgumentException: 'Unknown .NET Core version: 6.0 Parameter name: version'

### TestCentric Runner for NUnit 2.0.0-alpha3- September 30, 2021

The primary purpose of this release is to get a few more breaking changes into the repository. With this release, we switch to the dev-4.0 build of the NUnit Engine API, and stop building for .NET Standard 1.6 and .NET Core 1.1.

#### Breaking Changes

- 809 Stop building for .NET Standard 1.6 and .NET Core 1.1
- 808 Switch to the dev-40 build of the NUnit Engine API

#### Feature

- 804 Remove references to the engine from the GUI proper

#### Enhancement

- 705 Modify Arguments to Agent Process

#### Build

- 813 Upgrade to the latest Cake version
- 812 Use VS Project properties to generate the assemblyinfo files
- 805 Stop use of Image Directory where not needed

### TestCentric Runner for NUnit 2.0.0-alpha2- August 15, 2021

The 2.0.0 release will be the first major upgrade of the TestCentric Gui
with a number of breaking changes as well as new features.

The primary change in this second alpha release is that the old Standard
GUI is no longer used. The former Experimental GUI is now the only version
of the GUI in use. The GUI also has a few new features in this release:

- When using the full GUI  layout, the progress bar now appears in the right-hand panel.
- The Run Summary report is now displayed directly beneath the progress bar.
- The toolbar now includes icons for normal and forced stop (kill) and for displaying a summary of the last run.

#### Features

- 780 Restore TestPropertiesDialog for use with the mini-GUI
- 762 Variable positioning of progress bar
- 761 Make Menu Bar full width of main window
- 758 Make "Stop Run" a separate button on menu bar"
- 757 Remove "Run Failed" from split button choices in menu bar
- 745 Port XmlView from experimental GUI
- 744 Port PropertyView from experimental GUI
- 742 Remove Not Run tab
- 741 Move Progress Bar to left-hand panel
- 740 Remove right-hand panel Run and Cancel buttons
- 735 Remove Categories Tab from left-hand GUI panel
- 732 Merge features of the experimental GUI into the 2.0 standard GUI
- 609 Allow selecting normal versus forced stop
- 230 Save and restore Visual state

#### Enhancements

- 798 Improve Test Run Report Presentation
- 794 Adjust PropertiesDialog Layout to be closer to that of TestPropertiesView
- 790 Hide result box in TestPropertiesDialog when there is no result
- 789 Display package settings in TestPropertiesView
- 786 Show package settings at top of PropertiesDialog and only show for tests representing packages
- 755 Display last run summary on demand
- 737 Remove checkbox-related buttons from below tree display

#### Bugs

- 791 TestPropertiesDialog does not update after test run
- 788 Location of form should be saved before changing GUI layout
- 783 NRE when File Menu pops up without an open project
- 778 Visibility of StatusBar is not saved
- 770 Need icon for display format button
- 769 Groupings, which do not apply to the current display format, should be disabled
- 767 GroupBy dropdown has no effect when changing

#### Build

- 800 Retry failed publishing steps in build
- 753 Move "common" gui components to the  Gui project
- 733 Remove unneeded conditionals from the engine

### TestCentric Runner for NUnit 2.0.0-alpha1- June 30, 2021

The 2.0.0 release is the first major upgrade of the TestCentric Gui.
It includes a number of breaking changes as well as new features.

#### Significant Gui Changes

- The ProcessModel and DomainUsage menus have been eliminated.

- A new Select Agents menu allows the user to choose a non-default
  agent when more than one is available for a particular assembly.

#### Significant Engine Changes

- In-process execution of tests and the ProcessModel package setting
  are no longer supported. Each test assembly is now run in its own
  separate process.

- The DomainUsage package setting is no longer supported. The runner
  itself decides whether an AppDomain should  be used when running
  on a particular platform.

- All test execution is now performed by agents, which are usually
  separate local processes. Agent selection may be automatic or
  user-specified using a package setting.

- It is now possible to create "pluggable agents" by use of a new
  engine extension point. Currently, this capability is limited to
  local process agents, but it is intended to be extended to other
  agent types in the future.

- Services are now initialized when they are first accessed through
  the service context rather than at startup.

- There is no longer a .NET Standard build of the engine.

- The metadata assembly is now a separate package, which is used
  by the engine.

- X86 builds of .Net Core agents are no longer provided, since
  they are not needed.

#### Breaking Changes

- 664 Replace AppDomain and Process with "Agent" from user perspective
- 656 Pluggable Agents
- 665 Eliminate ProcessModel setting
- 657 Eliminate DomainUsage option
- 444 Eliminate in-process execution

#### Features

- 697 Agent Redesign
- 694 Remove x86 build of agent for .NET Core
- 693 Stop building engine for .NET Standard
- 689 Remove DomainManager as a service
- 684 Make metadata assembly a fully independent package
- 678 Create package for use by pluggable agents

#### Enhancements

- 715 Make dependencies of one service on another explicit
- 677 Update AboutBox for 2.0 release
- 666 Issue an error message when user provides an obsolete project setting. Ignore in project files.

#### Bugs

- 719 Crashing Testcentric on trying to change Process Model to X86
- 707 ResultHelper.Aggregate doesn't count warnings

#### Build

* 729 Allow creation of draft and production GitHub releases for pre-release versions
* 725 Upgrade NUnit framework to 3.12
* 716 Provide test doubles for all services needed for testing.
* 700 Use the GUI to run its own tests
* 699 Create separate test assembly for nunit.agent.core
* 682 Build script should check files for valid headers
