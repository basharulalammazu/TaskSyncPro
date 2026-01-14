using System.Net;
using System.Net.Mail;

namespace BLL.Helpers
{
    public static class EmailService
    {
        //  Public method to send credentials
        public static bool SendUserCredentials(string toEmail, string userName, string password, string phoneNumber)
        {
            try
            {
                // Create mail body
                var mailMessage = CreateMailMessage(toEmail, userName, password, phoneNumber);

                // Send email using SMTP
                return SendEmail(mailMessage);
            }
            catch
            {
                return false;
            }
        }

        // Method to create the MailMessage
        private static MailMessage CreateMailMessage(string toEmail, string userName, string password, string phoneNumber)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("your_email@gmail.com", "TaskSync System"),
                Subject = "Your TaskSync Account Credentials",
                IsBodyHtml = true,
                Body = $@"
                    <h3>Welcome {userName}!</h3>
                    <p>Your account has been created successfully.</p>
                    <ul>
                        <li>Email: {toEmail}</li>
                        <li>Phone: {phoneNumber}</li>
                        <li>Password: {password}</li>
                    </ul>
                    <p>Please change your password after first login.</p>"
            };

            mailMessage.To.Add(toEmail);

            return mailMessage;
        }

        // Method to configure SMTP and send email
        private static bool SendEmail(MailMessage mailMessage)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com")) // or your SMTP server
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("basharulalammicrosoft@gmail.com", "nfcm wiah ulle uzrn"); // Use app password
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mailMessage);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
