using Fano.Events.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.UnitTests.Events
{
    [TestClass]
    public class EventAggregatorTests
    {
        private IEventAggregator EventAggregator { get; set; }

        [TestInitialize]
        public void Init()
        {
            EventAggregator = new EventAggregator();
        }

        private class BaseEventArgs { }

        [TestMethod]
        public void Subscribe()
        {
            bool published = false;
            void SetPublished(BaseEventArgs a) => published = true;

            EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void Unsubscribe()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_MultipleSubscriptions()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);
            EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_NoSubscriptions()
        {
            bool published = false;

            void SetPublished(BaseEventArgs a) => published = true;

            EventAggregator.Unsubscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Publish_NoSubscriptions()
        {
            bool published = false;

            EventAggregator.Publish<BaseEvent<BaseEventArgs>, BaseEventArgs>(new BaseEventArgs());

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Subscribe_NoArgs()
        {
            bool published = false;
            void SetPublished() => published = true;

            EventAggregator.Subscribe<BaseEvent>(SetPublished);

            EventAggregator.Publish<BaseEvent>();

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void Unsubscribe_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            EventAggregator.Subscribe<BaseEvent>(SetPublished);
            EventAggregator.Unsubscribe<BaseEvent>(SetPublished);
            EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_MultipleSubscriptions_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            EventAggregator.Subscribe<BaseEvent>(SetPublished);
            EventAggregator.Subscribe<BaseEvent>(SetPublished);
            EventAggregator.Unsubscribe<BaseEvent>(SetPublished);
            EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void Unsubscribe_NoSubscriptions_NoArgs()
        {
            bool published = false;

            void SetPublished() => published = true;

            EventAggregator.Unsubscribe<BaseEvent>(SetPublished);

            Assert.IsFalse(published);
        }
        
        [TestMethod]
        public void Publish_NoSubscriptions_NoArgs()
        {
            bool published = false;

            EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }

        [TestMethod]
        public void PublishSubscribe_DifferentEventTypes()
        {
            bool published = false;
            void SetPublished(BaseEventArgs e) => published = true;

            EventAggregator.Subscribe<BaseEvent<BaseEventArgs>, BaseEventArgs>(SetPublished);

            EventAggregator.Publish<BaseEvent>();

            Assert.IsFalse(published);
        }
    }
}
