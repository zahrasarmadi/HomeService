using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Enums;

public enum StatusEnum
{
    [Display(Name = "در انتظار پیشنهاد متخصصان")]
    AwaitingSuggestionExperts =1,
    [Display(Name = "در انتظار تایید مشتری")]
    AwaitingCustomerConfirmation=2,
    [Display(Name = "تایید شد")]
    Confirmed=3,
    //[Display(Name = "تایید نشد")]
    //NotConfirmed,
    //[Display(Name = "در انتظار پرداخت")]
    //AwaitingPayment,
    //[Display(Name = "پرداخت شد")]
    //Paied,
    //[Display(Name = "انجام شد")]
    //Done,
    //[Display(Name = "لغو شد")]
    //Canceled
}