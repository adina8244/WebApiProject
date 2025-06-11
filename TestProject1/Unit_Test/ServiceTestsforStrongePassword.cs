using static Services.Service;
using Xunit;
using Services;

namespace  TestProject1.Unit_Test

{
    public class ServiceTestsforStrongePassword
    {
        [Fact]
        public void ValidPassword_ShouldReturnFalse_ForWeakPassword()
        {
            // Arrange  
            var service = new Service(null, null); // Ensure the 'Service' class is implemented and accessible.  

            // Act  
            bool result = service.validPassword("123");

            // Assert  
            Assert.False(result);
        }

        [Fact]
        public void ValidPassword_ShouldReturnTrue_ForStrongPassword()
        {
            // Arrange  
            var service = new Service(null, null); // Ensure the 'Service' class is implemented and accessible.  

            // Act  
            bool result = service.validPassword("Str0ngP@ssw0rd!");

            // Assert  
            Assert.True(result);
        }
    }
}
