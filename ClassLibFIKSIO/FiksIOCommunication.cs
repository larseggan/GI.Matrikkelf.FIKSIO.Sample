using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
//using System.Net.Security;
//using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using KS.Fiks.IO.Client;
using KS.Fiks.IO.Client.Configuration;
using Ks.Fiks.Maskinporten.Client;

namespace ClassLibFIKSIO
{
    public class FiksIOCommunication
    {
        FiksIOClient client;


        public FiksIOClient Config(string accountId, string accountPrivateKeyFilename, string integrasjonId, string integrasjonPassword,
            string virksomhetsSertifikat, string virksomhetsSertifikatIssuer)
        {
           
            try
            {


                // Fiks IO account configuration
                // accountId = "4b9b958b-2b2c-4986-b6c2-f646f2efe48f";
                Guid kontoId = new Guid(accountId);
                string privateKey = File.ReadAllText(accountPrivateKeyFilename);  /* Private key for offentlig nøkkel supplied to Fiks IO account */ //string privateKey = File.ReadAllText("privkey.pem");


                var kontoConfig = new KontoConfiguration(
                    kontoId: kontoId /* Fiks IO accountId as Guid */,
                    privatNokkel: privateKey  /* Private key, paired with the public key supplied to Fiks IO account */);
                if (kontoConfig != null)
                {

                    // Lars Eggan
                    // integrasjonid: 16547297-eca2-443e-88f7-f8aab1cb093b
                    // integrasjonPassord: v&d%FsPK5W1KSk1srRSR_&vbt_XpqOx7HSXgFghhCrz.^2k%yK

                    // Id and password for integration associated to the Fiks IO account.
                    var integrasjonid = new Guid(integrasjonId);
                    string integrasjonPassord = integrasjonPassword;

                    //integrasjonid = new Guid("23132e3a-72a2-4082-95e7-f7854907ec79");
                    //integrasjonPassord = "c9dfcbff-9264-4ce3-9c1c-32e6833a67e8";

                    // Norconsult test kommune
                    // Org nr: 	910230557
                    // aeedf954-3944-482a-bf7e-d193cc3fbc68
                    if (false)
                    {
                        integrasjonid = new Guid("aeedf954-3944-482a-bf7e-d193cc3fbc68");
                        integrasjonPassord = "wqaYNg4Esv2aK9AcBCj3I#K^@&^zMrKt(JNqwPR6~.yyXjQV%c";
                    }

                    //integrasjonPassord = "v&d%FsPK5W1KSk1srRSR_&vbt_XpqOx7HSXgFghhCrz.^2k%yK";
                    var integrasjonConfig = new IntegrasjonConfiguration(
                        integrasjonId: integrasjonid/* Integration id as Guid */,
                        integrasjonPassord: integrasjonPassord /* Integration password */, scope: "ks:fiks");


                    // Registry key in HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SystemCertificates\My\Certificates\5ACF50344AC3335C038C1EC5E2B1E297D1056EC5
                    // serialnumber inside certificate
                    string serialnr = virksomhetsSertifikat; // "0d808ba443780f415180e8";

                    //serialnr = "0228a6b80f1a3023217e7a"; //"0228a737024155eaedfd64"; // "0228a6b80f1a3023217e7a"; // "0228a737024155eaedfd64"; 
                    //var certificate = GetCertificate("29977dfe7faa9ab7e87d6edefa647229f1420cc8");

                    var certificate = GetFromStore(serialnr, StoreName.My, StoreLocation.LocalMachine);
                    var issuer = certificate.Issuer;
                    //issuer = "nois_test2";
                    issuer = certificate.Issuer;
                    issuer = @"oidc_ks_test";
                    issuer = "nois_test3";

                    issuer = "7d3fadd8-2f61-495e-9029-b1d2d84330ea"; // From DIFI, client_name: nois_test3: https://selvbetjening-samarbeid.difi.no/#/ver2/integrations/7d3fadd8-2f61-495e-9029-b1d2d84330ea
                    issuer = virksomhetsSertifikatIssuer; // From DIFI, client_name: nois_test3: https://selvbetjening-samarbeid.difi.no/#/ver2/integrations/7d3fadd8-2f61-495e-9029-b1d2d84330ea

                    // Hjem Min virksomhet Administrasjon av tjenester Ver 2

                    // TEST
                    if (false)
                    {
                        // Generert med: "C:\Program Files\Git\usr\bin\openssl.exe" pkcs12 -in "Buypass ID-NORCONSULT INFORMASJONSSYSTEMER AS-serienummer2609821720908501623078522-2019-09-10.p12" -clcerts -nokeys -out filename.crt
                        // med har ikke privatekey, så da feiler det.
                        certificate = GetCertificate("29977dfe7faa9ab7e87d6edefa647229f1420cc8");
                    }

                    if (false)
                    {
                        // Test reading the file directly:
                        var fileName = @"C:\ISY.GIS.WinMap\FIKS-IO\Certificates\Buypass ID-NORCONSULT INFORMASJONSSYSTEMER AS-serienummer2609821720908501623078522-2019-09-10.p12";
                        //fileName = @"C:\ISY.GIS.WinMap\FIKS-IO\Certificates\Buypass ID-NORCONSULT INFORMASJONSSYSTEMER AS-serienummer2609830868606812962028900-2019-09-10.p12";

                        fileName = @"C:\ISY.GIS.WinMap\FIKS-IO\Certificates\new-idp.pfx";
                        var secureString = "6KRxXffN7Pv6Utpj";
                        var certX509 = new X509Certificate2(fileName, secureString, X509KeyStorageFlags.DefaultKeySet);
                        certificate = certX509;
                        //X509Certificate2 certX509 = new X509Certificate2();
                        //issuer = certificate.Issuer;
                    }




                    //// TEST
                    //ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol
                    //                                        | (SecurityProtocolType.Tls
                    //                                           | (SecurityProtocolType.Tls11
                    //                                              | (SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3))));
                    //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(this.ValidateCertificate);

                    if (certificate.HasPrivateKey)
                    {
                        string mySignature = certificate.PublicKey.Key.SignatureAlgorithm;
                        //GetSignatureString();

                        // Create RSA provider from private key

                        // This works in .NET 5 & in .NEt framework 4.72
                        var rsaProvider = certificate.GetRSAPrivateKey();

                        //RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider)certificate.PrivateKey;
                        Debug.Print(certificate.SignatureAlgorithm.FriendlyName);

                        //Debug.Print(rsaProvider.CspKeyContainerInfo.ProviderName); /// ODes not worh on .NET 5

                        // Sign the signature with SHA512
                        //byte[] signedSignature = signedSignature = rsaProvider.SignData(originalData, alg);

                        //if (rsaProvider.VerifyData(or

                        if (false)
                        {
                            UpdateCertificateProvider(ref certificate);
                        }


                    }

                    // ID-porten machine to machine configuration
                    var maskinportenConfig = new MaskinportenClientConfiguration(
                        audience: @"https://oidc-ver2.difi.no/idporten-oidc-provider/", // ID-porten audience path
                        tokenEndpoint: @"https://oidc-ver2.difi.no/idporten-oidc-provider/token", // ID-porten token path
                        issuer: issuer,  // KS issuer name// issuer: @"oidc_ks_test",  // KS issuer name
                        numberOfSecondsLeftBeforeExpire: 10, // The token will be refreshed 10 seconds before it expires
                        certificate: certificate/* virksomhetssertifikat as a X509Certificate2  */);


                    // Optional: Use custom api host (i.e. for connecting to test api) - fungerer IKKE uten denne.
                    var apiConfig = new ApiConfiguration(scheme: "https", host: "api.fiks.test.ks.no", port: 443);

                    // Optional: Use custom amqp host (i.e. for connection to test queue)
                    var amqp = new AmqpConfiguration(
                        host: "io.fiks.test.ks.no",
                        port: 5671);  /*port: 5671);*/
                    //amqp = null;

                    //amqp.SslOption.AcceptablePolicyErrors =
                    //    System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors |
                    //    System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch |
                    //    System.Net.Security.SslPolicyErrors.RemoteCertificateNotAvailable;

                    // Combine all configurations
                    var configuration = new FiksIOConfiguration(kontoConfiguration: kontoConfig, integrasjonConfiguration: integrasjonConfig, maskinportenConfiguration: maskinportenConfig, apiConfiguration: apiConfig, amqpConfiguration: amqp);


                    client = new FiksIOClient(configuration);

                    return client;
                }

                return null;

                // client secret: nois test - FEIL 0a77508c-fae7-4a4d-bbb5-b54a8c6f763d
                // Ny: nois_test2
                // client id: 23132e3a-72a2-4082-95e7-f7854907ec79
                // client_secret: c9dfcbff-9264-4ce3-9c1c-32e6833a67e8

                // nois_test3: 7d3fadd8-2f61-495e-9029-b1d2d84330ea
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void UpdateCertificateProvider(ref X509Certificate2 cert)
        {
            // DOES NOT WORK

            //RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider)cert.PrivateKey;
            var privKey = cert.PrivateKey as RSACryptoServiceProvider;

            // will be needed later
            var exported = privKey.ToXmlString(true);

            // change CSP
            var cspParams = new CspParameters()
            {
                ProviderType = 24,
                ProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider"
            };

            // create new PrivateKey from CspParameters and exported privkey
            var newPrivKey = new RSACryptoServiceProvider(cspParams);
            newPrivKey.FromXmlString(exported);

            // Assign edited private key back
            cert.PrivateKey = newPrivKey;
        }

        public static X509Certificate2 GetFromStore(string serialnr, StoreName storeName, StoreLocation storeLocation)
        {
            X509Store xstore = new X509Store(storeName, storeLocation);
            xstore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2 cert = null;
            foreach (X509Certificate2 cert2 in xstore.Certificates)
            {
                if (cert2.SerialNumber.ToLower().CompareTo(serialnr.Replace(" ", "").ToLower()) == 0)
                {
                    cert = cert2;
                    break;
                }
            }
            if (cert == null)
            {
                throw new Exception("Failed getting certificate.");
            }
            return cert;
        }

        //private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //{
        //    //  See:     http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=81152&SiteId=1
        //    // Return True to force the certificate to be accepted.
        //    return true;
        //}

        private static X509Certificate2 GetCertificate(string ThumbprintIdPortenVirksomhetssertifikat)
        {

            //Det samme virksomhetssertifikat som er registrert hos ID-porten
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            X509Certificate2 cer = null;
            store.Open(OpenFlags.ReadOnly);
            //Henter Arkitektum sitt virksomhetssertifikat
            X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindByThumbprint, ThumbprintIdPortenVirksomhetssertifikat, false);
            if (cers.Count > 0)
            {
                cer = cers[0];
            };
            store.Close();

            return cer;
        }

    }

