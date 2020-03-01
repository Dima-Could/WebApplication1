using Quartz;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace QuartzApp.Jobs
{
    public class EmailSender : IJob
    {
        private readonly CustomerRepository _custumeRepository;
        private readonly WebAppContext _context;

        public EmailSender()
        {
            _context = new WebAppContext();
            _custumeRepository = new CustomerRepository(_context);
        }
        public async Task Execute(IJobExecutionContext context)
        {
           
            var todayCustomerBirthDay = _custumeRepository.GetBirthDateCustomers();

                  foreach (var customer in todayCustomerBirthDay)
            {
                using (var message = new MailMessage("dimalomaca@gmail.com", customer.Email))
                {
                    message.Subject = "Privet " + customer.FirstName;
                    message.Body = "Pidar " + customer.LastName;
                    using (var client = new SmtpClient
                    {
                        EnableSsl = true,
                        Host = "smtp.gmail.com",
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("Your Gmail address", "Your Gmail password")
                    })
                    {
                        await client.SendMailAsync(message);
                    }
                }     
            }
        }
    }
}