using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Triangle3.Figures;
using Triangle3.ValidationServices;

namespace NUnitTestProject.ValidationTests
{
    public class ValidationTests
    {
        private Validation _validation;

        [SetUp]
        public void Setup()
        {
            _validation = new Validation();
        }

        [Test]
        public void ValidationParameters_ShouldThrowArgumentException_WhenFigureTypeIsEmpty()
        {
            var parameters = new FigureDescriptionParameters
            {
                FigureType = "",
                BaseSide = 5,
                Height = 10,
                Name = "TestTriangle"
            };

            Assert.Throws<ArgumentException>(() => _validation.ValidationParameters(parameters));
        }

        [Test]
        public void ValidationParameters_ShouldThrowArgumentException_WhenRequiredParametersAreMissing()
        {
            var parameters = new FigureDescriptionParameters
            {
                FigureType = "triangle",
                Name = "TestTriangle"
            };

            Assert.Throws<ArgumentException>(() => _validation.ValidationParameters(parameters));
        }

        [Test]
        public void UniqueName_ShouldThrowArgumentException_WhenNameIsNotUnique()
        {
            var figureList = new List<IFigure>
            {
                new Triangle(5, 10, "ExistingTriangle"),
                new Triangle(5, 50, "ExistingTriangle")
            };

            Assert.Throws<ArgumentException>(() => _validation.UniqueName(figureList, "ExistingTriangle", nameof(Triangle)));
        }

        [Test]
        public void UniqueName_ShouldNotThrowException_WhenNameIsUnique()
        {
            var figureList = new List<IFigure>
            {
                new Triangle(5, 10, "ExistingTriangle")
            };

            Assert.DoesNotThrow(() => _validation.UniqueName(figureList, "NewTriangle", nameof(Triangle)));
        }
    }
}

