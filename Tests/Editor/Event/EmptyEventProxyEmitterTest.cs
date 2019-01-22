﻿using Zinnia.Event;

namespace Test.Zinnia.Event
{
    using UnityEngine;
    using NUnit.Framework;
    using Test.Zinnia.Utility.Mock;

    public class EmptyEventProxyEmitterTest
    {
        private GameObject containingObject;
        private EmptyEventProxyEmitter subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject();
            subject = containingObject.AddComponent<EmptyEventProxyEmitter>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(subject);
            Object.DestroyImmediate(containingObject);
        }

        [Test]
        public void Receive()
        {
            UnityEventListenerMock emittedMock = new UnityEventListenerMock();
            subject.Emitted.AddListener(emittedMock.Listen);

            Assert.IsFalse(emittedMock.Received);
            subject.Receive();
            Assert.IsTrue(emittedMock.Received);
        }

        [Test]
        public void ReceiveInactiveGameObject()
        {
            UnityEventListenerMock emittedMock = new UnityEventListenerMock();
            subject.Emitted.AddListener(emittedMock.Listen);
            subject.gameObject.SetActive(false);

            Assert.IsFalse(emittedMock.Received);
            subject.Receive();
            Assert.IsFalse(emittedMock.Received);
        }

        [Test]
        public void ReceiveInactiveComponent()
        {
            UnityEventListenerMock emittedMock = new UnityEventListenerMock();
            subject.Emitted.AddListener(emittedMock.Listen);
            subject.enabled = false;

            Assert.IsFalse(emittedMock.Received);
            subject.Receive();
            Assert.IsFalse(emittedMock.Received);
        }
    }
}