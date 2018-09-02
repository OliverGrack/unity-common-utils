using NUnit.Framework;
using UCU;
using UnityEngine;

public class VectorExtentionsTests {
    [Test]
    public void Round() {
        Assert.AreEqual(
            new Vector3(0.1f, 0.6f, 2.4f).Round(),
            new Vector3(0, 1, 2)
        );
        Assert.AreEqual(
            new Vector3(0.14f, 0.67f, 2.2f).Round(0.1f),
            new Vector3(0.1f, 0.7f, 2.2f)
        );
        Assert.AreEqual(
            new Vector2(0.1f, 0.6f).Round(),
            new Vector2(0, 1)
        );
        Assert.AreEqual(
            new Vector2(0.14f, 0.67f).Round(0.1f),
            new Vector2(0.1f, 0.7f)
        );
    }

    public void CutZeroComponents() {
        Assert.AreEqual(
            new Vector3(1, 2, -3).CutZeroComponents(),
            new Vector3(1, 2, 0)
        );
        Assert.AreEqual(
            new Vector2(1, -2).CutZeroComponents(),
            new Vector2(1, 0)
        );
    }
}
