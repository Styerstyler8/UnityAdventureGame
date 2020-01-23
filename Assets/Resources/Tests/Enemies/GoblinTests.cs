using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.TestTools;

namespace Tests {

    public class GoblinDamageTest {

        [UnityTest]
        public IEnumerator DealDamageGoblin() {
            ItemDatabase database = new GameObject().AddComponent<ItemDatabase>();
            database.buildDatabase();
            DropTable dropTable = new DropTable();
            dropTable.listOfDrop = new List<LootDrop>() {
                new LootDrop("Sword",100),
                
            };
            yield return null;
            Item drop = null;
            while(drop == null)
                drop = dropTable.getDrop();
            yield return null;
            Assert.AreEqual(drop.name, "Sword");
            DropTable dropTable_v2 = new DropTable();
            dropTable.listOfDrop = new List<LootDrop>() {
                new LootDrop("Sword",50),
                new LootDrop("Axe",50)
            };
            yield return null;
            while (drop == null)
                drop = dropTable.getDrop();
            Assert.IsTrue(drop.name == "Axe" || drop.name == "Sword");
        }
    }

}
