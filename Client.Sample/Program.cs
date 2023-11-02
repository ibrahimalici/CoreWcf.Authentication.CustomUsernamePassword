TestService.ServiceClient serviceClient = new TestService.ServiceClient(TestService.ServiceClient.EndpointConfiguration.WSHttpBinding_IService);

serviceClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
serviceClient.ClientCredentials.UserName.UserName = "deneme";
serviceClient.ClientCredentials.UserName.Password = "1234";

string result = serviceClient.GetStrAsync().GetAwaiter().GetResult();

Console.WriteLine(result);