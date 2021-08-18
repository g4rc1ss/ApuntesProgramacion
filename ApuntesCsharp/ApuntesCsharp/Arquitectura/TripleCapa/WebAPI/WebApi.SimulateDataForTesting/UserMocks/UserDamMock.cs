using Microsoft.AspNetCore.Identity;
using Moq;
using WebApi.SimulateDataForTesting.UserMocks.FakeData;
using WebAPI.Backend.Data.DataAccessManager.Interfaces;
using WebAPI.Backend.Data.Database.Identity;

namespace WebApi.SimulateDataForTesting.UserMocks {
    public class UserDamMock {
        public Mock<IUserDam> MockUserDam { get; set; }

        public UserDamMock(FakePossibilities possibilities) {
            MockUserDam = new Mock<IUserDam>();
            switch (possibilities) {
                case FakePossibilities.unknown:
                    break;
                case FakePossibilities.OK:
                    InitializeOKData();
                    break;
                case FakePossibilities.NoOk:
                    break;
                case FakePossibilities.NullData:
                    InitializeNullData();
                    break;
                case FakePossibilities.EmptyData:
                    break;
                default:
                    break;
            }
        }

        private void InitializeOKData() {
            MockUserDam.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            MockUserDam.Setup(x => x.CreateUserRoleAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            MockUserDam.Setup(x => x.DeleteUserAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
            MockUserDam.Setup(x => x.LogInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(SignInResult.Success);
            MockUserDam.Setup(x => x.LogoutAsync()).ReturnsAsync(FakeUserReturnOkData.ReturnOfLogoutAsync);

        }

        private void InitializeNullData() {
            MockUserDam.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(It.IsAny<IdentityResult>());
            MockUserDam.Setup(x => x.CreateUserRoleAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(It.IsAny<IdentityResult>());
            MockUserDam.Setup(x => x.DeleteUserAsync(It.IsAny<User>())).ReturnsAsync(It.IsAny<IdentityResult>());
            MockUserDam.Setup(x => x.LogInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(It.IsAny<SignInResult>());
            MockUserDam.Setup(x => x.LogoutAsync()).ReturnsAsync(FakeUserReturnNullData.ReturnOfLogoutAsync);
        }
    }
}
