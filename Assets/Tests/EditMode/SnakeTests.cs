using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SnakeTests
    {
        
        [Test]
        public void TurnLeft()
        {
            Snake snake = new Snake();

            snake.direction = Vector2Int.up;

            snake.Turn(-1);

            Assert.AreEqual(expected: Vector2Int.left, actual: snake.direction);
        }

        [Test]
        public void TurnRight()
        {
            Snake snake = new Snake();

            snake.direction = Vector2Int.up;

            snake.Turn(1);

            Assert.AreEqual(expected: Vector2Int.right, actual: snake.direction);
        }

    }
}
