using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using qpaysftp.util;
using Renci.SshNet;
namespace qpaysftp
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pgp.EncryptFile(@"C:\inetpub\wwwroot\qpaysftp\qpaysftp\bin\CW_WalletSettlementFile_20221031_001.csv", @"C:\inetpub\wwwroot\qpaysftp\qpaysftp\bin\WalletSettlementFile_20221031_001.csv", @"C:\inetpub\wwwroot\qpaysftp\qpaysftp\bin\key.txt", true, true);

            try

            {
                string ftpip = "78.100.29.186";
                string PORT = "22";
                string UN = "cwallet";
                string pwd = "Fp9_D?t{";

                string SftpPth = "/QNB/cwallet_test";

                string SftPHost = "78.100.29.18";//Use Your IP Address

                string SftpUserName = "cwallet";

                string SftpPsd = "Fp9_D?t{";

                int SftpPort = 22; //Port 22 is defaulted for SFTP upload


                //Local file address

                string source = @"C:\inetpub\wwwroot\qpaysftp\qpaysftp\bin\enc_sample.csv";//Upload File Address

                string destination = SftpPth;// If destination address available


               // UploadSFTPFile(SftPHost, SftpUserName, SftpPsd, source, destination, SftpPort);

                


            }

            catch (Exception ex)

            {
                string err = ex.ToString();
                //lblresponsemsg.Text = ex.Message.ToString();

            }


        }
        private void UploadSFTPFile(string host, string username, string password, string sourcefile, string destination, int port)

        {

            using (SftpClient client = new SftpClient(host, port, username, password))

            {

                client.Connect();

                client.ChangeDirectory(destination);

                using (FileStream fs = new FileStream(sourcefile, FileMode.Open))

                {

                    client.BufferSize = 4 * 1024;

                    client.UploadFile(fs, Path.GetFileName(sourcefile));

                }

            }

        }
    }
}