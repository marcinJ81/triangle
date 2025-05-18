using System.Xml.Linq;
using Triangle3;
using Triangle3.Figures;
using Triangle3.ValidationServices;

namespace NUnitTestProject
{
    public class Tests
    {
        private  Validation _validation;
        [SetUp]
        public void Setup()
        {
            _validation = new Validation();
        }

        [Test]
        public void Test1()
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
    }
}