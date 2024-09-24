﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFU.Common.Models
{
	/// <summary>
	/// đăng ký tài khoản
	/// </summary>
	public class RegisterModel : ITrimable, IValidatableObject
	{
		/// <summary>
		/// FirstName
		/// </summary>
		[Required(ErrorMessage = Constants.Required)]
		[Display(Name = "Họ"), StringLength(255, ErrorMessage = Constants.MaxlengthError)]
		public string FirstName { get; set; }

		/// <summary>
		/// LastName
		/// </summary>
		[Required(ErrorMessage = Constants.Required)]
		[Display(Name = "Tên"), StringLength(255, ErrorMessage = Constants.MaxlengthError)]
		public string LastName { get; set; }

		/// <summary>
		/// PhoneNumber
		/// </summary>
		[Required(ErrorMessage = Constants.Required)]
		[StringLength(11, ErrorMessage = "Số điện thoại chỉ chứa tối đa 11 số!")]
		public string PhoneNumber { get; set; }

		/// <summary>
		/// email
		/// </summary>
		[Required(ErrorMessage = Constants.Required)]
		[Display(Name = "Email"), StringLength(255, ErrorMessage = Constants.MaxlengthError)]
		[EmailAddress(ErrorMessage = Constants.EmailAddressFormatError)]
		public string Email { get; set; }

		/// <summary>
		/// mật khẩu
		/// </summary>
		[Required(ErrorMessage = Constants.Required)]
		[Display(Name = "Mật khẩu"), StringLength(255, ErrorMessage = Constants.PasswordStringLengthError, MinimumLength = 6)]
		[DataType(DataType.Password)]
		[RegularExpression(Constants.REGEX_PASSWORD, ErrorMessage = Constants.PasswordInvalidFormat)]
		public string Password { get; set; }

		/// <summary>
		/// nhập lại mật khẩu
		/// </summary>
		[DataType(DataType.Password)]
		[Required(ErrorMessage = Constants.Required)]
		[Compare("Password", ErrorMessage = Constants.ConfirmPasswordError)]
		[Display(Name = "Nhập lại mật khẩu"), StringLength(255, ErrorMessage = Constants.MaxlengthError)]
		public string ConfirmPassword { get; set; }
		/// <summary>
		/// loại user
		/// </summary>
		public UserType UserType { get; set; }
		public void Trim()
		{
			FirstName = FirstName.Trim();
			LastName = LastName.Trim();
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			Trim();
			return new List<ValidationResult>();
		}
	}
}
