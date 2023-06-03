using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class NotePressScoreTesting
{
  
    [Test]
    public void ScoreTestingSimplePasses()
    {
      
    }

    [UnityTest]
    public IEnumerator ScoreTestingWithEnumeratorPasses()
    {
        var gameobject = new GameObject().AddComponent<GameManager>();
        gameobject.currScore = 0;
        gameobject.scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.comboText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.PerfectHit();
        gameobject.NormalHit();
        gameobject.GoodHit();
        gameobject.NoteMiss();
        yield return null;
        Assert.AreEqual(300, gameobject.currScore);
    }
}
