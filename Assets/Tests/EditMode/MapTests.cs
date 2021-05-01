using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MapTests
    {
        
        [Test]
        public void MapTestsSimplePasses()
        {
            
        }

        [Test]
        public void EmptyPosition()
        {
            MapGrid map = new MapGrid(Vector2Int.one);

            Assert.AreEqual(expected: Vector2Int.zero, actual: map.GetRandomEmptyPos());
        }

        [Test]
        public void FullMap()
        {
            MapGrid map = new MapGrid(Vector2Int.one);

            Block block = new Block();

            map.AddBlock(block, Vector2Int.zero);

            Assert.AreEqual(expected: Vector2Int.one *-1, actual: map.GetRandomEmptyPos());
        }

    }
}
