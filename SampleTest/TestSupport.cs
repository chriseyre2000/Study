using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleTest
{
    [Binding]
    public class TestSupport
    {
        public const string CalulatorInstance = "Calulator";

        [Given(@"The register has a value of (.*)")]
        public void GivenTheRegisterHasAValueOf(int value)
        {
            ScenarioContext.Current.Add(CalulatorInstance, new Calculator(value));
        }

        [When(@"I Add (.*)")]
        public void WhenIAdd(int value)
        {
           ScenarioContext.Current.Get<Calculator>(CalulatorInstance).Add(value);
        }

        [Then(@"the register will show (.*)")]
        public void ThenTheRegisterWillShow(int value)
        {
            Assert.That(ScenarioContext.Current.Get<Calculator>(CalulatorInstance).Register, Is.EqualTo(value));
        }
    }
}
