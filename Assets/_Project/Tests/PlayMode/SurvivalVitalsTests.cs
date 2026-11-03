using NUnit.Framework;using UnityEngine;using LastHope.Survival;
namespace LastHope.Tests {
 public sealed class SurvivalVitalsTests {
  GameObject actor;SurvivalVitals vitals;
  [SetUp]public void Setup(){actor=new GameObject("Vitals test actor");vitals=actor.AddComponent<SurvivalVitals>();}
  [TearDown]public void TearDown(){Object.DestroyImmediate(actor);}
  [Test]public void StartsAtFullVitals(){Assert.AreEqual(100,vitals.Health,0.01f);Assert.AreEqual(100,vitals.Hunger,0.01f);Assert.AreEqual(100,vitals.Thirst,0.01f);}
  [Test]public void FoodAndWaterRestoreAndClamp(){vitals.SetVitals(60,90,80);vitals.Eat(30);vitals.Drink(50);Assert.AreEqual(100,vitals.Hunger,0.01f);Assert.AreEqual(100,vitals.Thirst,0.01f);}
  [Test]public void DamageCannotMakeHealthNegative(){vitals.Damage(500);Assert.AreEqual(0,vitals.Health,0.01f);Assert.IsTrue(vitals.IsDead);}
 }
}
