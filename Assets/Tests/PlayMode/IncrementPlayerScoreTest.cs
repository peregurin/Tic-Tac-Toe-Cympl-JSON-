using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class IncrementPlayerScoreTest
    {
        [Test]
        public void IncrementPlayerScore_IncreaseScoreByOne()
        {
            GameObject gameObject = new GameObject();
            GameController gameController = gameObject.AddComponent<GameController>();

            gameController.IncrementPlayerScore();

            Assert.AreEqual(1, gameController.PlayerXScore);
        }
    }
}
