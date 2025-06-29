using System.ComponentModel.DataAnnotations;

public class EditUsernameViewModel
{
    [Required]
    [Display(Name = "New Username")]
    public string NewUsername { get; set; } = string.Empty;
}