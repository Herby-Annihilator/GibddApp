using System;

namespace GibddApp.API.Data.Base
{
    public class DbAttributeNameAttribute : Attribute
    {
        public string AttributeName { get; set; }
        public DbAttributeNameAttribute(string attributeName, Register register = Register.Lower)
        {
            if (register == Register.Upper)
                AttributeName = attributeName.ToUpper();
            else if (register == Register.Default)
                AttributeName = attributeName;
            else
                AttributeName = attributeName.ToLower();
        }
    }
}
