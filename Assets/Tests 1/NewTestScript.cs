using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        GameObject[] bubbles = {
            Resources.Load<GameObject>("bluePF"),
            Resources.Load<GameObject>("limePF"),
            Resources.Load<GameObject>("cyanPF"),
            Resources.Load<GameObject>("fuchsiaPF"),
            Resources.Load<GameObject>("yellowPF"),
            Resources.Load<GameObject>("redPF")
        };

        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BallMovement()
        {
            GameObject blueBubble = GameObject.Instantiate(bubbles[0]);
            blueBubble.AddComponent<Rigidbody2D>();
            blueBubble.GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            Assert.AreEqual(blueBubble.GetComponent<Rigidbody2D>().position, new Vector2(0, 0));
            blueBubble.GetComponent<Rigidbody2D>().gravityScale = 4;
            blueBubble.GetComponent<Rigidbody2D>().mass = 20;
            yield return null;
            Assert.AreNotEqual(blueBubble.GetComponent<Rigidbody2D>().velocity, new Vector2(0, 0));
            yield return null;
        }

        [UnityTest]
        public IEnumerator BallStopMovement()
        {
            GameObject blueBubble = GameObject.Instantiate(bubbles[0]);
            blueBubble.AddComponent<Rigidbody2D>();
            blueBubble.GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            Assert.AreEqual(blueBubble.GetComponent<Rigidbody2D>().position, new Vector2(0, 0));
            blueBubble.GetComponent<Rigidbody2D>().gravityScale = 4;
            blueBubble.GetComponent<Rigidbody2D>().mass = 20;
            blueBubble.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yield return null;
            Assert.AreEqual(blueBubble.GetComponent<Rigidbody2D>().velocity, new Vector2(0, 0));
            yield return null;
        }
    }
}
