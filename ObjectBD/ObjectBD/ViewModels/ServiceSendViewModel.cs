using System.ComponentModel.DataAnnotations;

namespace ObjectBD.ViewModels
{
    public class ServiceSendViewModel
    {
        [Required]
        public TipSend TipSend { get; set; }
    }
    public enum TipSend
    {
       Email,
       Sms
    }

}
