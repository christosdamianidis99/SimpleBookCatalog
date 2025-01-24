using MailKit.Net.Smtp; // For MailKit's SmtpClient
using MimeKit; // For creating email messages

namespace RazorClassLibraryMain.EmailVerificationClasses
{
    public static class EmailHelper
    {
        public static async Task SendVerificationEmailAsync(string recipientEmail, string verificationLink)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("SimpleBookCatalog", "chydami@teiemt.gr")); // Sender's name and email
            email.To.Add(MailboxAddress.Parse(recipientEmail)); // Recipient's email
            email.Subject = "Verify Your Email Address"; // Email subject
            email.Body = new TextPart("html")
            {
                Text = $"<p>Hi,</p><p>Thank you for registering. Please verify your account by clicking the link below:</p><p><a href='{verificationLink}'>Verify Now</a></p>"
            };

            try
            {
                // Use the fully-qualified class name for MailKit's SmtpClient
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls); // Connect with TLS
                await smtp.AuthenticateAsync("Your-email", "your-password-or-password-generated-from-2fa"); // Authenticate with credentials
                await smtp.SendAsync(email); // Send the email
                await smtp.DisconnectAsync(true); // Disconnect cleanly
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }
    }
}
