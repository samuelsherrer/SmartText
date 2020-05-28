using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartText.Tests
{
    public class SmartTextReadHelperTests
    {
        private readonly ISmartTextReadHelper _smartTextReadHelper;
        public SmartTextReadHelperTests()
        {
            _smartTextReadHelper = new SmartTextReadHelper();
        }

        [Theory]
        [InlineData("E2                            001800483022          000000000002310                                                                                  02000063317222468")]
        public void ReadLineResultShouldBeEquals(string line)
        {
            // Arrange
            var body = new Body()
            {
                Id = "E",
                CompanyId = "2                       ",
                CustomerId = "001800483022",
                Amount = 4500,
                Description = "                                                            ",
                PaymentType = "",
                MovimentCode = "0",
                CustomerType = "63317222468",
                Identifier = "2"
            };

            var properties = new List<Property>()
            {
                new Property("Id", 1, 1),
                new Property("CompanyId", 2, 26),
                new Property(27, 30, 3),
                new Property("CustomerId", 31, 42, 4),
                new Property(43, 52, 5),
                new Property("Amount", 53, 67, 6),
                new Property(68, 69, 7),
                new Property("Description", 70, 129),
                new Property(130, 147, 9),
                new Property("PaymentType", 148, 149),
                new Property("MovimentCode", 150, 150),
                new Property("CustomerType", 151, 151),
                new Property("Identifier", 152, 166)
            };

            var result = new Body();

            // Act
            _smartTextReadHelper.ReadLine<Body>(properties, line, ref result);

            // Assert
            Assert.Equal(body, result);
        }
    }

    class Body
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string PaymentType { get; set; }
        public string MovimentCode { get; set; }
        public string CustomerType { get; set; }
        public string Identifier { get; set; }
    }
}
