# Chickensoft.GoDotLog

[![Chickensoft Badge][chickensoft-badge]][chickensoft-website] [![Discord][discord-badge]][discord] [![Read the docs][read-the-docs-badge]][docs] ![line coverage][line-coverage] ![branch coverage][branch-coverage]

Opinionated Godot logging interface and console implementation for C#.

---

<p align="center">
<img alt="Chickensoft.GoDotLog" src="Chickensoft.GoDotLog/icon.png" width="200">
</p>

```csharp
public class MyEntity {
  // Create a log which outputs messages prefixed with the name of the class.
  private ILog _log = new GDLog(nameof(MyClass));
}
```

Logs can perform a variety of common actions (and output messages if they fail automatically):

```csharp
_log.Print("My message");

_log.Warn("My message");

_log.Err("My message");

// Run a potentially unsafe action. Any errors thrown from the action will
// be output by the log. An optional error handler callback can be provided
// which will be invoked before the exception is re-thrown.
_log.Run(
  () => { _log.Print("Potentially unsafe action"); },
  (e) => {
    _log.Err("Better clean up after myself...whatever I did failed.");
  }
);

// Throw an assertion exception with the given message if the assertion fails.
_log.Assert(node.Name == "MyNode", "Must be valid node name.");

// Return the value of a function or a fallback value.
var result = _log.Always<T>(
  () => new Random().Next(0, 10) > 5 ? "valid value" : null,
  "fallback value"
);

// Print a decently formatted stack trace.
_log.Print(new StackTrace());
```

[chickensoft-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/chickensoft_badge.svg
[chickensoft-website]: https://chickensoft.games
[discord-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/discord_badge.svg
[discord]: https://discord.gg/gSjaPgMmYW
[read-the-docs-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/read_the_docs_badge.svg
[docs]: https://chickensoft.games/docsickensoft%20Discord-%237289DA.svg?style=flat&logo=discord&logoColor=white
[line-coverage]: Chickensoft.GoDotLog.Tests/badges/line_coverage.svg
[branch-coverage]: Chickensoft.GoDotLog.Tests/badges/branch_coverage.svg
