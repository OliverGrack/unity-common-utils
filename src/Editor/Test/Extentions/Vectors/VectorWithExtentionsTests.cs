using NUnit.Framework;
using UCU;
using UnityEngine;

public class VectorWithExtentionsTests {
    [Test]
    public void xy_3D() {
        Assert.AreEqual(
            new Vector2(1, 2),
            new Vector3(1, 2, 3).XY()
        );
    }

    [Test]
    public void WithXYZ_3D() {
        Assert.AreEqual(
            new Vector3(10, 2, 3),
            new Vector3(1, 2, 3).WithX(10)
        );
        Assert.AreEqual(
            new Vector3(1, 10, 3),
            new Vector3(1, 2, 3).WithY(10)
        );
        Assert.AreEqual(
            new Vector3(1, 2, 10),
            new Vector3(1, 2, 3).WithZ(10)
        );
    }

    [Test]
    public void With_3D() {
        Assert.AreEqual(
            new Vector3(10, 2, 3),
            new Vector3(1, 2, 3).With(x: 10)
        );
        Assert.AreEqual(
            new Vector3(1, 10, 3),
            new Vector3(1, 2, 3).With(y: 10)
        );
        Assert.AreEqual(
            new Vector3(1, 2, 10),
            new Vector3(1, 2, 3).With(z: 10)
        );
        Assert.AreEqual(
            new Vector3(10, 20, 3),
            new Vector3(1, 2, 3).With(x: 10, y: 20)
        );
        Assert.AreEqual(
            new Vector3(10, 2, 30),
            new Vector3(1, 2, 3).With(x: 10, z: 30)
        );
        Assert.AreEqual(
            new Vector3(1, 20, 30),
            new Vector3(1, 2, 3).With(y: 20, z: 30)
        );
        Assert.AreEqual(
            new Vector3(10, 20, 30),
            new Vector3(1, 2, 3).With(x: 10, y: 20, z: 30)
        );
    }
    [Test]
    public void WithXY_2D() {
        Assert.AreEqual(
            new Vector2(10, 2),
            new Vector2(1, 2).WithX(10)
        );
        Assert.AreEqual(
            new Vector2(1, 10),
            new Vector2(1, 2).WithY(10)
        );
    }

    [Test]
    public void With_2D() {
        Assert.AreEqual(
            new Vector2(10, 2),
            new Vector2(1, 2).With(x: 10)
        );
        Assert.AreEqual(
            new Vector2(1, 10),
            new Vector2(1, 2).With(y: 10)
        );
        Assert.AreEqual(
            new Vector2(10, 20),
            new Vector2(1, 2).With(x: 10, y: 20)
        );
    }

    [Test]
    public void WithMagnitute() {
        Assert.AreEqual(
            new Vector3(2, 2, 2).Round(0.0001f),
            new Vector3(1, 1, 1).WithMagnitude(Mathf.Sqrt(3) * 2).Round(0.0001f)
        );

        Assert.AreEqual(
            new Vector2(6, 8).Round(0.0001f),
            new Vector2(3, 4).WithMagnitude(10).Round(0.0001f)
        );
    }
}
