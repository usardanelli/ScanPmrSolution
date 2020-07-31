using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScanPmrWinForm.ViewModel
{
    public class UserViewModel
    {
		public string Username { get; set; }
		
		public string Domain { get; set; }

		public UserViewModel()
		{

		}

		public UserViewModel(string username, string domain)
		{
			Username = username ?? throw new ArgumentNullException(nameof(username));
			Domain = domain ?? throw new ArgumentNullException(nameof(domain));
		}
	}
}
