using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

namespace Encryption_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class RsaEncryption
        {
            private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            private RSAParameters _privateKey;
            private RSAParameters _publicKey;

            public RsaEncryption()
            {
                _privateKey = csp.ExportParameters(true);
                _publicKey = csp.ExportParameters(false);
            }

            public string GetPublicKey()
            {
                var sw = new StringWriter();
                var xs = new XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, _publicKey);
                return sw.ToString();
            }

            public string Encrypte(string plainText)
            {
                csp = new RSACryptoServiceProvider();
                csp.ImportParameters(_publicKey);

                var data = Encoding.Unicode.GetBytes(plainText);
            }
        }
    }
}
