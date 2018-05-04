using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class HexPositionTest {
	[Test]
	public void RotationTest() {
		Assert.True(Direction.n.Rotate(1) == Direction.ne);
		Assert.True(Direction.ne.Rotate(1) == Direction.se);
		Assert.True(Direction.se.Rotate(1) == Direction.s);
		Assert.True(Direction.s.Rotate(1) == Direction.sw);
		Assert.True(Direction.sw.Rotate(1) == Direction.nw);
		Assert.True(Direction.nw.Rotate(1) == Direction.n);

		Assert.True(Direction.n.Rotate(-1) == Direction.nw);
		Assert.True(Direction.ne.Rotate(-1) == Direction.n);
		Assert.True(Direction.se.Rotate(-1) == Direction.ne);
		Assert.True(Direction.s.Rotate(-1) == Direction.se);
		Assert.True(Direction.sw.Rotate(-1) == Direction.s);
		Assert.True(Direction.nw.Rotate(-1) == Direction.sw);

		Assert.True(Direction.s.Rotate(-12) == Direction.s);
		Assert.True(Direction.s.Rotate(-8) == Direction.ne);
		Assert.True(Direction.s.Rotate(-6) == Direction.s);
		Assert.True(Direction.s.Rotate(-3) == Direction.n);
		Assert.True(Direction.s.Rotate(-2) == Direction.ne);
		Assert.True(Direction.s.Rotate(0) == Direction.s);
		Assert.True(Direction.s.Rotate(2) == Direction.nw);
		Assert.True(Direction.s.Rotate(3) == Direction.n);
		Assert.True(Direction.s.Rotate(6) == Direction.s);
		Assert.True(Direction.s.Rotate(8) == Direction.nw);
		Assert.True(Direction.s.Rotate(12) == Direction.s);
	}
}
