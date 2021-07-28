string domain = "domain\\";
string ldapUrl = "LDAP://ldap.com.tw:389";
DirectorySearcher userSearch = new DirectorySearcher(ldapUrl);
userSearch.SearchRoot = new DirectoryEntry(ldapUrl, domain+uid, pwd);
userSearch.Filter = "(SAMAccountName=" + uid + ")";
SearchResult user = userSearch.FindOne();
if (user == null)
{
    throw new Exception("請確認帳號密碼是否正確.");
}

foreach (string key in user.Properties.PropertyNames)
{
    foreach (Object propValue in user.Properties[key])
    {

        Console.WriteLine(key + ":" + propValue);
    }
}

Console.WriteLine(user.Properties["distinguishedname"][0]);
Console.WriteLine("");
