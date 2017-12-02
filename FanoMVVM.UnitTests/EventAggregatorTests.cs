using System;
using FanoMvvm.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FanoMVVM.UnitTests
{
    [TestClass]
    public class EventAggregatorTests
    {
        private IEventAggregator EventAggregator { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.EventAggregator = new EventAggregator();
        }

        private class BaseEventArgs { }

        [TestMethod]
        public void Subscribe()
        {
            bool published = false;
            void SetPublished(BaseEventArgs a) => published = true;

            this.EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            this.EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void Unsubscribe()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            this.EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            this.EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            this.EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_MultipleSubscriptions()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            this.EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            this.EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            this.EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            this.EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_NoSubscriptions()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            this.EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Publish_NoSubscriptions()
        {
            bool published = false;

            this.EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Subscribe_NoArgs()
        {
            bool published = false;
            void SetPublished() => published = true;

            this.EventAggregator.Subscribe<BaseEvent>(SetPublished);

            this.EventAggregator.Publish<BaseEvent>();

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void Unsubscribe_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            this.EventAggregator.Subscribe<BaseEvent>(SetPublished);
            this.EventAggregator.Unsubscribe<BaseEvent>(SetPublished);
            this.EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_MultipleSubscriptions_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            this.EventAggregator.Subscribe<BaseEvent>(SetPublished);
            this.EventAggregator.Subscribe<BaseEvent>(SetPublished);
            this.EventAggregator.Unsubscribe<BaseEvent>(SetPublished);
            this.EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_NoSubscriptions_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            this.EventAggregator.Unsubscribe<BaseEvent>(SetPublished);

            Assert.IsFalse(published);
        }
        
        [TestMethod]
        public void Publish_NoSubscriptions_NoArgs()
        {
            bool published = false;

            this.EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void PublishSubscribe_DifferentEventTypes()
        {
            bool published = false;
            void SetPublished(BaseEventArgs e) => published = true;

            this.EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            this.EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }
    }
}
