using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ComboTesting
{
   
    [Test]
    public void ComboTestingSimplePasses()
    {
        
    }

    
    [UnityTest]
    public IEnumerator ComboTestingWithEnumeratorPasses()
    {
       
        var gameobject = new GameObject().AddComponent<GameManager>();
        gameobject.scoreText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.comboText = new GameObject().AddComponent<TextMeshProUGUI>();
        gameobject.currCombo = 0;
        gameobject.PerfectHit();
        gameobject.NormalHit();
        gameobject.GoodHit();
        gameobject.PerfectHoldHit();
        gameobject.NormalHoldHit();
        gameobject.GoodHoldHit();
        yield return null;
        Assert.AreEqual(6, gameobject.currCombo);
    }
}
