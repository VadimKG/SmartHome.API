using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SmartHome.API.Validators;
using SmartHome.Core.DTOs;

namespace SmartHome.API.Tests
{
    public class CreateDeviceValidatorTests 
    {
        private readonly CreateDeviceDtoValidator _validator = new();

        [Fact]
        public void Validate_ValidDto_ReturnsNoErrors()
        {
            var dto = new CreateDeviceDto { Name = "Living Room Light" };
            var result = _validator.Validate(dto);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Validate_ShouldFail_WhenTheNameIsEmpty(string? invalidName)
        {
            var dto = new CreateDeviceDto { Name = invalidName! };
            var result = _validator.Validate(dto);
            Assert.False(result.IsValid);
        }
    }
}
