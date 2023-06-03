using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ComboMissTesting
{
    [Test]
    public void ComboMissTestingSimplePasses()
    {

    }

    [UnityTest]
    public IEnumerator ComboMissTestingWithEnumeratorPasses()
    {
        var gameobject = new GameObject().AddComponent<GameManager>();
        gameobject.scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.comboText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.currCombo = 0;
        gameobject.PerfectHit();
        gameobject.NormalHit();
        gameobject.GoodHit();
        gameobject.NoteMiss();
        yield return null;
        Assert.AreEqual(0, gameobject.currCombo);
    }
}
