using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PauseTest {
    public Transform Canvas;

	[UnityTest]
	public IEnumerator PausesGameAndUnpauses() {
        var pause = new GameObject().AddComponent<PauseGame>();
        pause.Pause(); //Initiate Pause
        Assert.AreEqual(Time.timeScale, 0); //Does it pause the game?
        Assert.IsTrue(Canvas.gameObject.activeInHierarchy); //Does the Menu pop up?
        pause.Pause();//Initiate Resume
        Assert.AreEqual(Time.timeScale, 1); //Does it pause the game?
        Assert.IsFalse(Canvas.gameObject.activeInHierarchy); //Does the Menu pop down?
        yield return null;
    }
    
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
}
