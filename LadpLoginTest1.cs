string uid = "user";
string pwd = "password";
string domain = "domain\\";

var ldi = new LdapDirectoryIdentifier("ldap.com.tw", 389);
using (var ldapConnection =
        new System.DirectoryServices.Protocols.LdapConnection(ldi))
{
    Console.WriteLine("LdapConnection is created successfully.");
    ldapConnection.AuthType = AuthType.Basic;
    ldapConnection.SessionOptions.ProtocolVersion = 3;
    var nc = new NetworkCredential(domain + uid, pwd);
    try
    {
        ldapConnection.Bind(nc);
    }
    catch (Exception ex)
    {
        if (ex.Message == "提供的認證無效。")
        {
            Console.WriteLine("帳密不對");
        }
        else
        {
            Console.WriteLine(ex);
        }

    }
    Console.WriteLine("LdapConnection authentication success");
}
