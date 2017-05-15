namespace Sitecore.Mvp.Models.Modules
{
    using System;

    public class ContactFormArgs : EventArgs
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
