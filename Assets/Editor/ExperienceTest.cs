
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExperienceTest
{
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator ExperienceGainTest()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var player = new GameObject();
        player.gameObject.AddComponent<Experience>();
        player.gameObject.AddComponent<Player>();
        int originalXP = player.GetComponent<Experience>().GetCurrentXP();

        player.GetComponent<Experience>().AddXP(50);
        int newXP = player.GetComponent<Experience>().GetCurrentXP();

        yield return null;

        Assert.AreNotEqual(originalXP, newXP);
        Assert.AreEqual(newXP, 50);
    }
 
[UnityTest]
public IEnumerator LevelUpTest()
{
    // Use the Assert class to test conditions.
    // yield to skip a frame
    var player = new GameObject();
    player.gameObject.AddComponent<Experience>();
    player.gameObject.AddComponent<Player>();
    int originalLevel = player.GetComponent<Experience>().GetLevel();
    int originalXP = player.GetComponent<Experience>().GetCurrentXP();

    player.GetComponent<Experience>().AddXP(150);
    int newXP = player.GetComponent<Experience>().GetCurrentXP();
    int newLevel= player.GetComponent<Experience>().GetLevel();

    yield return null;

    Assert.AreNotEqual(originalXP, newXP);
    Assert.AreEqual(newXP, 50);
    Assert.AreNotEqual(originalLevel, newLevel);
    Assert.AreEqual(newLevel, 2);
}

[UnityTest]
public IEnumerator ExperienceCarryOverTest()
{
    // Use the Assert class to test conditions.
    // yield to skip a frame
    var player = new GameObject();
    player.gameObject.AddComponent<Experience>();
    player.gameObject.AddComponent<Player>();
    int originalLevel = player.GetComponent<Experience>().GetLevel();

    player.GetComponent<Experience>().AddXP(100);
    int newLevel = player.GetComponent<Experience>().GetLevel();

    yield return null;

    Assert.AreNotEqual(originalLevel, newLevel);
    Assert.AreEqual(newLevel, 2);
}

[UnityTest]
public IEnumerator MultipleLevelsTest()
{
    // Use the Assert class to test conditions.
    // yield to skip a frame
    var player = new GameObject();
    player.gameObject.AddComponent<Experience>();
    player.gameObject.AddComponent<Player>();
    int firstLevel = player.GetComponent<Experience>().GetLevel();

    player.GetComponent<Experience>().AddXP(100);
    int secondLevel = player.GetComponent<Experience>().GetLevel();

    player.GetComponent<Experience>().AddXP(200);
    int thirdLevel = player.GetComponent<Experience>().GetLevel();

    yield return null;

    Assert.AreNotEqual(firstLevel, secondLevel);
    Assert.AreNotEqual(firstLevel, thirdLevel);
    Assert.AreNotEqual(secondLevel, thirdLevel);
    Assert.AreEqual(firstLevel, 1);
    Assert.AreEqual(secondLevel, 2);
    Assert.AreEqual(thirdLevel, 3);
}

[UnityTest]
public IEnumerator DoubleLevelJumpTest()
{
    // Use the Assert class to test conditions.
    // yield to skip a frame
    var player = new GameObject();
    player.gameObject.AddComponent<Experience>();
    player.gameObject.AddComponent<Player>();
    int originalLevel = player.GetComponent<Experience>().GetLevel();

    player.GetComponent<Experience>().AddXP(300);
    int newLevel = player.GetComponent<Experience>().GetLevel();
    int newCurrentXP = player.GetComponent<Experience>().GetCurrentXP();

    yield return null;

    Assert.AreNotEqual(originalLevel, newLevel);
    Assert.AreEqual(originalLevel, 1);
    Assert.AreEqual(newLevel, 3);
    Assert.AreEqual(newCurrentXP, 0);
}

[UnityTest]
public IEnumerator ExperienceToLevelUpTest()
{
    // Use the Assert class to test conditions.
    // yield to skip a frame
    var player = new GameObject();
    player.gameObject.AddComponent<Experience>();
    player.gameObject.AddComponent<Player>();
    int firstXPToLevelUp = player.GetComponent<Experience>().GetXPToLevelUp();

    player.GetComponent<Experience>().AddXP(100);
    int secondXPToLevelUp = player.GetComponent<Experience>().GetXPToLevelUp();

    player.GetComponent<Experience>().AddXP(200);
    int thirdXPToLevelUp = player.GetComponent<Experience>().GetXPToLevelUp();

    yield return null;

    Assert.AreEqual(firstXPToLevelUp, 100);
    Assert.AreEqual(secondXPToLevelUp, 200);
    Assert.AreEqual(thirdXPToLevelUp, 300);
}
}
