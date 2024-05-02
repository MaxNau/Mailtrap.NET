# Mailtrap.NET

.NET [Mailtrap](https://mailtrap.io) client (This client uses API v2)

## Installation

You can add this library to your project using [NuGet][nuget].

**Package Manager Console**
Run the following command in the “Package Manager Console”:

> PM> NuGet\Install-Package Mailtrap.NET -Version "version number"

**Visual Studio**
Right click to your project in Visual Studio, choose “Manage NuGet Packages” and search for ‘Mailtrap.NET’ and click ‘Install’.
([see NuGet Gallery][nuget-gallery].)

**.NET Core Command Line Interface**
Run the following command from your favorite shell or terminal:

> dotnet add package Mailtrap.NET --version "version number"

## Usage

You can initialize the client like the following:

```csharp
var client = new MailtrapClient(new HttpClient(), new MailtrapApiConfiguration(new Uri("<api url>"), "<api token>"));

```

#### Example: Send email with text

```csharp
var response = await client.EmailSending.SendAsync(new EmailWithText(
                from: new EmailInfo("sender@email.com"),
                to:
                [
                    new EmailInfo ("recepient@email.com")
                ],
                subject: "Custom Subject",
                text: "Hello, I hope you received this email"));
```
