using CountryZip.Models;
using CountryZip.ViewModels;
using CountryZip.Controllers;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using CountryZip.Services;

namespace CountryZipTests.ControllersTests
{
    public class AccountControllerTests
    {
        [Fact]
        public void AccountController_Register_CreateCalledOnce()
        {
            //Arrange
            //public UserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger);
            Mock<UserManager<ApplicationUser>> userManager = new Mock<UserManager<ApplicationUser>>();//Нужно добавить все зависимости в конструктор
            Mock<SignInManager<ApplicationUser>> signInManager = new Mock<SignInManager<ApplicationUser>>();
            Mock<IMessageSender> message = new Mock<IMessageSender>();

            var registerViewModel = new AccountRegisterViewModel
            {
                FirstName = "Petr",
                LastName = "Petrov",
                Email = "Petr@com",
                Password = "ppp",
                ConfirmPassword = "ppp"
            };

            var user = new ApplicationUser
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.Email
            };

            userManager.Setup(x => x.CreateAsync(user, registerViewModel.Password)).ReturnsAsync(IdentityResult.Success);

            AccountController controller = new AccountController(userManager.Object, signInManager.Object, message.Object);

            //Act
            controller.Register(registerViewModel);

            //Assert
            userManager.Verify(x => x.CreateAsync(user, registerViewModel.Password),Times.Once);
        }
    }
}
