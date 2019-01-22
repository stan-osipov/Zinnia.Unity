﻿using Zinnia.Extension;
using Zinnia.Rule;

namespace Test.Zinnia.Rule
{
    using UnityEngine;
    using NUnit.Framework;

    public class ActiveInHierarchyRuleTest
    {
        private GameObject containingObject;
        private RuleContainer container;
        private ActiveInHierarchyRule subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject();
            container = new RuleContainer();
            subject = containingObject.AddComponent<ActiveInHierarchyRule>();
            container.Interface = subject;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(containingObject);
        }

        [Test]
        public void AcceptsMatch()
        {
            containingObject.SetActive(true);
            Assert.IsTrue(container.Accepts(containingObject));
        }

        [Test]
        public void RefusesEmpty()
        {
            Assert.IsFalse(container.Accepts(null));
        }

        [Test]
        public void RefusesInactive()
        {
            containingObject.SetActive(false);
            Assert.IsFalse(container.Accepts(containingObject));
        }
    }
}