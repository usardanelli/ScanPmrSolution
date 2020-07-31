using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;

namespace ScanPmrWinForm
{
    public partial class FormLogin : Form
    {
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();

		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
		public FormLogin()
        {
            InitializeComponent();
			
        }

		private void txtuser_Enter(object sender, EventArgs e)
		{
			if (txtuser.Text == "Username")
			{
				txtuser.Text = "";
				txtuser.ForeColor = Color.LightGray;
			}
		}

		private void txtuser_Leave(object sender, EventArgs e)
		{
			if (txtuser.Text == "")
			{
				txtuser.Text = "Username";
				txtuser.ForeColor = Color.Silver;
			}
		}

		private void txtpass_Enter(object sender, EventArgs e)
		{
			if (txtpass.Text == "Password")
			{
				txtpass.Text = "";
				txtpass.ForeColor = Color.LightGray;
				txtpass.UseSystemPasswordChar = true;
			}
		}

		private void txtpass_Leave(object sender, EventArgs e)
		{
			if (txtpass.Text == "")
			{
				txtpass.Text = "Password";
				txtpass.ForeColor = Color.Silver;
				txtpass.UseSystemPasswordChar = false;
			}
		}

		private void btnclose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnminimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void FormLogin_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

		private void Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

	

		private void btnLogin_Click(object sender, EventArgs e)
		{

			IntPtr tokenHandle = new IntPtr(0);
			try
			{


				string UserName = null;
				string domainName = null;
				string Pwd = null;

				//The MachineName property gets the name of your computer.
				domainName = Environment.UserDomainName;

				UserName = txtuser.Text;
				Pwd = txtpass.Text;

				const int LOGON32_PROVIDER_DEFAULT = 0;
				const int LOGON32_LOGON_INTERACTIVE = 2;
				tokenHandle = IntPtr.Zero;
				//Call the LogonUser function to obtain a handle to an access token.
				bool returnValue = LogonUser(UserName, domainName, Pwd, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out tokenHandle);

				if (returnValue == false)
				{
					//This function returns the error code that the last unmanaged function returned.
					int ret = Marshal.GetLastWin32Error();

					msgError(GetErrorMessage(ret));

					txtpass.Text = "Password";
					txtpass.UseSystemPasswordChar = false;
					txtuser.Focus();
				}
				else
				{
					//Create the WindowsIdentity object for the Windows user account that is
					//represented by the tokenHandle token.

					WindowsIdentity newId = new WindowsIdentity(tokenHandle);
					WindowsPrincipal userperm = new WindowsPrincipal(newId);
					MainForm main = new MainForm(new ViewModel.UserViewModel(UserName, domainName));
				
					main.Show();
					main.FormClosed += Logout;
					this.Hide();

					//Verify whether the Windows user has administrative credentials.

				}
				CloseHandle(tokenHandle);
			}
			catch (Exception ex)
			{
				msgError("Exception occurred. " + ex.Message);

			}

		}
		private void msgError(string msg)
		{
			lblerrmsg.Text = "    " + msg;
			lblerrmsg.Visible = true;
		}
		private void Logout(object sender, FormClosedEventArgs e)
		{
			txtpass.Text = "Password";
			txtpass.UseSystemPasswordChar = false;
			txtuser.Text = "Username";
			lblerrmsg.Visible = false;
			this.Show();
		}
	
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool LogonUser(string lpszUsername,
		 string lpszDomain,
		 string lpszPassword,
		 int dwLogonType,
		 int dwLogonProvider,
		 out IntPtr phToken
		 );

		[DllImport("kernel32.dll")]
		public static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref String lpBuffer, int nSize, ref IntPtr Arguments);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CloseHandle(IntPtr hObject);


		public static string GetErrorMessage(int errorCode)
		{
			int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100;
			int FORMAT_MESSAGE_IGNORE_INSERTS = 0x200;
			int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

			int msgSize = 255;
			string lpMsgBuf = null;
			int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;

			IntPtr lpSource = IntPtr.Zero;
			IntPtr lpArguments = IntPtr.Zero;
			int returnVal = FormatMessage(dwFlags, ref lpSource, errorCode, 0, ref lpMsgBuf, msgSize, ref lpArguments);

			if (returnVal == 0)
			{
				throw new Exception("Failed to format message for error code " + errorCode.ToString() + ". ");
			}
			return lpMsgBuf;

		}

		private void txtuser_TextChanged(object sender, EventArgs e)
		{
			if (txtuser.Text != "Username" && txtuser.TextLength > 2 && txtpass.Text != "Password" && txtpass.TextLength > 2)
				btnLogin.Enabled = true;
			else
				btnLogin.Enabled = false;
		}

		private void txtpass_TextChanged(object sender, EventArgs e)
		{
			if(txtuser.Text != "Username" && txtuser.TextLength > 2 && txtpass.Text != "Password" && txtpass.TextLength > 2)
				btnLogin.Enabled = true;
			else
				btnLogin.Enabled = false;
		}
	}
}
