using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class HealthTest {

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator HealthDamageTest() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
        var player = new GameObject().AddComponent<Health>();
        player.SetHealth(100);
        int originalHealth = player.GetHealth();

        player.TakeDamage(20);
        int newHealth = player.GetHealth();

        yield return null;

        Assert.AreNotEqual(originalHealth, newHealth);
        Assert.AreEqual(newHealth, 80);
    }

    [UnityTest]
    public IEnumerator HealthDamageNotBelowZeroTest()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var player = new GameObject().AddComponent<Health>();
        player.SetHealth(100);
        int originalHealth = player.GetHealth();

        player.TakeDamage(150);
        int newHealth = player.GetHealth();

        yield return null;

        Assert.AreNotEqual(originalHealth, newHealth);
        Assert.AreEqual(newHealth, 0);
    }

    [UnityTest]
    public IEnumerator HealthHealTest()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var player = new GameObject().AddComponent<Health>();
        player.SetHealth(50);
        int originalHealth = player.GetHealth();

        player.Heal(25);
        int newHealth = player.GetHealth();

        yield return null;

        Assert.AreNotEqual(originalHealth, newHealth);
        Assert.LessOrEqual(newHealth, 75);
    }

    [UnityTest]
    public IEnumerator HealthHealNotAboveMaxHealthTest()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var player = new GameObject().AddComponent<Health>();
        player.SetHealth(90);
        int originalHealth = player.GetHealth();

        player.Heal(20);
        int newHealth = player.GetHealth();

        yield return null;

        Assert.AreNotEqual(originalHealth, newHealth);
        Assert.LessOrEqual(newHealth, 100);
    }
}
