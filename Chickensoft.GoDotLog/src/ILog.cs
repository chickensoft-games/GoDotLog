namespace Chickensoft.GoDotLog;
using System;
using System.Diagnostics;

/// <summary>
/// Log interface for outputting messages produced during runtime.
/// A debug implementation might print the messages to the console, while a
/// production implementation might write the messages to a file.
/// </summary>
public interface ILog {
  /// <summary>
  /// Prints the specified message to the log.
  /// </summary>
  /// <param name="message">Message to output.</param>
  void Print(string message);

  /// <summary>
  /// Displays a stack trace in a convenient format.
  /// </summary>
  /// <param name="stackTrace">Stack trace to output.</param>
  void Print(StackTrace stackTrace);

  /// <summary>
  /// Prints an exception.
  /// </summary>
  /// <param name="e">Exception to print.</param>
  void Print(Exception e);

  /// <summary>
  /// Prints an exception with a message for context.
  /// </summary>
  /// <param name="e">Exception to print.</param>
  /// <param name="message">Message to output.</param>
  void Print(Exception e, string message) {
    Print(message);
    Print(e);
  }

  /// <summary>
  /// Adds a warning message to the log.
  /// </summary>
  /// <param name="message">Message to output.</param>
  void Warn(string message);

  /// <summary>
  /// Adds an error message to the log.
  /// </summary>
  /// <param name="message">Message to output.</param>
  void Err(string message);
}
