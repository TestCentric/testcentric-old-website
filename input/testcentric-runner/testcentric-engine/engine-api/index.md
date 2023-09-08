Title: Engine API
Order: 3
---
<div class="notice">
<b>WARNING:</b> As of the 2.0.0-beta2 release, the API assembly contains only a small number of interfaces and we continue to rely on the NUnit API (version 3.16.2) for most things. On this page, you can tell which interfaces are found in each API assembly by looking at the namespace in which the interface is defined. Over the next beta release, interfaces will be migrated to our own API assembly.
</div>

The engine exposes an API designed to be used by test runners, which is only updated in a backwards-compatible way wherever possible. In order to ensure future compatibility, runners should interact with the engine strictly through the API. The engine also hosts various extension points, to allow further customization.

The API is published on __nuget.org__ in package __TestCentric.Engine.Api__. Runners should reference both `testcentric.engine.api.dll` and `nunit.engine.api.dll`.
