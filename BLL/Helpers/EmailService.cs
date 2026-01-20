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
                Subject = "TaskSync Account Credentials",
                IsBodyHtml = true,
                Body = $@"
            <div style='font-family: Arial, Helvetica, sans-serif; color: #333;'>
                <h2 style='color:#2c3e50;'>Welcome to TaskSync, {userName}</h2>

                <p>
                    We are pleased to inform you that your <strong>TaskSync</strong> account has been successfully created.
                    Below are your account details:
                </p>

                <table style='border-collapse: collapse; margin-top: 10px;'>
                    <tr>
                        <td style='padding: 6px 10px; font-weight: bold;'>Email</td>
                        <td style='padding: 6px 10px;'>: {toEmail}</td>
                    </tr>
                    <tr>
                        <td style='padding: 6px 10px; font-weight: bold;'>Phone</td>
                        <td style='padding: 6px 10px;'>: {phoneNumber}</td>
                    </tr>
                    <tr>
                        <td style='padding: 6px 10px; font-weight: bold;'>Temporary Password</td>
                        <td style='padding: 6px 10px;'>: {password}</td>
                    </tr>
                </table>

                <p style='margin-top: 15px;'>
                    For security reasons, we strongly recommend that you change your password immediately after your first login.
                </p>

                <p>
                    If you did not request this account or believe this email was sent in error, please contact our support team immediately.
                </p>

                <p style='margin-top: 20px;'>
                    Best regards,<br/>
                    <strong>TaskSync Support Team</strong><br/>
                    <small>This is an automated email. Please do not reply.</small>
                </p>
            </div>"
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
