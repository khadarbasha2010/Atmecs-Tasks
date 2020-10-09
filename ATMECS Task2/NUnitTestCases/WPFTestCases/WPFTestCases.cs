using FluentAssertions;
using FrontEnd.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCases.WPFTestCases
{
    class WPFTestCases
    {
        
        [SetUp]
        public void Setup()
        {

        }
        [Test,Order(0)]
        public void WpfValidationTestCase()
        {
            (ViewModelClass.DataValidation("", "").Length).Should().BeGreaterThan(0);
        }
        [Test, Order(1)]
        public void WpfValidationstrTestCase()
        {
            (ViewModelClass.DataValidation("Textbox1", "Textbox1")).Should().BeEmpty();
        }
    }
}
