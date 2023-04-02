namespace Chickensoft.GoDotLog;

using System;
using System.Runtime.CompilerServices;

/// <summary>Exception thrown when an assertion fails.</summary>
public partial class AssertionException : Exception {
  /// <summary>
  /// Creates a new assertion exception.
  /// </summary>
  /// <param name="message">Assertion message.</param>
  /// <param name="file">File path (automatically inferred).</param>
  /// <param name="line">Line number (automatically inferred).</param>
  public AssertionException(
    string message,
    [CallerFilePath] string file = "<unknown>",
    [CallerLineNumber] int line = -1
  ) : base($"{file}:{line} {message}") { }

  /// <summary>
  /// Creates a new assertion exception.
  /// </summary>
  public AssertionException() { }

  /// <summary>
  /// Creates a new assertion exception with the given message.
  /// </summary>
  /// <param name="message">Assertion message.</param>
  public AssertionException(string? message) : base(message) { }

  /// <summary>
  /// Creates a new assertion exception with the given message and inner
  /// exception.
  /// </summary>
  /// <param name="message">Assertion message.</param>
  /// <param name="innerException">Inner exception.</param>
  public AssertionException(string? message, Exception? innerException)
    : base(message, innerException) { }
}
