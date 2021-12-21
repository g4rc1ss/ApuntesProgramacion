namespace ActiveDirectory.ActiveDirectory
{
    internal class AD
    {
        public AD()
        {

            //Console.WriteLine("Teclea tu usuario de dominio");
            //var user = Console.ReadLine();
            //Console.WriteLine("Teclea la pass");
            //var pass = string.Empty;

            //for (var stop = false; stop == false;) {
            //    var ultimaKey = Console.ReadKey(true);
            //    if (ultimaKey.Key == ConsoleKey.Backspace) {
            //        try {
            //            pass = pass.Remove(pass.Length - 1);
            //        } catch (Exception) {
            //            Console.WriteLine("Todo borrado");
            //        }
            //    } else if (ultimaKey.Key != ConsoleKey.Enter) {
            //        pass += ultimaKey.KeyChar;
            //        Console.Write("*");
            //    } else {
            //        stop = true;
            //        Console.Write("\n");
            //    }
            //}

            //var credential = new NetworkCredential(user, pass);

            //var connection = new LdapConnection(new LdapDirectoryIdentifier("dominioAConectar", 389, false, false), credential) {
            //    AuthType = AuthType.Ntlm
            //};

            //connection.Bind();


            //Console.WriteLine("Teclea el usuario que quieres buscar");
            //var buscarUsuario = Console.ReadLine();
            //var searchFilter = $"(SAMAccountName={buscarUsuario})";
            //var search = new SearchRequest("", searchFilter, SearchScope.Subtree);

            //var response = (SearchResponse)connection.SendRequest(search);
            //SearchResultAttributeCollection searchResult = response.Entries[0]?.Attributes;
            //foreach (var x in searchResult.AttributeNames) {
            //    Console.WriteLine($"----------------------------------------------------------- \n\n" +
            //        $"{x}  =  {x.Value}");
            //}

            //var dir = new DirectoryEntry("LDAP://dominioAConectar", user, pass) {
            //    AuthenticationType = AuthenticationTypes.Secure
            //};
            //using (var search = new DirectorySearcher(dir)) {

            //    var variable = search.FindAll();
            //    dir = variable[0].GetDirectoryEntry();

            //    foreach (PropertyValueCollection x in dir.Properties) {
            //        Console.WriteLine($"----------------------------------------------------------- \n\n" +
            //            $"{x.PropertyName}  =  {x.Value}");
            //    }
            //}
        }
    }
}
