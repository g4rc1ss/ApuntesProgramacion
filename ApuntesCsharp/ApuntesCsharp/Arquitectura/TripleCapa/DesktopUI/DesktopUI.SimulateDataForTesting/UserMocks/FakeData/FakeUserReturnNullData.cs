using System.Collections.Generic;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.SimulateDataForTesting.UserMocks.FakeData {
    internal static class FakeUserReturnNullData {
        public static List<Usuario> ReturnOfGetAllUsers => null;
        public static List<Usuario> ReturnOfGetAllUsersWithEdad => null;
    }
}
