using System.Collections.Generic;
using DesktopUI.Backend.Data.Database;
using Newtonsoft.Json;

namespace DesktopUI.SimulateDataForTesting.UserMocks.FakeData
{
    internal static class FakeUserReturnOkData
    {
        public static List<Usuario> ReturnOfGetAllUsersWithEdad => JsonConvert.DeserializeObject<List<Usuario>>(@"
        [   
            {
                ""Id"": 99,
                ""Nombre"": ""Nombre 36"",
                ""Edad"": 26,
                ""FechaHoy"": ""2021-08-07T22:01:39.9796015""
            }
        ]");
        public static List<Usuario> ReturnOfGetAllUsers => JsonConvert.DeserializeObject<List<Usuario>>(@"
        [
            {
                ""Id"": 98,
                ""Nombre"": ""Nombre 36"",
                ""Edad"": 26,
                ""FechaHoy"": ""2021-08-07T22:01:39.9796015""
            },
            {
                ""Id"": 100,
                ""Nombre"": ""Nombre 99"",
                ""Edad"": 98,
                ""FechaHoy"": ""2021-08-07T22:01:39.9797669""
            },
            {
                ""Id"": 19,
                ""Nombre"": ""Nombre 55"",
                ""Edad"": 12,
                ""FechaHoy"": ""2021-08-07T22:01:39.9796531""
            }
        ]");
    }
}
