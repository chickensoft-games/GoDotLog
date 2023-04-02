namespace Chickensoft.GoDotLog.Tests;

using System;
using Godot;
using GoDotTest;
using Shouldly;

public class AssertionExceptionTest : TestClass {
  public AssertionExceptionTest(Node testScene) : base(testScene) { }

  [Test]
  public void DefaultInitializer()
    => new AssertionException()
      .ShouldBeAssignableTo<AssertionException>();

  [Test]
  public void SimpleInitializer() {
    var e = new AssertionException((string?)"message");
    e.Message.ShouldBe("message");
  }

  [Test]
  public void InitializerWithInnerException() {
    var inner = new InvalidOperationException("inner");
    var e = new AssertionException("message", inner);
    e.Message.ShouldBe("message");
    e.InnerException.ShouldBe(inner);
  }

  [Test]
  public void InitializeWithCallerProperties() {
    var e = new AssertionException("message", "file", 42);
    e.Message.ShouldBe("file:42 message");
  }
}
