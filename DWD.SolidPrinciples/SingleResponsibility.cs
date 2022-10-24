using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using DWD.Shared;

namespace DWD.SolidPrinciples;

public class SingleResponsibility
{
    #region The darkness
    
    public class UserService  
    {
        private readonly SmtpClient _smtpClient;
    
        public UserService(SmtpClient smtpClient) {
            _smtpClient = smtpClient;
        }
    
        public void Register(string email, string password)  
        {  
            if (!IsValidEmail(email)) {
                throw new ValidationException("Email is not an email");  
            }
      
            if (IsValidEmail(email)) {
                
                var user = new Person
                {
                    Email = email,
                    Password = password
                };
                
                SendEmail(new MailMessage("mysite@nowhere.com", email) { 
                    Subject="Foo" 
                });   
            }
        }
   
        public bool IsValidEmail(string email)  
        {  
            return email.Contains("@");  
        }
    
        public void SendEmail(MailMessage message)
        {  
            _smtpClient.Send(message);  
        }  
    }
    

    #endregion

    #region The light
    
    public class BetterUserService  
    {
        private readonly EmailService _emailService;

        public BetterUserService(EmailService emailService)
        {
            _emailService = emailService;
        }
        
        public void Register(string email, string password)  
        {
            if (!_emailService.IsValidEmail(email))
            {
                throw new ValidationException("Email is not an email");
            }
            
            var user = new User
            {
                Email = email,
                Password = password
            };
            
            // persist user.
            _emailService.SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject="HEllo foo" });  
        }
    }

    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }
        
        public bool IsValidEmail(string email)
        {
            return email.Contains('@');
        }

        public void SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);  
        }
    }
    

    #endregion
}