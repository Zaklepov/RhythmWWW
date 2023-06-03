using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class SliderNoteScoreTesting
{
    
    [Test]
    public void SliderNoteScoreTestingSimplePasses()
    {
       
    }

    [UnityTest]
    public IEnumerator SliderNoteScoreTestingWithEnumeratorPasses()
    {
        var gameobject = new GameObject().AddComponent<GameManager>();
        gameobject.currScore = 0;
        gameobject.scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.comboText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.PerfectHoldHit();
        gameobject.NormalHoldHit();
        gameobject.GoodHoldHit();
        gameobject.NoteMiss();
        yield return null;
        Assert.AreEqual(600, gameobject.currScore);
    }
}
