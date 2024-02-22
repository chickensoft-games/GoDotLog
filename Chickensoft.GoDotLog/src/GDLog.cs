namespace Chickensoft.GoDotLog;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Godot;

/// <summary>
/// Default log which outputs to Godot using GD.Print, GD.PushWarning,
/// and GD.PushError. Warnings and errors also print the message since
/// `GD.PushWarning` and `GD.PushError` don't always show up in the output
/// when debugging.
/// </summary>
public sealed partial class GDLog : ILog {
  /// <summary>Default print action (GD.Print).</summary>
  public static readonly Action<string> DefaultPrint
    = GD.Print;

  /// <summary>Print action (defaults to GD.Print).</summary>
  public static Action<string> PrintAction { get; set; } = DefaultPrint;

  /// <summary>Default push warning action (GD.PushWarning).</summary>
  public static readonly Action<string> DefaultPushWarning
    = GD.PushWarning;

  /// <summary>Push warning action (defaults to GD.PushWarning).</summary>
  public static Action<string> PushWarningAction { get; set; }
    = DefaultPushWarning;

  /// <summary>Default push error action (GD.PushError).</summary>
  public static readonly Action<string> DefaultPushError
    = GD.PushError;
  /// <summary>Push error action (defaults to GD.PushError).</summary>
  public static Action<string> PushErrorAction { get; set; } = DefaultPushError;

  public string Prefix { get; }

  /// <summary>
  /// Creates a new GDLog with the given prefix.
  /// </summary>
  /// <param name="prefix">Log prefix, displayed at the start of each message.
  /// </param>
  public GDLog(string prefix) {
    Prefix = prefix;
  }

  /// <inheritdoc/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Print(string message) => PrintAction(Prefix + ": " + message);

  /// <inheritdoc/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Print(StackTrace stackTrace) {
    foreach (var frame in stackTrace.GetFrames()) {
      var fileName = frame.GetFileName() ?? "**";
      var lineNumber = frame.GetFileLineNumber();
      var colNumber = frame.GetFileColumnNumber();
      var method = frame.GetMethod();
      var className = method?.DeclaringType?.Name ?? "UnknownClass";
      var methodName = method?.Name ?? "UnknownMethod";
      Print(
        $"{className}.{methodName} in " +
        $"{fileName}({lineNumber},{colNumber})"
      );
    }
  }

  /// <inheritdoc/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Print(Exception e) {
    Err("An error ocurred.");
    Err(e.ToString());
  }

  /// <inheritdoc/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Warn(string message) {
    PrintAction(Prefix + ": " + message);
    PushWarningAction(Prefix + ": " + message);
  }

  /// <inheritdoc/>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Err(string message) {
    PrintAction(Prefix + ": " + message);
    PushErrorAction(Prefix + ": " + message);
  }
}
