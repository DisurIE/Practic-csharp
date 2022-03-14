using System;
using System.Text.RegularExpressions;
using System.Globalization;
namespace PracticaFirstTask
{

	public class Person
	{
		public int id;
		public string surname;
		public string name;
		public string patronymic;
		public string passport;
		public string numPhone;
		public string mail;
		public Person(int id, string surname, string name, string patronymic, string passport, string numPhone, string mail)
		{
			if (id > 0 && id <= 10)
			{
				this.id = id;
			}
			else
			{
				id = 0;
			}
			if (!Regex.IsMatch(surname, @"\P{IsCyrillic}") && surname[0] == char.ToUpper(surname[0]))
			{
				this.surname = surname;
			}
			else
			{
				surname = null;
			}
			if (!Regex.IsMatch(name, @"\P{IsCyrillic}") && name[0] == char.ToUpper(name[0]))
			{
				this.name = name;
			}
			else
			{
				this.name = null;
			}
			if (!Regex.IsMatch(patronymic, @"\P{IsCyrillic}") && patronymic[0] == char.ToUpper(patronymic[0]))
			{
				this.patronymic = patronymic;
			}
			else
			{
				this.patronymic = null;
			}
			if (passpor(passport) && passport.ToString()[0] != '0' && passport.ToString()[6] != '0')
			{
				this.passport = passport;
			}
			else
			{
				this.passport = null;
			}

			if (numPhone[0] == '+' && numPhone[1] == '7' && numPhone.Length == 12 && validNumber(numPhone))
			{
				this.numPhone = numPhone;
			}
			else if (numPhone[0] == '8' && numPhone.Length == 11 && validNumber(numPhone))
			{
				this.numPhone = numPhone;
			}
			else
			{
				this.numPhone = null;
			}

			if (mail.Contains("@firma.ru") && ssValidMail(mail) && IsValidEmail(mail) && IssValidEmail(mail))
			{
				this.mail = mail;
			}
			else
			{
				this.mail = null;
			}
		}


		public string Compare()
		{
			return id + "\t" + surname + "\t" + name + "\t" + patronymic + "\t" + passport + "\t" + numPhone + "\t" + mail;
		}
		public bool passpor(string passport)
        {
			if(passport.Length > 10)
            {
				return false;
            }
			for (int i = 0; i < passport.Length; i++) {
				if((int)passport[i] < 48 || (int)passport[i] > 57)
                {
					return false;
                }
			}
			return true;
        }

		public bool validNumber(string passport)
		{

			for (int i = 1; i < passport.Length; i++)
			{
				if ((int)passport[i] < 48 || (int)passport[i] > 57)
				{
					return false;
				}
			}
			return true;
		}

		public bool ssValidMail(string e_mail)
		{
			string expr =
			  "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";

			Match isMatch =
			  Regex.Match(e_mail, expr, RegexOptions.IgnoreCase);

			return isMatch.Success;
		}
		public static bool IssValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				// Normalize the domain
				email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
									  RegexOptions.None, TimeSpan.FromMilliseconds(200));

				// Examines the domain part of the email and normalizes it.
				string DomainMapper(Match match)
				{
					// Use IdnMapping class to convert Unicode domain names.
					var idn = new IdnMapping();

					// Pull out and process domain name (throws ArgumentException on invalid)
					string domainName = idn.GetAscii(match.Groups[2].Value);

					return match.Groups[1].Value + domainName;
				}
			}
			catch (RegexMatchTimeoutException e)
			{
				return false;
			}
			catch (ArgumentException e)
			{
				return false;
			}

			try
			{
				return Regex.IsMatch(email,
					@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}
		}

		public bool IsValidEmail(string email)
		{
			bool sas = true;
			if ((int)email[0] >= 97 && (int)email[0] <= 122)
			{
				sas = true;
			}
            else
            {
				return false;
            }
			int i = 0;
			while (email[i] != '@')
			{
				if ((int)email[i] >= 97 && (int)email[i] <= 122 || (int)email[i] == 95 && (int)passport[i] >= 48 || (int)passport[i] <= 57)
				{
					sas = true;
				}
				else
				{
					sas = false;
					return sas;
				}
				i++;
			}
			return sas;
		}
	}
}