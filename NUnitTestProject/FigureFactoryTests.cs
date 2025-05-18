using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Triangle3.Figures;

namespace NUnitTestProject
{
    [TestFixture]
    public class FigureFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            // Reset the FigureList before each test to ensure isolation
            FigureFactory.FigureList.Clear();
        }

        [Test]
        public void CreateFigure_ValidTriangle_AddsTriangleToList()
        {
            // Arrange
            var parameters = new FigureDescriptionParameters
            {
                FigureType = "triangle",
                BaseSide = 5,
                Height = 10,
                Name = "Triangle1"
            };

            // Act
            FigureFactory.CreateFigure(parameters);

            // Assert
            Assert.AreEqual(1, FigureFactory.FigureList.Count);
            Assert.IsInstanceOf<Triangle>(FigureFactory.FigureList[0]);
            Assert.AreEqual("Triangle1", FigureFactory.FigureList[0].Name);
        }

        [Test]
        public void CreateFigure_ValidSquare_AddsSquareToList()
        {
            // Arrange
            var parameters = new FigureDescriptionParameters
            {
                FigureType = "square",
                Side = 4,
                Name = "Square1"
            };

            // Act
            FigureFactory.CreateFigure(parameters);

            // Assert
            Assert.AreEqual(1, FigureFactory.FigureList.Count);
            Assert.IsInstanceOf<Square>(FigureFactory.FigureList[0]);
            Assert.AreEqual("Square1", FigureFactory.FigureList[0].Name);
        }

        [Test]
        public void CreateFigure_ValidCircle_AddsCircleToList()
        {
            // Arrange
            var parameters = new FigureDescriptionParameters
            {
                FigureType = nameof(Circle),
                Radius = 7,
                Name = "Circle1"
            };

            // Act
            FigureFactory.CreateFigure(parameters);

            // Assert
            Assert.AreEqual(1, FigureFactory.FigureList.Count);
            Assert.IsInstanceOf<Circle>(FigureFactory.FigureList[0]);
            Assert.AreEqual("Circle1", FigureFactory.FigureList[0].Name);
        }

        [Test]
        public void Should_Pass_CreateFigure_AnotherType_DuplicateName()
        {
            // Arrange
            var parameters1 = new FigureDescriptionParameters
            {
                FigureType = nameof(Triangle),
                BaseSide = 5,
                Height = 10,
                Name = "DuplicateName"
            };

            var parameters2 = new FigureDescriptionParameters
            {
                FigureType = nameof(Square),
                Side = 4,
                Name = "DuplicateName"
            };

            // Act
            FigureFactory.CreateFigure(parameters1);
            FigureFactory.CreateFigure(parameters2);

            // Assert
            Assert.AreEqual(2, FigureFactory.FigureList.Count);
        }

        [Test]
        public void Should_NotPass_CreateFigure_SameType_DuplicateName()
        {
            // Arrange
            var parameters1 = new FigureDescriptionParameters
            {
                FigureType = nameof(Triangle),
                BaseSide = 5,
                Height = 10,
                Name = "DuplicateName"
            };

            var parameters2 = new FigureDescriptionParameters
            {
                FigureType = nameof(Triangle),
                BaseSide = 5,
                Height = 10,
                Name = "DuplicateName"
            };

            // Act
            FigureFactory.CreateFigure(parameters1);
            var ex = Assert.Throws<ArgumentException>(() => FigureFactory.CreateFigure(parameters2)); 
            Assert.AreEqual("Figure name must be unique.", ex.Message);

            Assert.AreEqual(1, FigureFactory.FigureList.Count);
            Assert.AreEqual("DuplicateName", FigureFactory.FigureList[0].Name);
        }

        [Test]
        public void CreateFigure_InvalidFigureType_ThrowsNotSupportedException()
        {
            // Arrange
            var parameters = new FigureDescriptionParameters
            {
                FigureType = "invalidType",
                Name = "InvalidFigure"
            };

            // Act & Assert
            var ex = Assert.Throws<NotSupportedException>(() => FigureFactory.CreateFigure(parameters));
            Assert.AreEqual("Figure type 'invalidType' is not supported.", ex.Message);
        }

        [Test]
        public void CreateFigure_NullParameters_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => FigureFactory.CreateFigure(null));
        }
    }
}

