using CoreWcf.Authentication.CustomUsernamePassword;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCF.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<CoreWcf.Authentication.CustomUsernamePassword.Service>();


    WSHttpBinding basicHttpBinding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
    basicHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
    serviceBuilder.AddServiceEndpoint<CoreWcf.Authentication.CustomUsernamePassword.Service,
        CoreWcf.Authentication.CustomUsernamePassword.IService>(basicHttpBinding, "/Service.svc");
    serviceBuilder.ConfigureServiceHostBase<CoreWcf.Authentication.CustomUsernamePassword.Service>(serviceHost =>
    {
        serviceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode =
            UserNamePasswordValidationMode.Custom;
        serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomValidator();
        serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
    });

    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();