    public class FiksMaskinporten
    {
        // Se: https://github.com/ks-no/fiks-maskinporten-client-dotnet

        public static async Task SetupMaskinPortenAsync()
        {
            try
            {

                await Task.Delay(100).ConfigureAwait(false);
                string virksomhetsSertifikat = "0228a737024155eaedfd64"; // "0228a6b80f1a3023217e7a"; //"0d808ba443780f415180e8";

                string serialnr = virksomhetsSertifikat; // "0d808ba443780f415180e8";
                var certificate = FiksIOCommunication.GetFromStore(serialnr, StoreName.My, StoreLocation.LocalMachine);

                // Setup configuration
                var maskinportenConfig = new MaskinportenClientConfiguration(
                    audience: @"https://oidc-ver2.difi.no/idporten-oidc-provider/", // ID-porten audience path
                    tokenEndpoint: @"https://oidc-ver2.difi.no/idporten-oidc-provider/token", // ID-porten token path
                    issuer: @"oidc_ks_test",  // Issuer name
                    numberOfSecondsLeftBeforeExpire: 10, // The token will be refreshed 10 seconds before it expires
                    certificate: certificate /* virksomhetssertifikat as a X509Certificate2  */);

                // Create instance of MaskinportenClient

                var maskinportenClient = new MaskinportenClient(maskinportenConfig);

                // Get access token
                //await Task.Delay(100).ConfigureAwait(false);
                var scope = "ks:fiks"; // Scope for access token
                //var accessToken = maskinportenClient.GetAccessToken(scope).Result;
                var accessToken = await maskinportenClient.GetAccessToken(scope);

                


                // Send request using access token
                var httpClient = new HttpClient();
                //var tokenEndpoint = "https://test.ks.no/api/token";
                //using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint/* api uri */))
                //{
                //    // Set authorization header with maskinporten access token
                //    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);

                //    /* Set other headers. Integration id and password etc.*/

                //    // Send message
                //    var response = await httpClient.SendAsync(requestMessage);

                //    /* Handle response */
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


    }

}