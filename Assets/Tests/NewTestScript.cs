using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        GameObject partyPF = new GameObject();
        GameObject bubble;
        GameObject arrowPF = new GameObject();
        GameObject[] bubbles = {
            Resources.Load<GameObject>("bluePF"),
            Resources.Load<GameObject>("limePF"),
            Resources.Load<GameObject>("cyanPF"),
            Resources.Load<GameObject>("fuchsiaPF"),
            Resources.Load<GameObject>("yellowPF"),
            Resources.Load<GameObject>("redPF")
        };

        [Test]
        public void PartyCreated()
        {
            GameObject party = GameObject.Instantiate(partyPF);
            Assert.AreNotEqual(party, null);
        }

        [Test]
        public void BallCreated()
        {
            GameObject blueBubble = GameObject.Instantiate(bubbles[0]);
            Assert.AreNotEqual(blueBubble, null);
        }

        [Test]
        public void BallDestroy()
        {
            GameObject blueBubble = GameObject.Instantiate(bubbles[0]);
            GameObject.DestroyImmediate(blueBubble);
            Assert.IsNull(blueBubble);
        }

        [Test]
        public void ArrowMovement()
        {
            GameObject arrow = GameObject.Instantiate(arrowPF);
            arrow.transform.position = new Vector3(0, 0, 0);
            Assert.AreEqual(arrow.transform.position, new Vector3(0, 0, 0));
            Vector3 difference = new Vector3(50, 40, 0) - arrow.transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
            Assert.AreNotEqual(arrow.transform.rotation, new Vector3(0, 0, 0));
        }
    }
}
