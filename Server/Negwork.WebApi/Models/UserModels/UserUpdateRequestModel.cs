namespace Negwork.WebApi.Models.UserModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class UserUpdateRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [MinLength(ModelConstants.MIN_USER_FIRSTNAME_LENGTH, 
            ErrorMessage = ErrorMessages.USER_FIRSTNAME_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_USER_FIRSTNAME_LENGTH,
            ErrorMessage = ErrorMessages.USER_FIRSTNAME_TOO_LONG)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        
        [MinLength(ModelConstants.MIN_USER_LASTNAME_LENGTH,
            ErrorMessage = ErrorMessages.USER_LASTNAME_TOO_SHORT)]
        [MaxLength(ModelConstants.MAX_USER_LASTNAME_LENGTH,
            ErrorMessage = ErrorMessages.USER_LASTNAME_TOO_LONG)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [MaxLength(ModelConstants.MAX_USER_ADDITIONAL_INFO_LENGTH,
            ErrorMessage = ErrorMessages.USER_ADD_INFO_TOO_LONG)]
        public string AdditionalInfo { get; set; }

        [Url(ErrorMessage = ErrorMessages.USER_IMAGE_URL_INVALID)]
        public string ProfileImage { get; set; }
    }
}