using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class TestScript
{
    [UnityTest]
    public IEnumerator TestScriptWithEnumeratorPasses()
    {
        var player = GameObject.Find("/Player");
        var knight = GameObject.Find("/knight");
        player.transform.position = knight.transform.position;
        Button button = GameObject.FindWithTag("Button").GetComponent<Button>();
        button.onClick.Invoke();
        var spawnedBox = GameObject.FindWithTag("DialogueBox");
        var knightTop = GameObject.Find("/knight/PotatoCookie");
        var adder = new Vector3(0, 1, 0);
        Assert.AreEqual(knightTop.transform.position, spawnedBox.transform.position + adder);
        yield return new WaitForSeconds(5);
    }
}
