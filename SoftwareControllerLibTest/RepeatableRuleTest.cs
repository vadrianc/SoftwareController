namespace SoftwareControllerLibTest
{
    using NUnit.Framework;
    using SoftwareControllerApi.Rule;
    using SoftwareControllerLib;

    [TestFixture]
    public class RepeatableRuleTest
    {
        [Test]
        [Category("RepeatableRule")]
        public void CheckRepeatTrue()
        {
            RepeatableRule rule = new RepeatableRule("RepeatableRule");
            rule.CanRepeat += RepeatTrue;

            CanRepeatHandler handler = rule.CanRepeat;
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler(), Is.EqualTo(true));
        }

        private static bool RepeatTrue()
        {
            return true;
        }

        [Test]
        [Category("RepeatableRule")]
        public void CheckRepeatFalse()
        {
            RepeatableRule rule = new RepeatableRule("RepeatableRule");
            rule.CanRepeat += RepeatFalse;

            CanRepeatHandler handler = rule.CanRepeat;
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler(), Is.EqualTo(false));
        }

        private static bool RepeatFalse()
        {
            return false;
        }
    }
}
