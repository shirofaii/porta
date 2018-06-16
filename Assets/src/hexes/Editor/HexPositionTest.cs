using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

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

    [Test]
    public void HexPosTest() {
        var center = new HexPosition(0, 0, 0);
        var pos = center + center.TowardsDirection(Direction.nw, 3);
        Assert.AreEqual(pos, new HexPosition(-3, 3, 0));
        Assert.True(center.DistanceTo(pos) == 3);

        var ring = center.Ring(3);
        Assert.True(ring.Contains(pos));
        Assert.True(ring.All(x => center.DistanceTo(x) == 3));
    }
}
