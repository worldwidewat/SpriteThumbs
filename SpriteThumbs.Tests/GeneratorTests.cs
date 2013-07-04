﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldWideWat.SpriteThumbs;

namespace UpboatMe.SpriteThumbs.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void TempSpriteGeneratorTest()
        {
            var configuration = new SpriteThumbsConfiguration();
            configuration.SetSpriteOutputPath(@".\");
            configuration.SetImageQualityPercent(50);

            SpriteGenerator g = new SpriteGenerator(configuration);

            g.Generate();
        }
    }
}
