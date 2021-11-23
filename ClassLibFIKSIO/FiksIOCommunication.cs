using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using KS.Fiks.IO.Client;
using KS.Fiks.IO.Client.Configuration;
using Ks.Fiks.Maskinporten.Client;
using System.Configuration;

namespace ClassLibFIKSIO
{
    public class FiksIOCommunication
    {
        public static FiksIOClient Config()
        {
            try
            {
                string accountId = ConfigurationManager.AppSettings["accountId"];
                string integrasjonId = ConfigurationManager.AppSettings["integrationId"];
                string integrasjonPassword = ConfigurationManager.AppSettings["integrationPassword"];
                string virksomhetsSertifikatIssuer = ConfigurationManager.AppSettings["issuer"]; //Issuer is the issuer i.e. the client_id  from DIFI, client_name: nois_test Integrasjon on https://selvbetjening-samarbeid.difi.no/#/ver2/integrations/
                string virksomhetsSertifikat = ConfigurationManager.AppSettings["virksomhetsSertifikat"];
                string accountPrivKeyFilename = ConfigurationManager.AppSettings["accountPrivateKeyFilename"];


                var currFolder = Directory.GetCurrentDirectory(); // executing assembly path
                var accountPrivateKeyFilename = Path.Combine(currFolder, accountPrivKeyFilename);

                if (!File.Exists(accountPrivateKeyFilename))
                {
                    accountPrivateKeyFilename = Path.Combine(ConfigurationManager.AppSettings["CertificatesFolder"], accountPrivKeyFilename);
                }

                
                Guid kontoId = new Guid(accountId);
                string privateKey = File.ReadAllText(accountPrivateKeyFilename);  

                var kontoConfig = new KontoConfiguration(
                    kontoId: kontoId /* Fiks IO accountId as Guid */,
                    privatNokkel: privateKey  /* Private key, paired with the public key supplied to Fiks IO account */);
                if (kontoConfig != null)
                {
                                        
                    // Id and password for integration associated to the Fiks IO account.
                    var integrasjonid = new Guid(integrasjonId);
                    
                    var integrasjonConfig = new IntegrasjonConfiguration(
                        integrasjonId: integrasjonid/* Integration id as Guid */,
                        integrasjonPassord: integrasjonPassword /* Integration password */, scope: "ks:fiks");
                    
                    string serialnr = virksomhetsSertifikat; 

                   
                    var certificate = GetFromStore(serialnr, StoreName.My, StoreLocation.LocalMachine);
                
                    if (certificate.HasPrivateKey)
                    {
                        string mySignature = certificate.PublicKey.Key.SignatureAlgorithm;
                       

                        // Create RSA provider from private key

                        // This works in .NET 5 & in .NEt framework 4.72
                        var rsaProvider = certificate.GetRSAPrivateKey();

                        //RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider)certificate.PrivateKey;
                        Debug.Print(certificate.SignatureAlgorithm.FriendlyName);

                    }

                    // ID-porten machine to machine configuration
                    var maskinportenConfig = new MaskinportenClientConfiguration(
                        audience: @"https://oidc-ver2.difi.no/idporten-oidc-provider/", // ID-porten audience path
                        tokenEndpoint: @"https://oidc-ver2.difi.no/idporten-oidc-provider/token", // ID-porten token path
                        issuer: virksomhetsSertifikatIssuer,  // KS issuer name// issuer: @"oidc_ks_test",  // KS issuer name
                        numberOfSecondsLeftBeforeExpire: 10, // The token will be refreshed 10 seconds before it expires
                        certificate: certificate/* virksomhetssertifikat as a X509Certificate2  */);


                    // Optional: Use custom api host (i.e. for connecting to test api) - fungerer IKKE uten denne.
                    var apiConfig = new ApiConfiguration(scheme: "https", host: "api.fiks.test.ks.no", port: 443);

                    // Optional: Use custom amqp host (i.e. for connection to test queue)
                    var amqp = new AmqpConfiguration(
                        host: "io.fiks.test.ks.no",
                        port: 5671); 
                   
                    var configuration = new FiksIOConfiguration(kontoConfiguration: kontoConfig, integrasjonConfiguration: integrasjonConfig, maskinportenConfiguration: maskinportenConfig, apiConfiguration: apiConfig, amqpConfiguration: amqp);

                    return new FiksIOClient(configuration);
                                    }
                                return null;
                               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static void UpdateCertificateProvider(ref X509Certificate2 cert)
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
    }
}