using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Enums;

public enum StatusEnum
{
    [Display(Name = "در انتظار پیشنهاد متخصصان")]
    AwaitingSuggestionExperts,
    [Display(Name = "در انتظار تایید مشتری")]
    AwaitingCustomerConfirmation,
    [Display(Name = "تایید شد")]
    Confirmed,
    [Display(Name = "تایید نشد")]
    NotConfirmed,
    [Display(Name = "در انتظار پرداخت")]
    AwaitingPayment,
    [Display(Name = "پرداخت شد")]
    Paied,
    [Display(Name = "انجام شد")]
    Done,
    [Display(Name = "لغو شد")]
    Canceled
}