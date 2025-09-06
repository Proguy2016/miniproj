namespace miniproj.Domain.ValueObjects
{
    public class Email
    {
        public string mail { get; set;}
        public Email(){}
        public Email(string mail)
        {
            this.mail = (mail.Contains("@") && mail.EndsWith(".com")) ? mail : throw new ArgumentException("email not valid");
        }
        public bool Equals(Email other)
        {
            return this.mail == other.mail;
        }
    }
}