﻿using Zinnia.Extension;
using Zinnia.Rule;

namespace Test.Zinnia.Rule
{
    using UnityEngine;
    using NUnit.Framework;
    using Test.Zinnia.Utility.Stub;

    public class NegationRuleTest
    {
        private GameObject containingObject;
        private RuleContainer container;
        private NegationRule subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject();
            container = new RuleContainer();
            subject = containingObject.AddComponent<NegationRule>();
            container.Interface = subject;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(containingObject);
        }

        [Test]
        public void AcceptsFalse()
        {
            subject.rule = new RuleContainer
            {
                Interface = new FalseRuleStub()
            };
            Assert.IsTrue(container.Accepts(containingObject));
        }

        [Test]
        public void RefusesEmpty()
        {
            Assert.IsFalse(container.Accepts(containingObject));
        }

        [Test]
        public void RefusesTrue()
        {
            subject.rule = new RuleContainer
            {
                Interface = new TrueRuleStub()
            };
            Assert.IsFalse(container.Accepts(containingObject));
        }
    }
}