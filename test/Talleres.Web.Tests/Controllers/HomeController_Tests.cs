using System.Threading.Tasks;
using Talleres.Models.TokenAuth;
using Talleres.Web.Controllers;
using Shouldly;
using Xunit;

namespace Talleres.Web.Tests.Controllers
{
    public class HomeController_Tests: TalleresWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}