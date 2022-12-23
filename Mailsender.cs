using System;
namespace MailSender
{
    public class Mailsender
    {
        public void Yandex(string _To, string _cc, string _subject, string _content, string _smtphost, int _smtpport, string _email, string _pass)
        {
            try
            {
                var _defaultCredentials = false;
                var _enableSsl = true;
                using (var smtpClient = new System.Net.Mail.SmtpClient(_smtphost, _smtpport))
                {
                    smtpClient.EnableSsl = _enableSsl;
                    smtpClient.UseDefaultCredentials = _defaultCredentials;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                    if (_defaultCredentials == false)
                    {
                        smtpClient.Credentials = new System.Net.NetworkCredential(_email, _pass);
                    }
                    smtpClient.Send(_email, _To, _subject, _content);
                }
            }
            catch (Exception)
            { throw; }
        }

        public void Outlook(string _To, string _cc, string _subject, string _content, string _smtphost, int _smtpport, string _email, string _pass)
        {
            try
            {
                System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();
                Client.Port = _smtpport;
                Client.Host = _smtphost;
                Client.EnableSsl = true;
                Client.Credentials = new System.Net.NetworkCredential(_email, _pass);
                Msg.To.Add(_To);
                Msg.From = new System.Net.Mail.MailAddress(_email);
                Msg.Subject = (_subject);
                Msg.Body = _content;
                Client.Send(Msg);


            }
            catch (Exception)
            { throw; }

        }
    }
}

