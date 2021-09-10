using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.SimulateDataForTesting.UserMocks.FakeData;
using Moq;

namespace DesktopUI.SimulateDataForTesting.UserMocks {
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
            MockUserDam.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(FakeUserReturnOkData.ReturnOfGetAllUsers);
            MockUserDam.Setup(x => x.GetAllUsersWithEdadAsync(It.IsAny<int>())).ReturnsAsync(FakeUserReturnOkData.ReturnOfGetAllUsersWithEdad);

        }

        private void InitializeNullData() {
            MockUserDam.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(FakeUserReturnNullData.ReturnOfGetAllUsers);
            MockUserDam.Setup(x => x.GetAllUsersWithEdadAsync(It.IsAny<int>())).ReturnsAsync(FakeUserReturnNullData.ReturnOfGetAllUsersWithEdad);
        }
    }
}
