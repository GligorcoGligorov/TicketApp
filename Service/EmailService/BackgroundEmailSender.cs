using System.Linq;
using System.Threading.Tasks;
using Domain;
using EShop.Service.Interface;
using Repository;

namespace Service
{
    public class BackgroundEmailSender : IBackgroundEmailSender
    {

        private readonly IEmailService _emailService;
        private readonly IRepository<EmailMessage> _mailRepository;

        public BackgroundEmailSender(IRepository<EmailMessage> mailRepository, IEmailService emailService)
        {
            _emailService = emailService;
            _mailRepository = mailRepository;
        }
        
        public async Task DoWork()
        {
            var emailList = _mailRepository.GetAll().Where(z => !z.Status).ToList();
            await _emailService.SendEmailAsync(await Task.FromResult(emailList));
        }

    }
}
