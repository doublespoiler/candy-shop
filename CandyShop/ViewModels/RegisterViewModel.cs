using System.ComponentModel.DataAnnotations;

namespace CandyShop.ViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "UserName is required")]
    [Display(Name = "UserName")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Required(ErrorMessage = "Password is required")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}