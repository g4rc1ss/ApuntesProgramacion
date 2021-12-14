using Microsoft.AspNetCore.Identity;

namespace WebApi.SimulateDataForTesting.UserMocks.FakeData {
    internal static class FakeUserReturnNullData {
        public static bool ReturnOfLogoutAsync => false;
        public static IdentityResult ReturnOfCreateUserAsync => null;
        public static IdentityResult ReturnOfCreateUserRoleAsync => null;
        public static IdentityResult ReturnOfDeleteUserAsync => null;
        public static SignInResult ReturnOfLogInAsync => null;
    }
}
