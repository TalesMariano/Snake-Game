using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BlockTests
    {
        
        [Test]
        public void EngineWeightActive()
        {
            BlockEngine blockEngine = new BlockEngine();

            blockEngine.Active = (true);

            Assert.Negative(blockEngine.Weight);
        }

        [Test]
        public void EngineWeightInactive()
        {
            BlockEngine blockEngine = new BlockEngine();

            blockEngine.Active = (false);

            Assert.Positive(blockEngine.Weight);
        }


    }
}
