using System;

/// <summary>
/// Summary description for Credentials
/// 
/// !! BE WARNED !!
/// 
/// The following is not the recommended practice for security. (i.e.) to include the
/// Passcode to your email account within the code and should be changed to a 
/// more secure method, if you plan on using this on a public network.
/// 
/// Since, this is being used on and internal private network, I am willing to
/// accept the minimal risk this posses, with the intention of changing it in later
/// releases.
/// 
/// </summary>
public class Credentials
{

    const String eMailAddress = "your@email.address"; // your email address goes here
    const String eMailPassPhrase = "your Pass Phrase goes here"; // Your password goes here

    public Credentials()
    {
        //
        // TODO: Add constructor logic here
        //
    }
 
    public String getEmailAddress()
    {
        return eMailAddress;
    }

    public String getEmailPassPhrase()
    {
        return eMailPassPhrase;
    }

}
}